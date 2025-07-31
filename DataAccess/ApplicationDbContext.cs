using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Unitrust_Test.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Unitrust_Test.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Visitor> Visitors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
