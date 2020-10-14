using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder _optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder _builder)
        {

        }
    }
}