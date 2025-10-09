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
using NetFighter.Data;

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
        public async Task<IActionResult> VhostPortsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]VhostsPorts vhostPorts)
        {

            throw new NotImplementedException();
        }
    }
}
