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
    public class ScanProfilesStartupProfilesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScanProfilesStartupProfilesApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scanProfileId"></param>
        /// <param name="startupProfileId"></param>
        /// <param name="order"></param>
        /// <param name="prefer">Preference</param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("/scan_profiles_startup_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesDelete")]
        public async Task<IActionResult> ScanProfilesStartupProfilesDelete([FromQuery (Name = "scan_profile_id")]string scanProfileId, [FromQuery (Name = "startup_profile_id")]string startupProfileId, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scanProfileId"></param>
        /// <param name="startupProfileId"></param>
        /// <param name="order">Ordering</param>
        /// <param name="select">Filtering Columns</param>
        /// <param name="range">Limiting and Pagination</param>
        /// <param name="rangeUnit">Limiting and Pagination</param>
        /// <param name="offset">Limiting and Pagination</param>
        /// <param name="limit">Limiting and Pagination</param>
        /// <param name="prefer">Preference</param>
        /// <response code="200">OK</response>
        /// <response code="206">Partial Content</response>
        [HttpGet]
        [Route("/scan_profiles_startup_profiles")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ScanProfilesToolProfiles>), description: "OK")]
        public async Task<IActionResult> ScanProfilesStartupProfilesGet([FromQuery (Name = "scan_profile_id")]string scanProfileId, [FromQuery (Name = "startup_profile_id")]string startupProfileId, [FromQuery (Name = "order")]string order, [FromQuery (Name = "select")]string select, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<ScanProfilesStartupProfiles>));
            //TODO: Uncomment the next line to return response 206 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(206);
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"scan_profile_id\" : 0,\r\n  \"startup_profile_id\" : 6,\r\n  \"order\" : 1\r\n}, {\r\n  \"scan_profile_id\" : 0,\r\n  \"startup_profile_id\" : 6,\r\n  \"order\" : 1\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<ScanProfilesToolProfiles>>(exampleJson)
            : default(List<ScanProfilesToolProfiles>);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scanProfileId"></param>
        /// <param name="startupProfileId"></param>
        /// <param name="order"></param>
        /// <param name="prefer">Preference</param>
        /// <param name="scanProfilesStartupProfiles">scan_profiles_startup_profiles</param>
        /// <response code="204">No Content</response>
        [HttpPatch]
        [Route("/scan_profiles_startup_profiles")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesPatch")]
        public async Task<IActionResult> ScanProfilesStartupProfilesPatch([FromQuery (Name = "scan_profile_id")]string scanProfileId, [FromQuery (Name = "startup_profile_id")]string startupProfileId, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Prefer")]string prefer, [FromBody] ScanProfilesToolProfiles scanProfilesStartupProfiles)
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
        /// <param name="scanProfilesStartupProfiles">scan_profiles_startup_profiles</param>
        /// <response code="201">Created</response>
        [HttpPost]
        [Route("/scan_profiles_startup_profiles")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("ScanProfilesStartupProfilesPost")]
        public async Task<IActionResult> ScanProfilesStartupProfilesPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody] ScanProfilesToolProfiles scanProfilesStartupProfiles)
        {

            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            throw new NotImplementedException();
        }
    }
}
