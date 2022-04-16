using Notes.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Services.Contract
{
    public interface INoteService
    {
        Task<int> AddNote(NoteDTO noteDTO);
        Task DeleteNote(int id);
        Task<IEnumerable<NoteDTO>> GetAllNotes();
        Task<NoteDTO> GetNoteById(int id);
        Task<NoteDTO> UpdateNote(NoteDTO noteDTO, int id);
    }
}