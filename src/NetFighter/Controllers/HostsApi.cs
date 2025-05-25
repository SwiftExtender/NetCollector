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
using NetFighter.Data;
using System.Threading.Tasks;
using System.Linq;

namespace NetFighter.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class HostsApiController : ControllerBase
    { 
        private readonly ApplicationDbContext _context;

        public HostsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ip"></param>
        /// <param name="info"></param>
        /// <param name="subnetId"></param>
        /// <param name="prefer">Preference</param>
        /// <response code="204">No Content</response>
        [HttpDelete]
        [Route("/hosts")]
        [ValidateModelState]
        [SwaggerOperation("HostsDelete")]
        public async Task<IActionResult> HostsDelete([FromQuery (Name = "id")]string id)
        {
            try
            {
                Hosts deletedHost = new Hosts() { Id = Int32.Parse(id) };
                _context.Hosts.Remove(deletedHost);
                await _context.SaveChangesAsync();
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ip"></param>
        /// <param name="info"></param>
        /// <param name="subnetId"></param>
        /// <param name="select">Filtering Columns</param>
        /// <param name="order">Ordering</param>
        /// <param name="range">Limiting and Pagination</param>
        /// <param name="rangeUnit">Limiting and Pagination</param>
        /// <param name="offset">Limiting and Pagination</param>
        /// <param name="limit">Limiting and Pagination</param>
        /// <param name="prefer">Preference</param>
        /// <response code="200">OK</response>
        /// <response code="206">Partial Content</response>
        [HttpGet]
        [Route("/hosts")]
        [ValidateModelState]
        [SwaggerOperation("HostsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hosts>), description: "OK")]
        public async Task<IActionResult> HostsGet()
        {
            try
            {
                return StatusCode(200, new { Message = _context.Hosts.ToList() });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }
        //[FromQuery (Name = "id")]string id, [FromQuery (Name = "ip")]string ip, [FromQuery (Name = "info")]string info, [FromQuery (Name = "subnet_id")]string subnetId, [FromQuery (Name = "select")]string select, [FromQuery (Name = "order")]string order, [FromHeader (Name = "Range")]string range, [FromHeader (Name = "Range-Unit")]string rangeUnit, [FromQuery (Name = "offset")]string offset, [FromQuery (Name = "limit")]string limit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ip"></param>
        /// <param name="info"></param>
        /// <param name="subnetId"></param>
        /// <param name="prefer">Preference</param>
        /// <param name="hosts">hosts</param>
        /// <response code="204">No Content</response>
        [HttpPatch]
        [Route("/hosts")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("HostsPatch")]
        public async Task<IActionResult> HostsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "ip")]string ip, [FromQuery (Name = "info")]string info, [FromQuery (Name = "subnet_id")]string subnetId)
        {
            try
            {
                _context.Hosts.Update(new Hosts() { Id = Int32.Parse(id), Ip = ip, Info = info });
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="select">Filtering Columns</param>
        /// <param name="hosts">hosts</param>
        /// <response code="201">Created</response>
        [HttpPost]
        [Route("/hosts")]
        [Consumes("application/json", "application/vnd.pgrst.object+json;nulls=stripped", "application/vnd.pgrst.object+json", "text/csv")]
        [ValidateModelState]
        [SwaggerOperation("HostsPost")]
        public async Task<IActionResult> HostsPost([FromQuery(Name = "ip")] string ip, [FromQuery(Name = "info")] string info)
        {
            try
            {
                _context.Hosts.Add(new Hosts() { Ip = ip, Info = info });
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
