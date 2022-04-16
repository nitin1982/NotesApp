using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.DAL
{
    public class NoteRepository
    {
        private readonly NotesDbContext _dbContext;
        public NoteRepository(NotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
