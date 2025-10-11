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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetFighter.Controllers
{
    [ApiController]
    //[Authorize]
    public class ParamsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParamsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete]
        [Route("/params/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ParamsDelete")]
        public async Task<IActionResult> ParamsDelete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Param ID is required");
                }
                var param = await _context.Params.FindAsync(id);
                _context.Params.Remove(param);
                await _context.SaveChangesAsync();
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }
        [HttpGet]
        [Route("/params")]
        [ValidateModelState]
        [SwaggerOperation("ParamsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Params>), description: "OK")]
        public async Task<IActionResult> ParamsGet([FromQuery] PaginationRequestModels queryParams)
        {
            try
            {
                // Start with base query
                var query = _context.Params.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var _params = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<Params>
                {
                    Data = _params,
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
            ;
        }
        [HttpPatch]
        [Route("/params")]
        [ValidateModelState]
        [SwaggerOperation("ParamsPatch")]
        public async Task<IActionResult> ParamsPatch([FromQuery (Name = "id")]string id, [FromQuery (Name = "name")]string name, [FromQuery (Name = "value")]string value, [FromQuery (Name = "vhost_id")]string vhostId, [FromHeader (Name = "Prefer")]string prefer, [FromBody]Params varParams)
        {

            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("/params")]
        [ValidateModelState]
        [SwaggerOperation("ParamsPost")]
        public async Task<IActionResult> ParamsPost([FromBody]Params param)
        {
            try
            {
                _context.Params.Add(new Params() { 
                    Name = param.Name,
                    Value = param.Value,
                    //Id 
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
