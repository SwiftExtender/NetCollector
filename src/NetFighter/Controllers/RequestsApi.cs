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
    public class RequestsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RequestsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="urlId"></param>
        /// <param name="createdAt"></param>
        /// <param name="method"></param>
        /// <param name="status"></param>
        /// <param name="response"></param>
        /// <param name="info"></param>
        /// <param name="rawRequest"></param>
        /// <param name="prefer">Preference</param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("/requests")]
        [ValidateModelState]
        [SwaggerOperation("RequestsDelete")]
        public async Task<IActionResult> RequestsDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "url_id")]string urlId, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "method")]string method, [FromQuery (Name = "status")]string status, [FromQuery (Name = "response")]string response, [FromQuery (Name = "info")]string info, [FromQuery (Name = "raw_request")]string rawRequest, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="urlId"></param>
        /// <param name="createdAt"></param>
        /// <param name="method"></param>
        /// <param name="status"></param>
        /// <param name="response"></param>
        /// <param name="info"></param>
        /// <param name="rawRequest"></param>
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
        [Route("/requests")]
        [ValidateModelState]
        [SwaggerOperation("RequestsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Requests>), description: "OK")]
        public async Task<IActionResult> RequestsGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "url_id")]string urlId, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "method")]string method, [FromQuery (Name = "status")]string status, [FromQuery (Name = "response")]string response, [FromQuery (Name = "info")]string info, [FromQuery (Name = "raw_request")]string rawRequest, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Requests>));
            //TODO: Uncomment the next line to return response 206 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(206);
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"raw_request\" : \"raw_request\",\r\n  \"method\" : \"method\",\r\n  \"response\" : \"response\",\r\n  \"created_at\" : \"CURRENT_TIMESTAMP\",\r\n  \"id\" : 0,\r\n  \"url_id\" : 6,\r\n  \"status\" : 1,\r\n  \"info\" : \"info\"\r\n}, {\r\n  \"raw_request\" : \"raw_request\",\r\n  \"method\" : \"method\",\r\n  \"response\" : \"response\",\r\n  \"created_at\" : \"CURRENT_TIMESTAMP\",\r\n  \"id\" : 0,\r\n  \"url_id\" : 6,\r\n  \"status\" : 1,\r\n  \"info\" : \"info\"\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Requests>>(exampleJson)
            : default(List<Requests>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="urlId"></param>
        /// <param name="createdAt"></param>
        /// <param name="method"></param>
        /// <param name="status"></param>
        /// <param name="response"></param>
        /// <param name="info"></param>
        /// <param name="rawRequest"></param>
        /// <param name="prefer">Preference</param>
        /// <param name="requests">requests</param>
        /// <response code="204">No Content</response>
        [HttpPatch]
        [Route("/requests")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("RequestsPatch")]
        public async Task<IActionResult> RequestsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "url_id")]string urlId, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "method")]string method, [FromQuery (Name = "status")]string status, [FromQuery (Name = "response")]string response, [FromQuery (Name = "info")]string info, [FromQuery (Name = "raw_request")]string rawRequest, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Requests requests)
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
        /// <param name="requests">requests</param>
        /// <response code="201">Created</response>
        [HttpPost]
        [Route("/requests")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("RequestsPost")]
        public async Task<IActionResult> RequestsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Requests requests)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            throw new NotImplementedException();
        }
    }
}
