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
    public class ScanProfilesStartupProfilesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScanProfilesStartupProfilesApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/scan_profiles_startup_profiles/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesDelete")]
        public async Task<IActionResult> ScanProfilesStartupProfilesDelete(int id)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/scan_profiles_startup_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ScanProfilesToolProfiles>), description: "OK")]
        public async Task<IActionResult> ScanProfilesStartupProfilesGet([FromQuery] PaginationRequestModels queryParams)
        {
            try
            {
                // Start with base query
                var query = _context.ScanProfilesToolProfiles.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var scanProfilesToolProfiles = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<ScanProfilesToolProfiles>
                {
                    Data = scanProfilesToolProfiles,
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
        [Route("/scan_profiles_startup_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesPatch")]
        public async Task<IActionResult> ScanProfilesStartupProfilesPatch([FromQuery (Name = "scan_profile_id")]string scanProfileId, [FromQuery (Name = "startup_profile_id")]string startupProfileId, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Prefer")]string prefer, [FromBody] ScanProfilesToolProfiles scanProfilesStartupProfiles)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/scan_profiles_startup_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesPost")]
        public async Task<IActionResult> ScanProfilesStartupProfilesPost([FromBody] ScanProfilesToolProfiles scanProfilesStartupProfiles)
        {
            try
            {
                _context.ScanProfilesToolProfiles.Add(new ScanProfilesToolProfiles() {
                    StartupProfileId = scanProfilesStartupProfiles.StartupProfileId, 
                    ScanProfileId = scanProfilesStartupProfiles.ScanProfileId, 
                    Order = scanProfilesStartupProfiles.Order                
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
