using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetFighter.Attributes;
using NetFighter.Data;
using NetFighter.Models;
using NetFighter.Models.ResponseModels;
using NetFighter.RequestModels;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace NetFighter.Controllers
{
    [ApiController]
    //[Authorize]
    public class ToolsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToolsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/tools/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ToolsDelete")]
        public async Task<IActionResult> ToolsDelete(int id)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/tools")]
        [ValidateModelState]
        [SwaggerOperation("ToolsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Tools>), description: "OK")]
        public async Task<IActionResult> ToolsGet([FromQuery] PaginationRequestModels queryParams)
        {
            try
            {
                // Start with base query
                var query = _context.Tools.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var tools = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<Tools>
                {
                    Data = tools,
                    PageNumber = queryParams.PageNumber,
                    PageSize = queryParams.PageSize,
                    TotalCount = totalCount,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.PageSize)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }
        [HttpPatch]
        [Route("/tools")]
        [ValidateModelState]
        [SwaggerOperation("ToolsPatch")]
        public async Task<IActionResult> ToolsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "description")]string description, [FromQuery (Name = "version")]string version, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "updated_at")]string updatedAt, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Tools tools)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/tools")]
        [ValidateModelState]
        [SwaggerOperation("ToolsPost")]
        public async Task<IActionResult> ToolsPost([FromBody]Tools tools)
        {
            try
            {
                _context.Tools.Add(new Tools() { 
                    Name = tools.Name, Description = tools.Description, CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow, VarVersion = tools.VarVersion
                });
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }
    }
}
