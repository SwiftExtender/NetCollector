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
    public class ToolsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToolsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/tools")]
        [ValidateModelState]
        [SwaggerOperation("ToolsDelete")]
        public async Task<IActionResult> ToolsDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "description")]string description, [FromQuery (Name = "version")]string version, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "updated_at")]string updatedAt, [FromHeader (Name = "Prefer")]string prefer)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/tools")]
        [ValidateModelState]
        [SwaggerOperation("ToolsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Tools>), description: "OK")]
        public async Task<IActionResult> ToolsGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "description")]string description, [FromQuery (Name = "version")]string version, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "updated_at")]string updatedAt, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"updated_at\" : \"now()\",\r\n  \"name\" : \"name\",\r\n  \"description\" : \"description\",\r\n  \"created_at\" : \"now()\",\r\n  \"id\" : 0,\r\n  \"version\" : \"version\"\r\n}, {\r\n  \"updated_at\" : \"now()\",\r\n  \"name\" : \"name\",\r\n  \"description\" : \"description\",\r\n  \"created_at\" : \"now()\",\r\n  \"id\" : 0,\r\n  \"version\" : \"version\"\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Tools>>(exampleJson)
            : default(List<Tools>);
            return new ObjectResult(example);
        }
        [HttpPatch]
        [Route("/tools")]
        [ValidateModelState]
        [SwaggerOperation("ToolsPatch")]
        public async Task<IActionResult> ToolsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "description")]string description, [FromQuery (Name = "version")]string version, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "updated_at")]string updatedAt, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Tools tools)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/tools")]
        [ValidateModelState]
        [SwaggerOperation("ToolsPost")]
        public async Task<IActionResult> ToolsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Tools tools)
        {

            throw new NotImplementedException();
        }
    }
}
