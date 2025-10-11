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
    public class ToolsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToolsApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/tools/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ToolsDelete")]
        public async Task<IActionResult> ToolsDelete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Tool ID is required");
                }
                var existingtool = await _context.Tools.FindAsync(id);
                if (existingtool == null)
                {
                    return NotFound($"Tool with ID {id} not found");
                }
                _context.Tools.Remove(existingtool);
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
        [Route("/tools")]
        [ValidateModelState]
        [SwaggerOperation("ToolsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Tools>), description: "OK")]
        public async Task<IActionResult> ToolsGet([FromQuery] PaginationRequestModels queryParams)
        {
            try
            {
                // Start with base query
                var query = _context.Tools.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var tools = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<Tools>
                {
                    Data = tools,
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
        [Route("/tools")]
        [ValidateModelState]
        [SwaggerOperation("ToolsPatch")]
        public async Task<IActionResult> ToolsPatch([FromBody]Tools tool)
        {
            try
            {
                if (tool.Id <= 0)
                {
                    return BadRequest("ToolProfile ID is required");
                }
                var existingtool= await _context.Tools.FindAsync(tool.Id);
                if (existingtool == null)
                {
                    return NotFound($"ToolProfile with ID {tool.Id} not found");
                }
                existingtool.Name = tool.Name;
                existingtool.Description = tool.Description;
                existingtool.VarVersion = tool.VarVersion;
               
                existingtool.UpdatedAt = DateTime.UtcNow;
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
        [Route("/tools")]
        [ValidateModelState]
        [SwaggerOperation("ToolsPost")]
        public async Task<IActionResult> ToolsPost([FromBody]Tools tools)
        {
            try
            {
                _context.Tools.Add(new Tools() { 
                    Name = tools.Name, Description = tools.Description, CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow, VarVersion = tools.VarVersion
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
