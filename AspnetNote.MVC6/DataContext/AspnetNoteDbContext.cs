using AspnetNote.MVC6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.MVC6.DataContext
{
    public class AspnetNoteDbContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-URHM9LJH\SQLEXPRESS; Database=AspnetDB; User Id=sa; Password=20171023");
        }
    }
}
