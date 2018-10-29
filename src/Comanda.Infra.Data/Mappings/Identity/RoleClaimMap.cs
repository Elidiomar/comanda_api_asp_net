using Comanda.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comanda.Infra.Data.Mappings.Identity
{
    public class RoleClaimMap : IEntityTypeConfiguration<RoleClaim>
    {        
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.HasIndex(e => e.RoleId);

            builder.Property(e => e.RoleId).IsRequired();

            builder.HasOne(d => d.Role)
                .WithMany(p => p.RoleClaims)
                .HasForeignKey(d => d.RoleId);

            builder.ToTable("RoleClaims");
        }
    }
}
