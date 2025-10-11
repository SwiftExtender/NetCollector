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

            throw new NotImplementedException();
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
        public async Task<IActionResult> ScanProfilesPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "description")]string description, [FromQuery (Name = "created_at")]string createdAt, [FromHeader (Name = "Prefer")]string prefer, [FromBody]ScanProfiles scanProfiles)
        {

            throw new NotImplementedException();
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
