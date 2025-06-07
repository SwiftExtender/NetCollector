using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NetFighter.Filters;
using NetFighter.OpenApi;
using NetFighter.Formatters;
using Microsoft.AspNetCore.Http;
using NetFighter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using NetFighter.Models;
using NetFighter.Services;
using Serilog;
using Microsoft.AspNetCore.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NetFighter
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// The application configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error() // Log only errors and higher
                .WriteTo.File(
                    path: "netf-errors.log", // File path
                    rollingInterval: RollingInterval.Infinite, // Disable log rotation
                    fileSizeLimitBytes: 10_000_000, // ~10 MB max size
                    retainedFileCountLimit: 1, // Keep only 1 file
                    rollOnFileSizeLimit: true, // Roll when size exceeded (but we retain only 1)
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}"
                )
                .CreateLogger();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Match the connection string from your manual instance
                options.UseSqlite($"Data Source=data.db").LogTo(Console.WriteLine, LogLevel.Information); ;
            });
            //services.AddDbContext<ApplicationDbContext>();
            services
                .AddControllersWithViews(options => {
                    options.InputFormatters.Insert(0, new InputFormatterStream());
                })
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    });
                });
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IPasswordHasher<Users>, PasswordHasher<Users>>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
                {
                    options.Cookie.Name = "Auth";
                    options.LoginPath = "/Login";
                    options.AccessDeniedPath = "/Error";
                    options.Cookie.HttpOnly = true;
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                });

            services
                .AddSwaggerGen(c =>
                {
                    c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
                    
                    c.SwaggerDoc("13.0.0", new OpenApiInfo
                    {
                        Title = "standard public schema",
                        Description = "standard public schema (ASP.NET Core 8.0)",
                        TermsOfService = new Uri("https://github.com/openapitools/openapi-generator"),
                        Contact = new OpenApiContact
                        {
                            Name = "OpenAPI-Generator Contributors",
                            Url = new Uri("https://github.com/openapitools/openapi-generator"),
                            Email = ""
                        },
                        License = new OpenApiLicense
                        {
                            Name = "NoLicense",
                            Url = new Uri("http://localhost")
                        },
                        Version = "13.0.0",
                    });
                    c.CustomSchemaIds(type => type.FriendlyId(true));
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{Assembly.GetExecutingAssembly().GetName().Name}.xml");

                    // Include DataAnnotation attributes on Controller Action parameters as OpenAPI validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    c.OperationFilter<GeneratePathParamsValidationFilter>();
                });
                services
                    .AddSwaggerGenNewtonsoftSupport();
        }

        //static Task CreateInitialUserAsync(UserManager<IdentityUser> userManager,
        //    IConfiguration config)
        //{
        //    // Get user credentials from configuration
        //    var email = config["InitialUser:Email"]!;
        //    var password = config["InitialUser:Password"]!;

        //    // Check if user exists
        //    if (userManager.FindByEmailAsync(email) is null)
        //    {
        //        var user = new IdentityUser { UserName = email, Email = email };
        //        var result = userManager.Create(user, password);

        //        if (!result.Succeeded)
        //            throw new Exception($"User creation failed: {string.Join(", ", result.Errors)}");

        //        // Optional: Add roles or claims here
        //    }
        //}

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.EnsureCreated();
                var hasher = new PasswordHasher<Users>();
                var init = new AuthService(dbContext, hasher);
                dbContext.Users.Add(init.ConstructUser("user", "test"));
                dbContext.SaveChanges();
            }
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    logger.LogError(exception, "Unhandled exception");
                    await Results.Problem().ExecuteAsync(context);
                });
            });
            //app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger(c =>
                {
                    c.RouteTemplate = "openapi/{documentName}/openapi.json";
                })
                .UseSwaggerUI(c =>
                {
                    // set route prefix to openapi, e.g. http://localhost:8080/openapi/index.html
                    c.RoutePrefix = "openapi";
                    //TODO: Either use the SwaggerGen generated OpenAPI contract (generated from C# classes)
                    c.SwaggerEndpoint("/openapi/13.0.0/openapi.json", "standard public schema");

                    //TODO: Or alternatively use the original OpenAPI contract that's included in the static files
                    // c.SwaggerEndpoint("/openapi-original.json", "standard public schema Original");
                });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
