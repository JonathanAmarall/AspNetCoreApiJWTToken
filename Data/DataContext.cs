using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder _optionsBuilder) { }
        public DataContext(DbContextOptions<DataContext> _options) : base(_options)
        {
        }
        protected override void OnModelCreating(ModelBuilder _builder)
        {

        }
    }
}