using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetFighter.Attributes;
using NetFighter.Data;
using NetFighter.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace NetFighter.Controllers
{
    [ApiController]
    [Authorize]
    public class VhostPortsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VhostPortsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/vhost_ports")]
        [ValidateModelState]
        [SwaggerOperation("VhostPortsDelete")]
        public async Task<IActionResult> VhostPortsDelete([FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "port_id")]string portId, [FromHeader (Name = "Prefer")]string prefer)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/vhost_ports")]
        [ValidateModelState]
        [SwaggerOperation("VhostPortsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<VhostsPorts>), description: "OK")]
        public async Task<IActionResult> VhostPortsGet([FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "port_id")]string portId, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"port_id\" : 6,\r\n  \"vhost_id\" : 0\r\n}, {\r\n  \"port_id\" : 6,\r\n  \"vhost_id\" : 0\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<VhostsPorts>>(exampleJson)
            : default(List<VhostsPorts>);
            return new ObjectResult(example);
        }
        [HttpPatch]
        [Route("/vhost_ports")]
        [ValidateModelState]
        [SwaggerOperation("VhostPortsPatch")]
        public async Task<IActionResult> VhostPortsPatch([FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "port_id")]string portId, [FromHeader (Name = "Prefer")]string prefer, [FromBody]VhostsPorts vhostPorts)
        {

            throw new NotImplementedException();
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
                    //Ports = vhostPorts.Ports,
                    //Vhosts = vhostPorts.Vhosts
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
