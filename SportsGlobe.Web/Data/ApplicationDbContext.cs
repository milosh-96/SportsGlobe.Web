using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsGlobe.Web.Domain;
using System.Security.Cryptography.X509Certificates;

namespace SportsGlobe.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Sport> Sports { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Stadium> Stadiums { get; set; }
    }
}
