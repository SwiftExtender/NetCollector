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

namespace NetFighter.Controllers
{ 
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> HostsDelete([FromBody] string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("Host ID is required");
                }
                Hosts deletedHost = new Hosts() { Id = Int32.Parse(id) };
                _context.Hosts.Remove(deletedHost);
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
        [Route("/hosts")]
        [ValidateModelState]
        [SwaggerOperation("HostsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hosts>), description: "Get all hosts")]
        public async Task<IActionResult> HostsGet()
        {
            try
            {
                var allHosts = await _context.Hosts.ToListAsync();
                return Ok(allHosts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }


        [HttpGet]
        [Route("/hosts/{id}")]
        [ValidateModelState]
        [SwaggerOperation("GetPort")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hosts>), description: "Get host by id")]
        public async Task<IActionResult> GetPort(int id)
        {
            try
            {
                Hosts selectedHost = await _context.Hosts.SingleAsync(p => p.Id == id);
                return Ok(selectedHost);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPatch]
        [Route("/hosts")]
        [Consumes("application/json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("HostsPatch")]
        public async Task<IActionResult> HostsPatch([FromBody] UpdatedHost host)
        {
            try
            {
                Hosts updatedHost = new Hosts() { Id = host.Id };
                _context.Hosts.Update(new Hosts() { Id = host.Id, Ip = host.Ip, Info = host.Info });
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPost]
        [Route("/hosts")]
        [Consumes("application/json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("HostsPost")]
        public async Task<IActionResult> HostsPost([FromBody] CreatedHost host)
        {
            try
            {
                _context.Hosts.Add(new Hosts() { Ip = host.Ip, Info = host.Info });
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
