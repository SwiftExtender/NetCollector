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
using System.Threading.Tasks;

namespace NetFighter.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class HostsApiController : ControllerBase
    { 
        private readonly ApplicationDbContext _context;

        public HostsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ip"></param>
        /// <param name="info"></param>
        /// <param name="subnetId"></param>
        /// <param name="prefer">Preference</param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("/hosts")]
        [ValidateModelState]
        [SwaggerOperation("HostsDelete")]
        public async Task<IActionResult> HostsDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "ip")]string ip, [FromQuery (Name = "info")]string info, [FromQuery (Name = "subnet_id")]string subnetId, [FromHeader (Name = "Prefer")]string prefer)
        {
            try
            {
                var deletedHost = _context.Hosts.Remove(id);
                await _context.SaveChangesAsync();
                return StatusCode(204);
            }
            catch (Exception ex) {
                return StatusCode(500);
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ip"></param>
        /// <param name="info"></param>
        /// <param name="subnetId"></param>
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
        [Route("/hosts")]
        [ValidateModelState]
        [SwaggerOperation("HostsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hosts>), description: "OK")]
        public async Task<IActionResult> HostsGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "ip")]string ip, [FromQuery (Name = "info")]string info, [FromQuery (Name = "subnet_id")]string subnetId, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {

            string exampleJson = null;
            exampleJson = "[ {\r\n  \"ip\" : \"ip\",\r\n  \"subnet_id\" : 6,\r\n  \"id\" : 0,\r\n  \"info\" : \"info\"\r\n}, {\r\n  \"ip\" : \"ip\",\r\n  \"subnet_id\" : 6,\r\n  \"id\" : 0,\r\n  \"info\" : \"info\"\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Hosts>>(exampleJson)
            : default(List<Hosts>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ip"></param>
        /// <param name="info"></param>
        /// <param name="subnetId"></param>
        /// <param name="prefer">Preference</param>
        /// <param name="hosts">hosts</param>
        /// <response code="204">No Content</response>
        [HttpPatch]
        [Route("/hosts")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("HostsPatch")]
        public async Task<IActionResult> HostsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "ip")]string ip, [FromQuery (Name = "info")]string info, [FromQuery (Name = "subnet_id")]string subnetId, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Hosts hosts)
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
        /// <param name="hosts">hosts</param>
        /// <response code="201">Created</response>
        [HttpPost]
        [Route("/hosts")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("HostsPost")]
        public async Task<IActionResult> HostsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Hosts hosts)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            throw new NotImplementedException();
        }
    }
}
