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
    public class ToolProfilesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToolProfilesApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/tool_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ToolProfilesDelete")]
        public async Task<IActionResult> StartupProfilesDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "tool_id")]string toolId, [FromQuery (Name = "name")]string name, [FromQuery (Name = "configuration")]string configuration, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "updated_at")]string updatedAt, [FromHeader (Name = "Prefer")]string prefer)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/tool_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ToolProfilesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ToolProfiles>), description: "OK")]
        public async Task<IActionResult> StartupProfilesGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "tool_id")]string toolId, [FromQuery (Name = "name")]string name, [FromQuery (Name = "configuration")]string configuration, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "updated_at")]string updatedAt, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"updated_at\" : \"now()\",\r\n  \"configuration\" : \"{}\",\r\n  \"name\" : \"name\",\r\n  \"tool_id\" : 6,\r\n  \"created_at\" : \"now()\",\r\n  \"id\" : 0\r\n}, {\r\n  \"updated_at\" : \"now()\",\r\n  \"configuration\" : \"{}\",\r\n  \"name\" : \"name\",\r\n  \"tool_id\" : 6,\r\n  \"created_at\" : \"now()\",\r\n  \"id\" : 0\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<ToolProfiles>>(exampleJson)
            : default(List<ToolProfiles>);
            return new ObjectResult(example);
        }
        [HttpPatch]
        [Route("/tool_profiles")]
        [Consumes("application/json","text/csv")]
        [ValidateModelState]
        [SwaggerOperation("ToolProfilesPatch")]
        public async Task<IActionResult> StartupProfilesPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "tool_id")]string toolId, [FromQuery (Name = "name")]string name, [FromQuery (Name = "configuration")]string configuration, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "updated_at")]string updatedAt, [FromHeader (Name = "Prefer")]string prefer, [FromBody]ToolProfiles startupProfiles)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/tool_profiles")]
        [Consumes("application/json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("ToolProfilesPost")]
        public async Task<IActionResult> StartupProfilesPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]ToolProfiles startupProfiles)
        {

            throw new NotImplementedException();
        }
    }
}
