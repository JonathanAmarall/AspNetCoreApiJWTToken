using System.Reflection;
using Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class DataContext : IdentityDbContext
    {

        //protected override void OnConfiguring(DbContextOptionsBuilder _optionsBuilder) { }
        public DataContext(DbContextOptions<DataContext> _options) : base(_options)
        {
        }

    }
}