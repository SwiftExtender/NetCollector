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
        [Route("/scan_profiles_tool_profiles/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesDelete")]
        public async Task<IActionResult> ScanProfilesToolProfilesDelete(int id)
        {
                try
                {
                    if (id <= 0)
                    {
                        return BadRequest("ScanProfilesToolProfiles ID is required");
                    }
                    var scanProfilesToolProfiles = await _context.ScanProfilesToolProfiles.FindAsync(id);
                    if (scanProfilesToolProfiles == null)
                    {
                        return NotFound($"ScanProfilesToolProfiles with ID {id} not found");
                    }
                    _context.ScanProfilesToolProfiles.Remove(scanProfilesToolProfiles);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(500, new { ex.Message });
                }
        }
        [HttpGet]
        [Route("/scan_profiles_tool_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesToolProfilesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ScanProfilesToolProfiles>), description: "OK")]
        public async Task<IActionResult> ScanProfilesToolProfilesGet([FromQuery] PaginationRequestModels queryParams)
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
        [Route("/scan_profiles_tool_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesToolProfilesPatch")]
        public async Task<IActionResult> ScanProfilesToolProfilesPatch([FromBody] ScanProfilesToolProfiles scanProfilesStartupProfile)
        {
            try
            {
                if (scanProfilesStartupProfile.Id <= 0)
                {
                    return BadRequest("ScanProfilesToolProfile ID is required");
                }
                var existingscanProfilesStartupProfile = await _context.ScanProfilesToolProfiles.FindAsync(scanProfilesStartupProfile.Id);
                if (existingscanProfilesStartupProfile == null)
                {
                    return NotFound($"ScanProfilesToolProfile with ID {scanProfilesStartupProfile.Id} not found");
                }
                existingscanProfilesStartupProfile.Order = scanProfilesStartupProfile.Order;
                existingscanProfilesStartupProfile.ScanProfileId = scanProfilesStartupProfile.ScanProfileId;
                existingscanProfilesStartupProfile.StartupProfileId = scanProfilesStartupProfile.StartupProfileId;
                existingscanProfilesStartupProfile.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }
        [HttpPost]
        [Route("/scan_profiles_tool_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesToolProfilesPost")]
        public async Task<IActionResult> ScanProfilesToolProfilesPost([FromBody] ScanProfilesToolProfiles scanProfilesStartupProfiles)
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
