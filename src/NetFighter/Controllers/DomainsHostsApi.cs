using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using NetFighter.Attributes;
using NetFighter.Models;
using System.Threading.Tasks;
using NetFighter.Data;

namespace NetFighter.Controllers
{
    [ApiController]
    //[Authorize]
    public class DomainsHostsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DomainsHostsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpDelete]
        //[Route("/domainshosts/{id}")]
        //[ValidateModelState]
        //[SwaggerOperation("DomainsHostsDelete")]
        //public async Task<IActionResult> DomainsHostsDelete([FromQuery (Name = "id")]int id)
        //{
        //    try
        //    {
        //        if (id <= 0)
        //        {
        //            return BadRequest("DomainsHosts ID is required");
        //        }
        //        var domain = await _context.DomainsHosts.FindAsync(id);
        //        _context.DomainsHosts.Remove(domain);
        //        await _context.SaveChangesAsync();
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(500, new { ex.Message });
        //    }
        //}
        [HttpGet]
        [Route("/domainshosts")]
        [ValidateModelState]
        [SwaggerOperation("DomainsHostsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<DomainsHosts>), description: "OK")]
        public async Task<IActionResult> DomainsHostsGet([FromQuery (Name = "domain_id")]string domainId, [FromQuery (Name = "host_id")]string hostId, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit, [FromHeader (Name = "Prefer")]string prefer)
        {
            string exampleJson = null;
            exampleJson = "[ {\r\n  \"domain_id\" : 0,\r\n  \"host_id\" : 6\r\n}, {\r\n  \"domain_id\" : 0,\r\n  \"host_id\" : 6\r\n} ]";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<DomainsHosts>>(exampleJson)
            : default(List<DomainsHosts>);
            return new ObjectResult(example);
        }
        [HttpPatch]
        [Route("/domainshosts")]
        [ValidateModelState]
        [SwaggerOperation("DomainsHostsPatch")]
        public async Task<IActionResult> DomainsHostsPatch([FromQuery (Name = "domain_id")]string domainId, [FromQuery (Name = "host_id")]string hostId, [FromHeader (Name = "Prefer")]string prefer, [FromBody]DomainsHosts domainsHosts)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/domainshosts")]
        [ValidateModelState]
        [SwaggerOperation("DomainsHostsPost")]
        public async Task<IActionResult> DomainsHostsPost([FromQuery (Name = "select")]string select, [FromHeader (Name = "Prefer")]string prefer, [FromBody]DomainsHosts domainsHosts)
        {

            throw new NotImplementedException();
        }
    }
}
