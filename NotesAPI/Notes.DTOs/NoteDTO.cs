using System;

namespace Notes.DTOs
{    
    public class NoteDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
