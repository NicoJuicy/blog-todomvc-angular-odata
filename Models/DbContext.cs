using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Odata_101.Models
{
    public class NoteContext : DbContext
    {
        public NoteContext()
            : base("DefaultConnection")
        {
        }

        public static NoteContext Create()
        {
            return new NoteContext();
        }

        public DbSet<Note> Notes { get; set; }
    }
}