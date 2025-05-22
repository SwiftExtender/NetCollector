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

namespace NetFighter.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class PortsApiController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="hostId"></param>
        /// <param name="info"></param>
        /// <param name="protocol"></param>
        /// <param name="prefer">Preference</param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("/ports")]
        [ValidateModelState]
        [SwaggerOperation("PortsDelete")]
        public async Task<IActionResult> PortsDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "number")]string number, [FromQuery (Name = "host_id")]string hostId, [FromQuery (Name = "info")]string info, [FromQuery (Name = "protocol")]string protocol, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
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
        /// <param name="range">Limiting and Pagination</param>
        /// <param name="rangeUnit">Limiting and Pagination</param>
        /// <param name="offset">Limiting and Pagination</param>
        /// <param name="limit">Limiting and Pagination</param>
        /// <param name="prefer">Preference</param>
        /// <response code="200">OK</response>
        /// <response code="206">Partial Content</response>
        [HttpGet]
        [Route("/ports")]
        [ValidateModelState]
        [SwaggerOperation("PortsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Ports>), description: "OK")]
        public async Task<IActionResult> PortsGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "number")]string number, [FromQuery (Name = "host_id")]string hostId, [FromQuery (Name = "info")]string info, [FromQuery (Name = "protocol")]string protocol, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Ports>));
            //TODO: Uncomment the next line to return response 206 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(206);
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"number\" : 6,\r\n  \"protocol\" : \"protocol\",\r\n  \"id\" : 0,\r\n  \"host_id\" : 1,\r\n  \"info\" : \"info\"\r\n}, {\r\n  \"number\" : 6,\r\n  \"protocol\" : \"protocol\",\r\n  \"id\" : 0,\r\n  \"host_id\" : 1,\r\n  \"info\" : \"info\"\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Ports>>(exampleJson)
            : default(List<Ports>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="hostId"></param>
        /// <param name="info"></param>
        /// <param name="protocol"></param>
        /// <param name="prefer">Preference</param>
        /// <param name="ports">ports</param>
        /// <response code="204">No Content</response>
        [HttpPatch]
        [Route("/ports")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("PortsPatch")]
        public async Task<IActionResult> PortsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "number")]string number, [FromQuery (Name = "host_id")]string hostId, [FromQuery (Name = "info")]string info, [FromQuery (Name = "protocol")]string protocol, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Ports ports)
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
        /// <param name="ports">ports</param>
        /// <response code="201">Created</response>
        [HttpPost]
        [Route("/ports")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("PortsPost")]
        public async Task<IActionResult> PortsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Ports ports)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            throw new NotImplementedException();
        }
    }
}
