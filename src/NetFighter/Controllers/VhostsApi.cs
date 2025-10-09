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
    public class VhostsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VhostsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/vhosts")]
        [ValidateModelState]
        [SwaggerOperation("VhostsDelete")]
        public async Task<IActionResult> VhostsDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "info")]string info, [FromHeader (Name = "Prefer")]string prefer)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/vhosts")]
        [ValidateModelState]
        [SwaggerOperation("VhostsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Vhosts>), description: "OK")]
        public async Task<IActionResult> VhostsGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "info")]string info, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"name\" : \"name\",\r\n  \"id\" : 0,\r\n  \"info\" : \"info\"\r\n}, {\r\n  \"name\" : \"name\",\r\n  \"id\" : 0,\r\n  \"info\" : \"info\"\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Vhosts>>(exampleJson)
            : default(List<Vhosts>);
            return new ObjectResult(example);
        }
        [HttpPatch]
        [Route("/vhosts")]
                [ValidateModelState]
        [SwaggerOperation("VhostsPatch")]
        public async Task<IActionResult> VhostsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "info")]string info, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Vhosts vhosts)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/vhosts")]
                [ValidateModelState]
        [SwaggerOperation("VhostsPost")]
        public async Task<IActionResult> VhostsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Vhosts vhosts)
        {

            throw new NotImplementedException();
        }
    }
}
