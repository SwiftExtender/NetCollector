using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using NetFighter.Attributes;
using NetFighter.Models;
using Microsoft.EntityFrameworkCore;
using NetFighter.Data;
using System.Linq;
using NetFighter.RequestModels;

namespace NetFighter.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class PortsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PortsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("/ports")]
        [ValidateModelState]
        [SwaggerOperation("PortsDelete")]
        public async Task<IActionResult> PortsDelete([FromBody] int id)
        {
            try
            {
                Ports deletedPort = new Ports() { Id = id };
                _context.Ports.Remove(deletedPort);
                await _context.SaveChangesAsync();
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostId"></param>
        /// <response code="200">OK</response>
        /// <response code="206">Partial Content</response>
        [HttpGet]
        [Route("/host/{hostId}/ports")]
        [ValidateModelState]
        [SwaggerOperation("GetHostPorts")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Ports>), description: "OK")]
        public async Task<IActionResult> GetHostPorts(int hostId)
        {
            try
            {
                var selectedPort = await _context.Ports.Where(p => p.HostId.Equals(hostId)).ToListAsync();
                return Ok(selectedPort);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
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
        public async Task<IActionResult> PortsGet() //[FromQuery(Name = "offset")] string offset, [FromQuery(Name = "limit")] string limit
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="hostId"></param>
        /// <param name="info"></param>
        /// <param name="protocol"></param>
        /// <response code="204">No Content</response>
        [HttpPatch]
        [Route("/ports")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
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

        /// <summary>
        /// 
        /// </summary>
        /// <response code="201">Created</response>
        [HttpPost]
        [Route("/ports")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
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
