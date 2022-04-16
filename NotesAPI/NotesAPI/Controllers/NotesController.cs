using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes.DTOs;
using Notes.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }
        public async Task<IActionResult> GetAllNotes()
        {
            return Ok(await _noteService.GetAllNotes());            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id)
        {
            var note = await _noteService.GetNoteById(id);
            if (note == null)
                return NotFound();
            return Ok(note);
        }

        [HttpPost()]
        public async Task<IActionResult> AddNote([FromBody] NoteDTO note)
        {
            if (string.IsNullOrEmpty(note.Title) || string.IsNullOrEmpty(note.Description))
                return BadRequest("Invalid Note to add.");
            var id = await _noteService.AddNote(note);
            note.Id = id;
            return CreatedAtAction(nameof(GetNoteById) , new { id = id }, note);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote([FromBody] NoteDTO note, int id)
        {
            if(id != note.Id || string.IsNullOrEmpty(note.Title) || string.IsNullOrEmpty(note.Description))
                return BadRequest("Invalid Note to update.");

            var updatedNote = await _noteService.UpdateNote(note, id);
            if (updatedNote == null)
                return NotFound();

            return NoContent();
        }
    }
}
