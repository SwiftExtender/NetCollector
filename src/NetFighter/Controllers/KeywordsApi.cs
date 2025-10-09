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
    [ApiController]
    [Authorize]
    public class KeywordsApiController : ControllerBase
    {
        [HttpDelete]
        [Route("/keywords")]
        [ValidateModelState]
        [SwaggerOperation("KeywordsDelete")]
        public async Task<IActionResult> KeywordsDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "source")]string source, [FromQuery (Name = "info")]string info, [FromHeader (Name = "Prefer")]string prefer)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/keywords")]
        [ValidateModelState]
        [SwaggerOperation("KeywordsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Keywords>), description: "OK")]
        public async Task<IActionResult> KeywordsGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "source")]string source, [FromQuery (Name = "info")]string info, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"name\" : \"name\",\r\n  \"id\" : 0,\r\n  \"source\" : \"{}\",\r\n  \"info\" : \"info\"\r\n}, {\r\n  \"name\" : \"name\",\r\n  \"id\" : 0,\r\n  \"source\" : \"{}\",\r\n  \"info\" : \"info\"\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Keywords>>(exampleJson)
            : default(List<Keywords>);
            return new ObjectResult(example);
        }
        [HttpPatch]
        [Route("/keywords")]
        [Consumes("application/json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("KeywordsPatch")]
        public async Task<IActionResult> KeywordsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "source")]string source, [FromQuery (Name = "info")]string info, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Keywords keywords)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/keywords")]
        [Consumes("application/json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("KeywordsPost")]
        public async Task<IActionResult> KeywordsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Keywords keywords)
        {

            throw new NotImplementedException();
        }
    }
}
