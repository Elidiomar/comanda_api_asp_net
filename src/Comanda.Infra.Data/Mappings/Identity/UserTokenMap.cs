using Comanda.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comanda.Infra.Data.Mappings.Identity
{
    public class UserTokenMap : IEntityTypeConfiguration<UserToken>
    {        
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            builder.HasOne(d => d.UserIdentity)
                .WithMany(p => p.UserTokens)
                .HasForeignKey(d => d.UserId);

            builder.ToTable("UserTokens");

        }
    }
}
