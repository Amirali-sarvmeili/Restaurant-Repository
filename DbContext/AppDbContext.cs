using crud.Mapping;
using crud.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Comestible> Comestibles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
    }
}