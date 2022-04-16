using Microsoft.EntityFrameworkCore;
using Notes.DAL;
using Notes.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Repositories
{
    public class NoteRepository
    {
        private readonly NotesDbContext _dbContext;
        private DbSet<Note> _dbSet;
        public NoteRepository(NotesDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Note>();
        }

        public void Add(Note note)
        {
            _dbSet.Add(note);
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Note> GetByIDAsync(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(en => en.Id == id);
        }

        public async Task<Note> GetFirstAsync(Expression<Func<Note, bool>> where)
        {
            return await _dbSet.FirstOrDefaultAsync(where);
        }

        public void Update(Note entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

    }
}
