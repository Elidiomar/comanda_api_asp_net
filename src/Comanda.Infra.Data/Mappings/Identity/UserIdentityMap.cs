using Comanda.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comanda.Infra.Data.Mappings.Identity
{
    public class UserIdentityMap : IEntityTypeConfiguration<UserIdentity>
    {        
        public void Configure(EntityTypeBuilder<UserIdentity> builder)
        {
            builder.HasIndex(e => e.NormalizedEmail)
                           .HasName("EmailIndex");

            builder.HasIndex(e => e.NormalizedUserName)
                .HasName("UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Email).HasMaxLength(256);

            builder.Property(e => e.NormalizedEmail).HasMaxLength(256);

            builder.Property(e => e.NormalizedUserName).HasMaxLength(256);

            builder.Property(e => e.UserName).HasMaxLength(256);

            builder.ToTable("Users");
        }
    }
}
