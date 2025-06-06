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
    [Authorize]
    public class KeywordsApiController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="info"></param>
        /// <param name="prefer">Preference</param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("/keywords")]
        [ValidateModelState]
        [SwaggerOperation("KeywordsDelete")]
        public async Task<IActionResult> KeywordsDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "source")]string source, [FromQuery (Name = "info")]string info, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="source"></param>
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
        [Route("/keywords")]
        [ValidateModelState]
        [SwaggerOperation("KeywordsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Keywords>), description: "OK")]
        public async Task<IActionResult> KeywordsGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "source")]string source, [FromQuery (Name = "info")]string info, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Keywords>));
            //TODO: Uncomment the next line to return response 206 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(206);
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"name\" : \"name\",\r\n  \"id\" : 0,\r\n  \"source\" : \"{}\",\r\n  \"info\" : \"info\"\r\n}, {\r\n  \"name\" : \"name\",\r\n  \"id\" : 0,\r\n  \"source\" : \"{}\",\r\n  \"info\" : \"info\"\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Keywords>>(exampleJson)
            : default(List<Keywords>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="source"></param>
        /// <param name="info"></param>
        /// <param name="prefer">Preference</param>
        /// <param name="keywords">keywords</param>
        /// <response code="204">No Content</response>
        [HttpPatch]
        [Route("/keywords")]
        [Consumes("application/json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("KeywordsPatch")]
        public async Task<IActionResult> KeywordsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "source")]string source, [FromQuery (Name = "info")]string info, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Keywords keywords)
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
        /// <param name="keywords">keywords</param>
        /// <response code="201">Created</response>
        [HttpPost]
        [Route("/keywords")]
        [Consumes("application/json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("KeywordsPost")]
        public async Task<IActionResult> KeywordsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Keywords keywords)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            throw new NotImplementedException();
        }
    }
}
