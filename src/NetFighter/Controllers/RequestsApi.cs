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
    public class RequestsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RequestsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/requests")]
        [ValidateModelState]
        [SwaggerOperation("RequestsDelete")]
        public async Task<IActionResult> RequestsDelete(int id)
        {

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("/requests")]
        [ValidateModelState]
        [SwaggerOperation("RequestsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Requests>), description: "OK")]
        public async Task<IActionResult> RequestsGet([FromQuery] PaginationRequestModels queryParams)
        {
            try
            {
                // Start with base query
                var query = _context.Requests.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var requests = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<Requests>
                {
                    Data = requests,
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
        [Route("/requests")]
        [ValidateModelState]
        [SwaggerOperation("RequestsPatch")]
        public async Task<IActionResult> RequestsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "url_id")]string urlId, [FromQuery (Name = "created_at")]string createdAt, [FromQuery (Name = "method")]string method, [FromQuery (Name = "status")]string status, [FromQuery (Name = "response")]string response, [FromQuery (Name = "info")]string info, [FromQuery (Name = "raw_request")]string rawRequest, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Requests requests)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/requests")]
        [ValidateModelState]
        [SwaggerOperation("RequestsPost")]
        public async Task<IActionResult> RequestsPost([FromBody]Requests requests)
        {
            try
            {
                _context.Requests.Add(new Requests() { 
                    Info = requests.Info, Method = requests.Method, Status = requests.Status,
                    RawRequest = requests.RawRequest, Response = requests.Response, UrlId = requests.UrlId
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
