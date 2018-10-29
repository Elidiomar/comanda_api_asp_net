using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Comanda.Domain.Models;
using Comanda.Domain.Models.Identity;

namespace Comanda.Infra.Data.Mappings.Identity
{    
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
                builder.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                builder.Property(e => e.Id).ValueGeneratedNever();

                builder.Property(e => e.Name).HasMaxLength(256);

                builder.Property(e => e.NormalizedName).HasMaxLength(256);

            builder.ToTable("Roles");

        }
    }
}