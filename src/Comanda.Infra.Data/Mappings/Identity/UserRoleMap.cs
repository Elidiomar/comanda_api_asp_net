using Comanda.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comanda.Infra.Data.Mappings.Identity
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {        
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(e => new { e.UserId, e.RoleId });

            builder.HasIndex(e => e.RoleId);

            builder.HasOne(d => d.Role)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId);

            builder.HasOne(d => d.UserIdentity)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId);

            builder.ToTable("UserRoles");
        }
    }
}
