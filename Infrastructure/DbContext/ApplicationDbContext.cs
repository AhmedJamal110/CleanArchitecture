

using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }


        public DbSet<Property> Properties { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
