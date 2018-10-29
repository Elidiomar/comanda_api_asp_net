
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

        //public void Initialize()
        //{
        //    if (_context.Database.EnsureCreated())
        //    {
        //        if (!_roleManager.RoleExistsAsync(Roles.ROLE_API_ALTURAS).Result)
        //        {
        //            var resultado = _roleManager.CreateAsync(
        //                new IdentityRole(Roles.ROLE_API_ALTURAS)).Result;
        //            if (!resultado.Succeeded)
        //            {
        //                throw new Exception(
        //                    $"Erro durante a criação da role {Roles.ROLE_API_ALTURAS}.");
        //            }
        //        }

        //        CreateUser(
        //            new ApplicationUser()
        //            {
        //                UserName = "admin_apialturas",
        //                Email = "admin-apialturas@teste.com.br",
        //                EmailConfirmed = true
        //            }, "AdminAPIAlturas01!", Roles.ROLE_API_ALTURAS);

        //        CreateUser(
        //            new ApplicationUser()
        //            {
        //                UserName = "usrinvalido_apialturas",
        //                Email = "usrinvalido-apialturas@teste.com.br",
        //                EmailConfirmed = true
        //            }, "UsrInvAPIAlturas01!");
        //    }
        //}

        //private void CreateUser(ApplicationUser user,string password,string initialRole = null)
        //{
        //    if (_userManager.FindByNameAsync(user.UserName).Result == null)
        //    {
        //        var resultado = _userManager
        //            .CreateAsync(user, password).Result;

        //        if (resultado.Succeeded &&
        //            !String.IsNullOrWhiteSpace(initialRole))
        //        {
        //            _userManager.AddToRoleAsync(user, initialRole).Wait();
        //        }
        //    }
        //}
    }
}
