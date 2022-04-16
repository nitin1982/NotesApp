using System;
using Microsoft.EntityFrameworkCore;
using Notes.DAL.Entities;

namespace Notes.DAL
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options): base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
    }
}
