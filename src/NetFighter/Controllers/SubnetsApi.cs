using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class SubnetsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SubnetsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete]
        [Route("/subnets")]
        [ValidateModelState]
        [SwaggerOperation("SubnetsDelete")]
        public async Task<IActionResult> SubnetsDelete([FromQuery (Name = "id")]string id, [FromQuery (Name = "cidr")]string cidr, [FromQuery (Name = "name")]string name, [FromQuery (Name = "description")]string description, [FromHeader (Name = "Prefer")]string prefer)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/subnets")]
        [ValidateModelState]
        [SwaggerOperation("SubnetsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Subnets>), description: "OK")]
        public async Task<IActionResult> SubnetsGet([FromQuery (Name = "id")]string id, [FromQuery (Name = "cidr")]string cidr, [FromQuery (Name = "name")]string name, [FromQuery (Name = "description")]string description, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"name\" : \"name\",\r\n  \"description\" : \"description\",\r\n  \"cidr\" : \"cidr\",\r\n  \"id\" : 0\r\n}, {\r\n  \"name\" : \"name\",\r\n  \"description\" : \"description\",\r\n  \"cidr\" : \"cidr\",\r\n  \"id\" : 0\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Subnets>>(exampleJson)
            : default(List<Subnets>);
            return new ObjectResult(example);
        }
        [HttpPatch]
        [Route("/subnets")]
        [ValidateModelState]
        [SwaggerOperation("SubnetsPatch")]
        public async Task<IActionResult> SubnetsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "cidr")]string cidr, [FromQuery (Name = "name")]string name, [FromQuery (Name = "description")]string description, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Subnets subnets)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/subnets")]
        [ValidateModelState]
        [SwaggerOperation("SubnetsPost")]
        public async Task<IActionResult> SubnetsPost([FromBody]Subnets subnets)
        {
            try
            {
                _context.Subnets.Add(new Subnets() { 
                    Name = subnets.Name,
                    //Hosts = subnets.Hosts,
                    Description = subnets.Description,
                    Cidr = subnets.Cidr
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
