using System.IO;
using Comanda.Domain.Models.Catalog;
using Comanda.Domain.Models.Identity;
using Comanda.Domain.Models.Sale;
using Comanda.Infra.Data.Mappings.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Comanda.Infra.Data.Context
{
    public class ComandaDbContext : DbContext
    {
        //public DbSet<Customer> Customers { get; set; }

        // IDENTITY MODELS MAP DOMAIN
        public virtual DbSet<RoleClaim> RoleClaims { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Comanda.Domain.Models.Identity.UserIdentity> Users { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }

        //public DbSet<BillingAddress> BillingAddresses { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Image> Images { get; set; }

        //public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Comanda.Domain.Models.Sale.Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Comanda.Domain.Models.Catalog.Product> Products { get; set; }
        //public DbSet<ProductCategoryMapping> ProductCategoryMappings { get; set; }
        //public DbSet<ProductImageMapping> ProductImageMappings { get; set; }
        //public DbSet<ProductManufacturerMapping> ProductManufacturerMappings { get; set; }
        //public DbSet<ProductSpecificationMapping> ProductSpecificationMappings { get; set; }
        public DbSet<Comanda.Domain.Models.Sale.Historic> Historics { get; set; }
        //public DbSet<Specification> Specifications { get; set; }

        //public DbSet<OrderCount> OrderCounts { get; set; }
        //public DbSet<VisitorCount> VisitorCounts { get; set; }

        //public DbSet<ContactUsMessage> ContactUsMessage { get; set; }


        // APP MODELS MAP DOMAIN
        //public DbSet<Comanda.Domain.Models.Blog.Course> Courses { get; set; }
        //public DbSet<Comanda.Domain.Models.Blog.Phrase> Phrases { get; set; }
        //public DbSet<Comanda.Domain.Models.Blog.Meditation> Meditations { get; set; }
        //public DbSet<Comanda.Domain.Models.Blog.Theme> Themes { get; set; }
        //public DbSet<Comanda.Domain.Models.Blog.PhraseTheme> PhraseThemes { get; set; }
        //public DbSet<Comanda.Domain.Models.Blog.PlayList> PlayLists { get; set; }
        //public DbSet<Comanda.Domain.Models.Blog.MeditationPlayList> MeditationPlayLists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.ApplyConfiguration(new CustomerMap());

            // IDENTITY MAP CONFIG
            builder.ApplyConfiguration(new RoleClaimMap());
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new UserClaimMap());
            builder.ApplyConfiguration(new UserLoginMap());
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new UserIdentityMap());
            builder.ApplyConfiguration(new UserTokenMap());

            // APP MAP CONFIG
            //builder.ApplyConfiguration(new CourseMap());
            //builder.ApplyConfiguration(new PhraseMap());
            //builder.ApplyConfiguration(new ThemeMap());
            //builder.ApplyConfiguration(new MeditationMap());
            //builder.ApplyConfiguration(new PlayListMap());
            

            //builder.Entity<Budget>().ToTable("Budgets", schema: "data").HasKey(m => m.Id);
            //builder.Entity<BillingAddress>().ToTable("BillingAddress", schema: "data").HasKey(m => m.Id);
            //builder.Entity<Category>().ToTable("Category", schema: "data").HasKey(m => m.Id);
            //builder.Entity<Image>().ToTable("Image", schema: "data").HasKey(m => m.Id);
            //builder.Entity<Manufacturer>().ToTable("Manufacturer", schema: "data").HasKey(m => m.Id);
            //builder.Entity<Order>().ToTable("Order", schema: "data").HasKey(m => m.Id);
            //builder.Entity<OrderItem>().ToTable("OrderItem", schema: "data").HasKey(m => m.Id);
            //builder.Entity<Product>().ToTable("Product", schema: "data").HasKey(m => m.Id);
            //builder.Entity<ProductCategoryMapping>().ToTable("ProductCategoryMapping", schema: "data").HasKey(m => m.Id);
            //builder.Entity<ProductImageMapping>().ToTable("ProductImageMapping", schema: "data").HasKey(m => m.Id);
            //builder.Entity<ProductManufacturerMapping>().ToTable("ProductManufacturerMapping", schema: "data").HasKey(m => m.Id);
            //builder.Entity<ProductSpecificationMapping>().ToTable("ProductSpecificationMapping", schema: "data").HasKey(m => m.Id);
            //builder.Entity<Review>().ToTable("Review", schema: "data").HasKey(m => m.Id);
            //builder.Entity<Specification>().ToTable("Specification", schema: "data").HasKey(m => m.Id);
            //builder.Entity<OrderCount>().ToTable("OrderCount", schema: "data").HasKey(m => m.Id);
            //builder.Entity<VisitorCount>().ToTable("VisitorCount", schema: "data").HasKey(m => m.Id);
            //builder.Entity<ContactUsMessage>().ToTable("ContactUsMessage", schema: "data").HasKey(m => m.Id);            
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
