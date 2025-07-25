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
using System.Threading.Tasks;
using NetFighter.Data;

namespace NetFighter.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Authorize]
    public class DomainsHostsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DomainsHostsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="hostId"></param>
        /// <param name="prefer">Preference</param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("/domains_hosts")]
        [ValidateModelState]
        [SwaggerOperation("DomainsHostsDelete")]
        public async Task<IActionResult> DomainsHostsDelete([FromQuery (Name = "domain_id")]string domainId, [FromQuery (Name = "host_id")]string hostId, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="hostId"></param>
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
        [Route("/domains_hosts")]
        [ValidateModelState]
        [SwaggerOperation("DomainsHostsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<DomainsHosts>), description: "OK")]
        public async Task<IActionResult> DomainsHostsGet([FromQuery (Name = "domain_id")]string domainId, [FromQuery (Name = "host_id")]string hostId, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<DomainsHosts>));
            //TODO: Uncomment the next line to return response 206 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(206);
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"domain_id\" : 0,\r\n  \"host_id\" : 6\r\n}, {\r\n  \"domain_id\" : 0,\r\n  \"host_id\" : 6\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<DomainsHosts>>(exampleJson)
            : default(List<DomainsHosts>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="hostId"></param>
        /// <param name="prefer">Preference</param>
        /// <param name="domainsHosts">domains_hosts</param>
        /// <response code="204">No Content</response>
        [HttpPatch]
        [Route("/domains_hosts")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("DomainsHostsPatch")]
        public async Task<IActionResult> DomainsHostsPatch([FromQuery (Name = "domain_id")]string domainId, [FromQuery (Name = "host_id")]string hostId, [FromHeader (Name = "Prefer")]string prefer, [FromBody]DomainsHosts domainsHosts)
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
        /// <param name="domainsHosts">domains_hosts</param>
        /// <response code="201">Created</response>
        [HttpPost]
        [Route("/domains_hosts")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("DomainsHostsPost")]
        public async Task<IActionResult> DomainsHostsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]DomainsHosts domainsHosts)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            throw new NotImplementedException();
        }
    }
}
