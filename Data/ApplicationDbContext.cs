using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<MvcMovie.Models.Customer> Customer { get; set; } = default!;
        public DbSet<MvcMovie.Models.Order> Order { get; set; } = default!;
        public DbSet<MvcMovie.Models.Product> Product { get; set; } = default!;
    }
}