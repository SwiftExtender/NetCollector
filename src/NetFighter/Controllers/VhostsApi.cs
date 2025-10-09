using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetFighter.Attributes;
using NetFighter.Data;
using NetFighter.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

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
        [Route("/vhosts/{id}")]
        [ValidateModelState]
        [SwaggerOperation("VhostsDelete")]
        public async Task<IActionResult> VhostsDelete([From] Vhosts vhosts)
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
        public async Task<IActionResult> VhostsPost([FromBody]Vhosts vhosts)
        {
            try
            {
                _context.Vhosts.Add(new Vhosts() { 
                    Info = vhosts.Info, Name = vhosts.Name//, Params = vhosts.Params,
                    //Urls = vhosts.Urls, VhostPorts = vhosts.VhostPorts
                });
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }
    }
}
