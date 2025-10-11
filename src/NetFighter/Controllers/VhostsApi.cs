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
    public class VhostsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VhostsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/vhosts/{id}")]
        [SwaggerOperation("VhostsDelete")]
        public async Task<IActionResult> VhostsDelete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Vhost ID is required");
                }
                var existingvhost = await _context.Vhosts.FindAsync(id);
                if (existingvhost == null)
                {
                    return NotFound($"Vhost with ID {id} not found");
                }
                _context.Vhosts.Remove(existingvhost);
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
        [Route("/vhosts")]
        [ValidateModelState]
        [SwaggerOperation("VhostsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Vhosts>), description: "OK")]
        public async Task<IActionResult> VhostsGet([FromQuery] PaginationRequestModels queryParams)
        {
            try
            {
                // Start with base query
                var query = _context.Vhosts.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var vhosts = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<Vhosts>
                {
                    Data = vhosts,
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
        [Route("/vhosts")]
        [ValidateModelState]
        [SwaggerOperation("VhostsPatch")]
        public async Task<IActionResult> VhostsPatch([FromBody]Vhosts vhost)
        {
            try
            {
                if (vhost.Id <= 0)
                {
                    return BadRequest("Vhost ID is required");
                }
                var existingvhost = await _context.Vhosts.FindAsync(vhost.Id);
                if (existingvhost == null)
                {
                    return NotFound($"Vhost with ID {vhost.Id} not found");
                }
                existingvhost.Name = vhost.Name;
                existingvhost.Info = vhost.Info;
                existingvhost.Params = vhost.Params;
                existingvhost.Urls = vhost.Urls;
                existingvhost.VhostPorts = vhost.VhostPorts;
                existingvhost.UpdatedAt = DateTime.UtcNow;
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
        [Route("/vhosts")]
        [ValidateModelState]
        [SwaggerOperation("VhostsPost")]
        public async Task<IActionResult> VhostsPost([FromBody]Vhosts vhosts)
        {
            try
            {
                _context.Vhosts.Add(new Vhosts() { 
                    Info = vhosts.Info, Name = vhosts.Name, Params = vhosts.Params,
                    Urls = vhosts.Urls, VhostPorts = vhosts.VhostPorts
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
