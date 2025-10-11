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
    public class NotesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotesApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpDelete]
        [Route("/notes/{id}")]
        [ValidateModelState]
        [SwaggerOperation("NotesDelete")]
        public async Task<IActionResult> NotesDelete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Note ID is required");
                }
                var existingnote = await _context.Notes.FindAsync(id);
                if (existingnote == null)
                {
                    return NotFound($"Note with ID {id} not found");
                }
                _context.Notes.Remove(existingnote);
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
        [Route("/notes/{id}")]
        [ValidateModelState]
        [SwaggerOperation("GetNote")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Notes>), description: "OK")]
        public async Task<IActionResult> GetNote(int id)
        {
            try
            {
                Notes notes = await _context.Notes.SingleAsync(p => p.Id == id);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpGet]
        [Route("/notes")]
        [ValidateModelState]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Notes>), description: "OK")]
        public async Task<IActionResult> GetNotes([FromQuery] PaginationRequestModels queryParams)
        {
            try
            {
                // Start with base query
                var query = _context.Notes.AsQueryable();

                // Get total count for pagination metadata
                var totalCount = await query.CountAsync();

                // Apply pagination
                var notes = await query
                    .OrderBy(h => h.Id)
                    .Skip((queryParams.PageNumber - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();

                // Create response with pagination metadata
                var response = new PagedResponse<Notes>
                {
                    Data = notes,
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
        [Route("/notes")]
        [ValidateModelState]
        [SwaggerOperation("PatchNotes")]
        public async Task<IActionResult> NotesPatch([FromBody] Notes note)
        {
            try
            {
                if (note.Id <= 0)
                {
                    return BadRequest("Port ID is required");
                }
                var existingnote = await _context.Notes.FindAsync(note.Id);
                if (existingnote == null)
                {
                    return NotFound($"Port with ID {note.Id} not found");
                }
                existingnote.Text = note.Text;
                existingnote.Date= note.Date;
                existingnote.UpdatedAt = DateTime.UtcNow;
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
        [Route("/notes")]
        [ValidateModelState]
        [SwaggerOperation("AddPorts")]
        public async Task<IActionResult> NotesPost([FromBody] Notes note)
        {
            try
            {
                Notes createdNote = new Notes() { 
                    Date = DateTime.UtcNow, 
                    Text = note.Text,
                    CreatedAt = DateTime.UtcNow
                };
                _context.Notes.Add(createdNote);
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, new { ex.InnerException });
            }
        }
    }
}
