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
    ////[Authorize]
    public class PortsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PortsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/ports/{id}")]
        [ValidateModelState]
        [SwaggerOperation("PortsDelete")]
        public async Task<IActionResult> PortsDelete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Port ID is required");
                }
                var host = await _context.Hosts.FindAsync(id);
                _context.Hosts.Remove(host);
                await _context.SaveChangesAsync();
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }
        [HttpGet]
        [Route("/host/{id}/ports")]
        [ValidateModelState]
        [SwaggerOperation("GetHostPorts")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Ports>), description: "OK")]
        public async Task<IActionResult> GetHostPorts(int id)
        {
            return StatusCode(200);
            //try
            //{
            //    // Start with base query
            //    var query = _context.Ports.AsQueryable();

            //    // Get total count for pagination metadata
            //    var totalCount = await query.CountAsync();

            //    // Apply pagination
            //    var ports = await query
            //        .OrderBy(h => h.Id)
            //        .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
            //        .Take(queryParams.PageSize)
            //        .ToListAsync();

            //    // Create response with pagination metadata
            //    var response = new PagedResponse<Ports>
            //    {
            //        Data = ports,
            //        PageNumber = queryParams.PageNumber,
            //        PageSize = queryParams.PageSize,
            //        TotalCount = totalCount,
            //        TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.PageSize)
            //    };

            //    return Ok(response);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return StatusCode(500, new { ex.Message });
            //}
        }

        [HttpGet]
        [Route("/ports/{id}")]
        [ValidateModelState]
        [SwaggerOperation("GetPort")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Ports>), description: "OK")]
        public async Task<IActionResult> GetPort(int id)
        {
            try
            {
                Ports selectedPort = await _context.Ports.SingleAsync(p => p.Id == id);
                return Ok(selectedPort);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpGet]
        [Route("/ports")]
        [ValidateModelState]
        [SwaggerOperation("GetAllPorts")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Ports>), description: "OK")]
        public async Task<IActionResult> PortsGet()
        {
            try
            {
                List<Ports> allPorts = await _context.Ports.ToListAsync();
                return Ok(allPorts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }
        [HttpPatch]
        [Route("/ports")]
        [ValidateModelState]
        [SwaggerOperation("PatchPorts")]
        public async Task<IActionResult> PortsPatch([FromBody] UpdatedPort port)
        {
            try
            {
                Ports changedPort = new Ports() { Id = port.Id, HostId = port.HostId, Number = port.Number, Protocol = port.Protocol, Info = port.Info};
                _context.Ports.Update(changedPort);
                await _context.SaveChangesAsync();
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }
        [HttpPost]
        [Route("/ports")]
        [ValidateModelState]
        [SwaggerOperation("AddPorts")]
        public async Task<IActionResult> PortsPost([FromBody] CreatedPort port)
        {
            try
            {
                Ports createdPort = new Ports() { HostId = port.HostId, Number = port.Number, Info = port.Info, Protocol = port.Protocol };
                _context.Ports.Add(createdPort);
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.InnerException });
            }
        }
    }
}
