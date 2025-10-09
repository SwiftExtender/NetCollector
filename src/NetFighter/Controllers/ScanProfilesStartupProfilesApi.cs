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
    public class ScanProfilesStartupProfilesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScanProfilesStartupProfilesApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/scan_profiles_startup_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesDelete")]
        public async Task<IActionResult> ScanProfilesStartupProfilesDelete([FromQuery (Name = "scan_profile_id")]string scanProfileId, [FromQuery (Name = "startup_profile_id")]string startupProfileId, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Prefer")]string prefer)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/scan_profiles_startup_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ScanProfilesToolProfiles>), description: "OK")]
        public async Task<IActionResult> ScanProfilesStartupProfilesGet([FromQuery (Name = "scan_profile_id")]string scanProfileId, [FromQuery (Name = "startup_profile_id")]string startupProfileId, [FromQuery (Name = "order")]string order, [FromQuery (Name = "select")]string select, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"scan_profile_id\" : 0,\r\n  \"startup_profile_id\" : 6,\r\n  \"order\" : 1\r\n}, {\r\n  \"scan_profile_id\" : 0,\r\n  \"startup_profile_id\" : 6,\r\n  \"order\" : 1\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<ScanProfilesToolProfiles>>(exampleJson)
            : default(List<ScanProfilesToolProfiles>);
            return new ObjectResult(example);
        }
        [HttpPatch]
        [Route("/scan_profiles_startup_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesPatch")]
        public async Task<IActionResult> ScanProfilesStartupProfilesPatch([FromQuery (Name = "scan_profile_id")]string scanProfileId, [FromQuery (Name = "startup_profile_id")]string startupProfileId, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Prefer")]string prefer, [FromBody] ScanProfilesToolProfiles scanProfilesStartupProfiles)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/scan_profiles_startup_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesPost")]
        public async Task<IActionResult> ScanProfilesStartupProfilesPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody] ScanProfilesToolProfiles scanProfilesStartupProfiles)
        {

            throw new NotImplementedException();
        }
    }
}
