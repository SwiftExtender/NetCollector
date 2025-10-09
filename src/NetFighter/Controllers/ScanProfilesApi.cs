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
    public class ScanProfilesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScanProfilesApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/scan_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesDelete")]
        public async Task<IActionResult> ScanProfilesDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "description")]string description, [FromQuery (Name = "created_at")]string createdAt, [FromHeader (Name = "Prefer")]string prefer)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/scan_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ScanProfiles>), description: "OK")]
        public async Task<IActionResult> ScanProfilesGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "description")]string description, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"name\" : \"name\",\r\n  \"description\" : \"description\",\r\n  \"created_at\" : \"CURRENT_TIMESTAMP\",\r\n  \"id\" : 0\r\n}, {\r\n  \"name\" : \"name\",\r\n  \"description\" : \"description\",\r\n  \"created_at\" : \"CURRENT_TIMESTAMP\",\r\n  \"id\" : 0\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<ScanProfiles>>(exampleJson)
            : default(List<ScanProfiles>);
            return new ObjectResult(example);
        }
        [HttpPatch]
        [Route("/scan_profiles")]
        [Consumes("application/json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesPatch")]
        public async Task<IActionResult> ScanProfilesPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "description")]string description, [FromQuery (Name = "created_at")]string createdAt, [FromHeader (Name = "Prefer")]string prefer, [FromBody]ScanProfiles scanProfiles)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/scan_profiles")]
        [Consumes("application/json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesPost")]
        public async Task<IActionResult> ScanProfilesPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]ScanProfiles scanProfiles)
        {

            throw new NotImplementedException();
        }
    }
}
