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
    public class ParamsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParamsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/params")]
        [ValidateModelState]
        [SwaggerOperation("ParamsDelete")]
        public async Task<IActionResult> ParamsDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "value")]string value, [FromQuery (Name = "vhost_id")]string vhostId, [FromHeader (Name = "Prefer")]string prefer)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/params")]
        [ValidateModelState]
        [SwaggerOperation("ParamsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Params>), description: "OK")]
        public async Task<IActionResult> ParamsGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "value")]string value, [FromQuery (Name = "vhost_id")]string vhostId, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"name\" : \"name\",\r\n  \"id\" : 0,\r\n  \"vhost_id\" : 6,\r\n  \"value\" : \"value\"\r\n}, {\r\n  \"name\" : \"name\",\r\n  \"id\" : 0,\r\n  \"vhost_id\" : 6,\r\n  \"value\" : \"value\"\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Params>>(exampleJson)
            : default(List<Params>);
            return new ObjectResult(example);
        }
        [HttpPatch]
        [Route("/params")]
        [Consumes("application/json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("ParamsPatch")]
        public async Task<IActionResult> ParamsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "value")]string value, [FromQuery (Name = "vhost_id")]string vhostId, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Params varParams)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/params")]
        [Consumes("application/json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("ParamsPost")]
        public async Task<IActionResult> ParamsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Params varParams)
        {

            throw new NotImplementedException();
        }
    }
}
