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
    public class UrlsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UrlsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <param name="vhostId"></param>
        /// <param name="info"></param>
        /// <param name="prefer">Preference</param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("/urls")]
        [ValidateModelState]
        [SwaggerOperation("UrlsDelete")]
        public async Task<IActionResult> UrlsDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "url")]string url, [FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "info")]string info, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <param name="vhostId"></param>
        /// <param name="info"></param>
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
        [Route("/urls")]
        [ValidateModelState]
        [SwaggerOperation("UrlsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Urls>), description: "OK")]
        public async Task<IActionResult> UrlsGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "url")]string url, [FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "info")]string info, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Urls>));
            //TODO: Uncomment the next line to return response 206 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(206);
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"id\" : 0,\r\n  \"vhost_id\" : 6,\r\n  \"url\" : \"url\",\r\n  \"info\" : \"info\"\r\n}, {\r\n  \"id\" : 0,\r\n  \"vhost_id\" : 6,\r\n  \"url\" : \"url\",\r\n  \"info\" : \"info\"\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Urls>>(exampleJson)
            : default(List<Urls>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <param name="vhostId"></param>
        /// <param name="info"></param>
        /// <param name="prefer">Preference</param>
        /// <param name="urls">urls</param>
        /// <response code="204">No Content</response>
        [HttpPatch]
        [Route("/urls")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("UrlsPatch")]
        public async Task<IActionResult> UrlsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "url")]string url, [FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "info")]string info, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Urls urls)
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
        /// <param name="urls">urls</param>
        /// <response code="201">Created</response>
        [HttpPost]
        [Route("/urls")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("UrlsPost")]
        public async Task<IActionResult> UrlsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Urls urls)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            throw new NotImplementedException();
        }
    }
}
