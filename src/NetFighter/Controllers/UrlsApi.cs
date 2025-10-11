using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetFighter.Attributes;
using NetFighter.Data;
using NetFighter.Models;
using NetFighter.Models.ResponseModels;
using NetFighter.RequestModels;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace NetFighter.Controllers
{
    [ApiController]
    //[Authorize]
    public class UrlsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UrlsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/urls/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UrlsDelete")]
        public async Task<IActionResult> UrlsDelete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Url ID is required");
                }
                var existingurl = await _context.Urls.FindAsync(id);
                if (existingurl == null)
                {
                    return NotFound($"Url with ID {id} not found");
                }
                _context.Urls.Remove(existingurl);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }
        [HttpGet]
        [Route("/urls")]
        [ValidateModelState]
        [SwaggerOperation("UrlsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Urls>), description: "OK")]
        public async Task<IActionResult> UrlsGet([FromQuery] PaginationRequestModels queryParams)
        {
            try
            {
                // Start with base query
                var query = _context.Urls.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var urls = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<Urls>
                {
                    Data = urls,
                    PageNumber = queryParams.PageNumber,
                    PageSize = queryParams.PageSize,
                    TotalCount = totalCount,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)queryParams.PageSize)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }
        [HttpPatch]
        [Route("/urls")]
        [ValidateModelState]
        [SwaggerOperation("UrlsPatch")]
        public async Task<IActionResult> UrlsPatch([FromBody]Urls url)
        {
            try
            {
                if (url.Id <= 0)
                {
                    return BadRequest("Url ID is required");
                }
                var existingurl = await _context.Urls.FindAsync(url.Id);
                if (existingurl == null)
                {
                    return NotFound($"Url with ID {url.Id} not found");
                }
                existingurl.Info = url.Info;
                existingurl.Requests = url.Requests;
                existingurl.Url = url.Url;
                existingurl.VhostId = url.VhostId;
                existingurl.UpdatedAt = DateTime.UtcNow;
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
        [Route("/urls")]
        [ValidateModelState]
        [SwaggerOperation("UrlsPost")]
        public async Task<IActionResult> UrlsPost([FromBody]Urls urls)
        {
            try
            {
                _context.Urls.Add(new Urls() { 
                    Info = urls.Info, //Requests = urls.Requests, 
                    Url = urls.Url, VhostId = urls.VhostId
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
