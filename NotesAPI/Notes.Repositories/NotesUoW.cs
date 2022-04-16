using Notes.DAL;
using System;
using System.Threading.Tasks;

namespace Notes.Repositories
{
    public class NotesUoW
    {
        private readonly NotesDbContext _dbContext;
        private NoteRepository _noteRepository;
        public NotesUoW(NotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public NoteRepository NoteRepository
        {
            get 
            {
                if (_noteRepository == null)
                    _noteRepository = new NoteRepository(_dbContext);

                return _noteRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
