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
    public class SubnetsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SubnetsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete]
        [Route("/subnets/{id}")]
        [ValidateModelState]
        [SwaggerOperation("SubnetsDelete")]
        public async Task<IActionResult> SubnetsDelete(int id)
        {
                try
                {
                    if (id <= 0)
                    {
                        return BadRequest("Subnet ID is required");
                    }
                    var existingsubnet = await _context.Subnets.FindAsync(id);
                    if (existingsubnet == null)
                    {
                        return NotFound($"Subnet with ID {id} not found");
                    }
                    _context.Subnets.Remove(existingsubnet);
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
        [Route("/subnets")]
        [ValidateModelState]
        [SwaggerOperation("SubnetsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Subnets>), description: "OK")]
        public async Task<IActionResult> SubnetsGet([FromQuery] PaginationRequestModels queryParams) {
            try
            {
                // Start with base query
                var query = _context.Subnets.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var subnets = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<Subnets>
                {
                    Data = subnets,
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
        [Route("/subnets")]
        [ValidateModelState]
        [SwaggerOperation("SubnetsPatch")]
        public async Task<IActionResult> SubnetsPatch([FromBody]Subnets subnet)
        {
            try
            {
                if (subnet.Id <= 0)
                {
                    return BadRequest("Subnet ID is required");
                }
                var existingsubnet = await _context.Subnets.FindAsync(subnet.Id);
                if (existingsubnet == null)
                {
                    return NotFound($"Subnet with ID {subnet.Id} not found");
                }
                existingsubnet.Name = subnet.Name;
                existingsubnet.Cidr = subnet.Cidr;
                existingsubnet.Hosts = subnet.Hosts;
                existingsubnet.Description = subnet.Description;
                existingsubnet.UpdatedAt = DateTime.UtcNow;
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
        [Route("/subnets")]
        [ValidateModelState]
        [SwaggerOperation("SubnetsPost")]
        public async Task<IActionResult> SubnetsPost([FromBody]Subnets subnets)
        {
            try
            {
                _context.Subnets.Add(new Subnets() { 
                    Name = subnets.Name,
                    //Hosts = subnets.Hosts,
                    Description = subnets.Description,
                    Cidr = subnets.Cidr
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
