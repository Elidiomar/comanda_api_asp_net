
using Comanda.Infra.Cross.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Comanda.Infra.Cross.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<HistoryRow>().ToTable("MigrationsHistory", "admin").HasKey(h => h.MigrationId);

            modelBuilder.Entity<Comanda.Infra.Cross.Identity.Models.ApplicationUser>().ToTable("Users", "Identity");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "Identity");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Identity");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Identity");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Identity");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Identity");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Identity");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()                
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();            

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetSection("ConnectionString")["LocalConnection"]);
        }
    }
}
