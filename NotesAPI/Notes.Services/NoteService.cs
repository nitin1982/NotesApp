using Notes.DAL.Entities;
using Notes.DTOs;
using Notes.Repositories;
using Notes.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Services
{
    public class NoteService : INoteService
    {
        private NotesUoW _uow;
        public NoteService(NotesUoW uow)
        {
            _uow = uow;
        }

        public async Task<int> AddNote(NoteDTO noteDTO)
        {
            var repo = _uow.NoteRepository;
            var note = new Note();
            note.Title = noteDTO.Title;
            note.Description = noteDTO.Description;
            note.Description = noteDTO.Description;
            repo.Add(note);
            await _uow.SaveAsync();

            return note.Id;
        }

        public async Task DeleteNote(int id)
        {
            throw new NotImplementedException();
        }

        private async Task CreateDefaultData()
        {
            await AddNote(new NoteDTO { Description = "My First Note.", Title = "Sample Note 1", CreatedDate = DateTime.Now });
            await AddNote(new NoteDTO { Description = "My Second Note.", Title = "Sample Note 2", CreatedDate = DateTime.Now });
        }
        public async Task<IEnumerable<NoteDTO>> GetAllNotes()
        {            
            var repo = _uow.NoteRepository;
            var notes = await repo.GetAllAsync();
            if (notes.Count() == 0)
            {
                await CreateDefaultData();
                notes = await repo.GetAllAsync();
            }
            var result = new List<NoteDTO>();

            foreach (var note in notes)
            {
                result.Add(new NoteDTO 
                {
                    Id = note.Id,
                    Title = note.Title,
                    Description = note.Description,
                    CreatedDate = note.CreatedDate
                });
            }

            return result;
        }

        public async Task<NoteDTO> GetNoteById(int id)
        {
            var repo = _uow.NoteRepository;
            var note = await repo.GetByIDAsync(id);
            if (note == null)
                return null;
            var result = new NoteDTO() { 
                Id = note.Id,
                Title = note.Title,
                Description = note.Description,
                CreatedDate = note.CreatedDate
            };
            return result;
        }

        public async Task<NoteDTO> UpdateNote(NoteDTO noteDTO, int id)
        {
            var repo = _uow.NoteRepository;
            var note = await repo.GetByIDAsync(id);
            if (note == null)
                return null;

            note.Id = id;
            note.Title = noteDTO.Title;
            note.Description = noteDTO.Description;
                        
            repo.Update(note);
            await _uow.SaveAsync();
            return noteDTO;
        }
    }
}
