using Microsoft.EntityFrameworkCore;
using MVC_Task5.Models;

namespace MVC_Task5.Context
    {
    public class CollageConText:DbContext
        {
        public DbSet<User> Users { get; set; }
        public DbSet<Courses> courses { get; set; }
        public CollageConText() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LAPTOP-N4FSBJ00;Database=!courses;Trusted_Connection=True;Encrypt=False");
        }
    }
