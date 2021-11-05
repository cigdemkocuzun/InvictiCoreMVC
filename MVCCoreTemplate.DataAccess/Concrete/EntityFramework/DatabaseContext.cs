
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCCoreTemplate.DataAccess.Identity;
using MVCCoreTemplate.Entities.DbEntities;

namespace MVCCoreTemplate.DataAccess.Concrete.EntityFramework
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public DatabaseContext()
           
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=test; Trusted_Connection=true");

        }

        public DbSet<Application> Applications { get; set; }
    }
}


