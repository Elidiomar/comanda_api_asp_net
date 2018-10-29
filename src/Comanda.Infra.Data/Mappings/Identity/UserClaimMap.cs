using Comanda.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comanda.Infra.Data.Mappings.Identity
{
    public class UserClaimMap : IEntityTypeConfiguration<UserClaim>
    {        
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasIndex(e => e.UserId);

            builder.Property(e => e.UserId).IsRequired();

            builder.HasOne(d => d.UserIdentity)
                .WithMany(p => p.UserClaims)
                .HasForeignKey(d => d.UserId);

            builder.ToTable("UserClaims");
        }
    }
}
