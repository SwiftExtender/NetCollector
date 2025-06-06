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
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Authorize]
    public class VhostPortsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VhostPortsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vhostId"></param>
        /// <param name="portId"></param>
        /// <param name="prefer">Preference</param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("/vhost_ports")]
        [ValidateModelState]
        [SwaggerOperation("VhostPortsDelete")]
        public async Task<IActionResult> VhostPortsDelete([FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "port_id")]string portId, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vhostId"></param>
        /// <param name="portId"></param>
        /// <param name="select">Filtering Columns</param>
        /// <param name="order">Ordering</param>
        /// <param name="range">Limiting and Pagination</param>
        /// <param name="rangeUnit">Limiting and Pagination</param>
        /// <param name="offset">Limiting and Pagination</param>
        /// <param name="limit">Limiting and Pagination</param>
        /// <param name="prefer">Preference</param>
        /// <response code="200">OK</response>
        /// <response code="206">Partial Content</response>
        [HttpGet]
        [Route("/vhost_ports")]
        [ValidateModelState]
        [SwaggerOperation("VhostPortsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<VhostsPorts>), description: "OK")]
        public async Task<IActionResult> VhostPortsGet([FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "port_id")]string portId, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<VhostPorts>));
            //TODO: Uncomment the next line to return response 206 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(206);
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"port_id\" : 6,\r\n  \"vhost_id\" : 0\r\n}, {\r\n  \"port_id\" : 6,\r\n  \"vhost_id\" : 0\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<VhostsPorts>>(exampleJson)
            : default(List<VhostsPorts>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vhostId"></param>
        /// <param name="portId"></param>
        /// <param name="prefer">Preference</param>
        /// <param name="vhostPorts">vhost_ports</param>
        /// <response code="204">No Content</response>
        [HttpPatch]
        [Route("/vhost_ports")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("VhostPortsPatch")]
        public async Task<IActionResult> VhostPortsPatch([FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "port_id")]string portId, [FromHeader (Name = "Prefer")]string prefer, [FromBody]VhostsPorts vhostPorts)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="select">Filtering Columns</param>
        /// <param name="prefer">Preference</param>
        /// <param name="vhostPorts">vhost_ports</param>
        /// <response code="201">Created</response>
        [HttpPost]
        [Route("/vhost_ports")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("VhostPortsPost")]
        public async Task<IActionResult> VhostPortsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]VhostsPorts vhostPorts)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            throw new NotImplementedException();
        }
    }
}
