using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using NetFighter.Attributes;
using NetFighter.Models;
using Microsoft.EntityFrameworkCore;
using NetFighter.Data;
using System.Linq;
using NetFighter.RequestModels;

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
                    return BadRequest("Port ID is required");
                }
                var host = await _context.Hosts.FindAsync(id);
                _context.Hosts.Remove(host);
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
        public async Task<IActionResult> GetNotes()
        {
            try
            {
                List<Notes> notes = await _context.Notes.ToListAsync();
                return Ok(notes);
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
        public async Task<IActionResult> NotesPatch([FromBody] UpdatedPort port)
        {
            try
            {
                Notes note = new Notes() { };
                _context.Notes.Update(note);
                await _context.SaveChangesAsync();
                return StatusCode(200);
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
                Notes createdNote = new Notes() { Date = DateTime.UtcNow, Text = note.Text };
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
