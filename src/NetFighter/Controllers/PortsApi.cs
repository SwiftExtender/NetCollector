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

namespace NetFighter.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class PortsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("/ports")]
        [ValidateModelState]
        [SwaggerOperation("PortsDelete")]
        public async Task<IActionResult> PortsDelete([FromQuery (Name = "id")]string id)
        {
            try
            {
                Ports deletedPort = new Ports() { Id = Int32.Parse(id) };
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
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="hostId"></param>
        /// <param name="info"></param>
        /// <param name="protocol"></param>
        /// <param name="select">Filtering Columns</param>
        /// <param name="order">Ordering</param>
        /// <param name="offset">Limiting and Pagination</param>
        /// <param name="limit">Limiting and Pagination</param>
        /// <response code="200">OK</response>
        /// <response code="206">Partial Content</response>
        [HttpGet]
        [Route("/host/{hostId}/ports")]
        [ValidateModelState]
        [SwaggerOperation("GetHostPorts")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Ports>), description: "OK")]
        public async Task<IActionResult> GetHostPorts(string hostId, [FromQuery (Name = "id")]int id, [FromQuery (Name = "number")]string number, [FromQuery (Name = "info")]string info, [FromQuery (Name = "protocol")]string protocol, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit)
        {
            try
            {
                Ports selectedPort = new Ports() { Id = id };
                return StatusCode(200);
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
                Ports selectedPort = new Ports() { Id = id };
                
                return StatusCode(200);
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
        [SwaggerOperation("PortsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Ports>), description: "OK")]
        public async Task<IActionResult> PortsGet([FromQuery(Name = "id")] int id, [FromQuery(Name = "number")] string number, [FromQuery(Name = "host_id")] string hostId, [FromQuery(Name = "info")] string info, [FromQuery(Name = "protocol")] string protocol, [FromQuery(Name = "select")] string select, [FromQuery(Name = "order")] string order, [FromHeader(Name = "Range")] string range, [FromQuery(Name = "offset")] string offset, [FromQuery(Name = "limit")] string limit, [FromHeader(Name = "Prefer")] string prefer)
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
        [SwaggerOperation("PortsPatch")]
        public async Task<IActionResult> PortsPatch([FromQuery (Name = "id")]int id, [FromQuery (Name = "number")]int number, [FromQuery (Name = "info")]string info, [FromQuery (Name = "protocol")]string protocol)
        {
            try
            {
                Ports changedPort = new Ports() { Id = id, Number = number, Protocol = protocol, Info = info};
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
        [SwaggerOperation("PortsPost")]
        public async Task<IActionResult> PortsPost([FromQuery(Name = "number")] int number, [FromQuery(Name = "host_id")] int hostId, [FromQuery(Name = "info")] string info, [FromQuery(Name = "protocol")] string protocol)
        {
            try
            {
                Ports createdPort = new Ports() { HostId = hostId, Number = number, Info = info, Protocol = protocol };
                _context.Ports.Add(createdPort);
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
