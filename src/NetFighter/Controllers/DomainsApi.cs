using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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

namespace NetFighter.Controllers
{
    [ApiController]
    //[Authorize]
    public class DomainsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DomainsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpDelete]
        //[Route("domains/{id}")]
        //[ValidateModelState]
        //[SwaggerOperation("DomainsDelete")]
        //public async Task<IActionResult> DomainsDelete([FromQuery] int id)
        //{
        //    try
        //    {
        //        if (id <= 0)
        //        {
        //            return BadRequest("Domain ID is required");
        //        }
        //        var domain = await _context.Domains.FindAsync(id);
        //        _context.Domains.Remove(domain);
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
        [Route("domains")]
        [ValidateModelState]
        [SwaggerOperation("DomainsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Domains>))]
        public async Task<IActionResult> DomainsGet()
        {
            var allHosts = await _context.Domains.ToListAsync();
            return Ok(allHosts);
        }
        [HttpPatch]
        [Route("domains")]
        [ValidateModelState]
        [SwaggerOperation("DomainsPatch")]
        public async Task<IActionResult> DomainsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "info")]string info, [FromBody]Domains domains)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("Domain ID is required");
                }
                var domain = await _context.Domains.FindAsync(id);
                _context.Domains.Update(domain);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPost]
        [Route("domains")]
        [ValidateModelState]
        [SwaggerOperation("DomainsPost")]
        public async Task<IActionResult> DomainsPost([FromBody]Domains domains)
        {
            try
            {
                _context.Domains.Add(new Domains() { Info = domains.Info, Name = domains.Name });
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
