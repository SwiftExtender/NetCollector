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

namespace NetFighter.Controllers
{
    [ApiController]
    //[Authorize]
    public class DomainsHostsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DomainsHostsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete]
        [Route("/domainshosts/{id}")]
        [ValidateModelState]
        [SwaggerOperation("DomainsHostsDelete")]
        public async Task<IActionResult> DomainsHostsDelete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("DomainsHosts ID is required");
                }
                var domain = await _context.DomainsHosts.FindAsync(id);
                _context.DomainsHosts.Remove(domain);
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
        [Route("/domainshosts")]
        [ValidateModelState]
        [SwaggerOperation("DomainsHostsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<DomainsHosts>), description: "OK")]
        public async Task<IActionResult> DomainsHostsGet([FromQuery] PaginationRequestModels queryParams)
        {

            try
            {
                // Start with base query
                var query = _context.DomainsHosts.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var domainsHosts = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<DomainsHosts>
                {
                    Data = domainsHosts,
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
        [Route("/domainshosts")]
        [ValidateModelState]
        [SwaggerOperation("DomainsHostsPatch")]
        public async Task<IActionResult> DomainsHostsPatch([FromQuery (Name = "domain_id")]string domainId, [FromQuery (Name = "host_id")]string hostId, [FromHeader (Name = "Prefer")]string prefer, [FromBody]DomainsHosts domainsHosts)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/domainshosts")]
        [ValidateModelState]
        [SwaggerOperation("DomainsHostsPost")]
        public async Task<IActionResult> DomainsHostsPost([FromBody]DomainsHosts domainsHosts)
        {

            throw new NotImplementedException();
        }
    }
}
