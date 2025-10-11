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
    ////[Authorize]
    public class HostsApiController : ControllerBase
    { 
        private readonly ApplicationDbContext _context;

        public HostsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete]
        [Route("/hosts/{id}")]
        [ValidateModelState]
        [SwaggerOperation("HostsDelete")]
        public async Task<IActionResult> HostsDelete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Host ID is required");
                }
                var existinghost = await _context.Hosts.FindAsync(id);
                if (existinghost == null)
                {
                    return NotFound($"Host with ID {id} not found");
                }
                _context.Hosts.Remove(existinghost);
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
        [Route("/hosts")]
        [ValidateModelState]
        [SwaggerOperation("HostsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(PagedResponse<Hosts>), description: "Get paginated and filtered hosts")]
        public async Task<IActionResult> HostsGet([FromQuery] PaginationRequestModels queryParams)
        {
            try
            {
                // Start with base query
                var query = _context.Hosts.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var hosts = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<Hosts>
                {
                    Data = hosts,
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
        //later
        //[HttpGet]
        //[Route("/hosts/{id}")]
        //[ValidateModelState]
        //[SwaggerOperation("GetPortsofHost")]
        //[SwaggerResponse(statusCode: 200, type: typeof(List<Hosts>), description: "Get host by id")]
        //public async Task<IActionResult> GetPortsofHost(int id)
        //{
        //    try
        //    {
        //        Hosts selectedHost = await _context.Hosts.SingleAsync(p => p.Id == id);
        //        return Ok(selectedHost);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(500, new { ex.Message });
        //    }
        //}

        [HttpPatch]
        [Route("/hosts")]
        [ValidateModelState]
        [SwaggerOperation("HostsPatch")]
        public async Task<IActionResult> HostsPatch([FromBody] Hosts host)
        {
            try
            {
                if (host.Id <= 0)
                {
                    return BadRequest("Host ID is required");
                }
                var existinghost = await _context.Hosts.FindAsync(host.Id);
                if (existinghost == null)
                {
                    return NotFound($"Host with ID {host.Id} not found");
                }
                existinghost.Ip = host.Ip;
                existinghost.Info = host.Info;
                existinghost.UpdatedAt = DateTime.UtcNow;
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
        [Route("/hosts")]
        [ValidateModelState]
        [SwaggerOperation("HostsPost")]
        public async Task<IActionResult> HostsPost([FromBody] Hosts host)
        {
            try
            {
                _context.Hosts.Add(new Hosts() { Ip = host.Ip, Info = host.Info, Ports = host.Ports });
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
