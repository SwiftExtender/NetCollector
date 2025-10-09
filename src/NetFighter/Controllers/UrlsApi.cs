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
    public class UrlsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UrlsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/urls")]
        [ValidateModelState]
        [SwaggerOperation("UrlsDelete")]
        public async Task<IActionResult> UrlsDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "url")]string url, [FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "info")]string info, [FromHeader (Name = "Prefer")]string prefer)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/urls")]
        [ValidateModelState]
        [SwaggerOperation("UrlsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Urls>), description: "OK")]
        public async Task<IActionResult> UrlsGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "url")]string url, [FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "info")]string info, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"id\" : 0,\r\n  \"vhost_id\" : 6,\r\n  \"url\" : \"url\",\r\n  \"info\" : \"info\"\r\n}, {\r\n  \"id\" : 0,\r\n  \"vhost_id\" : 6,\r\n  \"url\" : \"url\",\r\n  \"info\" : \"info\"\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Urls>>(exampleJson)
            : default(List<Urls>);
            return new ObjectResult(example);
        }
        [HttpPatch]
        [Route("/urls")]
        [ValidateModelState]
        [SwaggerOperation("UrlsPatch")]
        public async Task<IActionResult> UrlsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "url")]string url, [FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "info")]string info, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Urls urls)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/urls")]
        [ValidateModelState]
        [SwaggerOperation("UrlsPost")]
        public async Task<IActionResult> UrlsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Urls urls)
        {

            throw new NotImplementedException();
        }
    }
}
