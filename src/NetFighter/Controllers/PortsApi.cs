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
            {
                try
                {
                    if (id <= 0)
                    {
                        return BadRequest("Port ID is required");
                    }
                    var existingport = await _context.Ports.FindAsync(id);
                    if (existingport == null)
                    {
                        return NotFound($"Port with ID {id} not found");
                    }
                    _context.Ports.Remove(existingport);
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
        public async Task<IActionResult> PortsPatch([FromBody] Ports port)
        {
            try
            {
                if (port.Id <= 0)
                {
                    return BadRequest("Port ID is required");
                }
                var existingport = await _context.Ports.FindAsync(port.Id);
                if (existingport == null)
                {
                    return NotFound($"Port with ID {port.Id} not found");
                }
                existingport.Number = port.Number;
                existingport.Protocol  = port.Protocol;
                existingport.Info  = port.Info;
                existingport.UpdatedAt = DateTime.UtcNow;
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
        [Route("/ports")]
        [ValidateModelState]
        [SwaggerOperation("AddPorts")]
        public async Task<IActionResult> PortsPost([FromBody] Ports port)
        {
            try
            {
                Ports createdPort = new Ports() { HostId = port.HostId, Number = port.Number, Info = port.Info, Protocol = port.Protocol, CreatedAt = DateTime.UtcNow };
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
