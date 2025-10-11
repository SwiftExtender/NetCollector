using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using NetFighter.Attributes;
using NetFighter.Models;
using NetFighter.Data;
using NetFighter.RequestModels;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NetFighter.Models.ResponseModels;

namespace NetFighter.Controllers
{
    [ApiController]
    //[Authorize]
    public class ScanProfilesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScanProfilesApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/scan_profiles/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesDelete")]
        public async Task<IActionResult> ScanProfilesDelete(int id)
        {
            {
                try
                {
                    if (id <= 0)
                    {
                        return BadRequest("Scan Profile ID is required");
                    }
                    var existingScanProfile = await _context.ScanProfiles.FindAsync(id);
                    if (existingScanProfile == null)
                    {
                        return NotFound($"Scan Profile with ID {id} not found");
                    }
                    _context.ScanProfiles.Remove(existingScanProfile);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(500, new { ex.Message });
                }
            }
        }
        [HttpGet]
        [Route("/scan_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ScanProfiles>), description: "OK")]
        public async Task<IActionResult> ScanProfilesGet([FromQuery] PaginationRequestModels queryParams)
        {
            try
            {
                // Start with base query
                var query = _context.ScanProfiles.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var scanProfiles = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<ScanProfiles>
                {
                    Data = scanProfiles,
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
        [Route("/scan_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesPatch")]
        public async Task<IActionResult> ScanProfilesPatch([FromBody]ScanProfiles scanProfile)
        {
            try
            {
                if (scanProfile.Id <= 0)
                {
                    return BadRequest("ScanProfile ID is required");
                }
                var existingScanProfile = await _context.ScanProfiles.FindAsync(scanProfile.Id);
                if (existingScanProfile == null)
                {
                    return NotFound($"ScanProfile with ID {scanProfile.Id} not found");
                }
                existingScanProfile.Name = scanProfile.Name;
                existingScanProfile.Description = scanProfile.Description;
                existingScanProfile.UpdatedAt = DateTime.UtcNow;
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
        [Route("/scan_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesPost")]
        public async Task<IActionResult> ScanProfilesPost([FromBody]ScanProfiles scanProfiles)
        {
            try
            {
                _context.ScanProfiles.Add(new ScanProfiles() { 
                    Description = scanProfiles.Description,
                    Name = scanProfiles.Name, 
                    CreatedAt = DateTime.UtcNow
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
