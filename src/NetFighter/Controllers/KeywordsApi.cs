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

namespace NetFighter.Controllers
{
    [ApiController]
    //[Authorize]
    public class KeywordsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public KeywordsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete]
        [Route("/keywords/{id}")]
        [ValidateModelState]
        [SwaggerOperation("KeywordsDelete")]
        [SwaggerResponse(statusCode: 204, description: "Delete keyword")]
        public async Task<IActionResult> KeywordsDelete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Keyword ID is required");
                }
                var existingkeyword = await _context.Keywords.FindAsync(id);
                if (existingkeyword == null)
                {
                    return NotFound($"Keyword with ID {id} not found");
                }
                _context.Keywords.Remove(existingkeyword);
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
        [Route("/keywords")]
        [ValidateModelState]
        [SwaggerOperation("KeywordsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Keywords>), description: "OK")]
        public async Task<IActionResult> KeywordsGet([FromQuery] PaginationRequestModels queryParams)
        {
            try
            {
                // Start with base query
                var query = _context.Keywords.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var keywords = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<Keywords>
                {
                    Data = keywords,
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
        [Route("/keywords")]
        [ValidateModelState]
        [SwaggerOperation("KeywordsPatch")]
        public async Task<IActionResult> KeywordsPatch([FromBody]Keywords keywords)
        {
            try
            {
                if (keywords.Id <= 0)
                {
                    return BadRequest("Keyword ID is required");
                }
                var existingkeyword = await _context.Keywords.FindAsync(keywords.Id);
                if (existingkeyword == null)
                {
                    return NotFound($"Keyword with ID {keywords.Id} not found");
                }
                existingkeyword.Name = keywords.Name;
                existingkeyword.Source = keywords.Source;
                existingkeyword.SourceType = keywords.SourceType;
                existingkeyword.Info = keywords.Info;
                existingkeyword.UpdatedAt = DateTime.UtcNow;
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
        [Route("/keywords")]
        [ValidateModelState]
        [SwaggerOperation("KeywordsPost")]
        public async Task<IActionResult> KeywordsPost([FromBody]Keywords keywords)
        {
            try
            {
                _context.Keywords.Add(new Keywords() { Info = keywords.Info, Name = keywords.Name, Source = keywords.Source, SourceType = keywords.SourceType });
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
