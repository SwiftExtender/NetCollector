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
    public class VhostPortsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VhostPortsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/vhost_ports/{id}")]
        [SwaggerOperation("VhostPortsDelete")]
        public async Task<IActionResult> VhostPortsDelete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("VhostPorts ID is required");
                }
                var existingVhostPorts = await _context.VhostsPorts.FindAsync(id);
                if (existingVhostPorts == null)
                {
                    return NotFound($"VhostPorts with ID {id} not found");
                }
                _context.VhostsPorts.Remove(existingVhostPorts);
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
        [Route("/vhost_ports")]
        [ValidateModelState]
        [SwaggerOperation("VhostPortsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<VhostsPorts>), description: "OK")]
        public async Task<IActionResult> VhostPortsGet([FromQuery] PaginationRequestModels queryParams)
        {
            try
            {
                // Start with base query
                var query = _context.VhostsPorts.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var vhostsPorts = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<VhostsPorts>
                {
                    Data = vhostsPorts,
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
        [Route("/vhost_ports")]
        [ValidateModelState]
        [SwaggerOperation("VhostPortsPatch")]
        public async Task<IActionResult> VhostPortsPatch([FromBody]VhostsPorts vhostPort)
        {
            try
            {
                if (vhostPort.Id <= 0)
                {
                    return BadRequest("ToolProfile ID is required");
                }
                var existingvhostPort = await _context.VhostsPorts.FindAsync(vhostPort.Id);
                if (existingvhostPort == null)
                {
                    return NotFound($"ToolProfile with ID {vhostPort.Id} not found");
                }
                existingvhostPort.PortId = vhostPort.PortId;
                existingvhostPort.Ports = vhostPort.Ports;
                existingvhostPort.VhostId = vhostPort.VhostId;
                existingvhostPort.Vhosts = vhostPort.Vhosts;
                existingvhostPort.UpdatedAt = DateTime.UtcNow;
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
        [Route("/vhost_ports")]
        [ValidateModelState]
        [SwaggerOperation("VhostPortsPost")]
        public async Task<IActionResult> VhostPortsPost([FromBody]VhostsPorts vhostPorts)
        {
            try
            {
                _context.VhostsPorts.Add(new VhostsPorts() { 
                    PortId = vhostPorts.PortId, 
                    VhostId = vhostPorts.VhostId, 
                    Ports = vhostPorts.Ports,
                    Vhosts = vhostPorts.Vhosts
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
