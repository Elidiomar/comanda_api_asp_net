using Comanda.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comanda.Infra.Data.Mappings.Identity
{
    public class UserLoginMap : IEntityTypeConfiguration<UserLogin>
    {        
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            builder.HasIndex(e => e.UserId);

            builder.Property(e => e.UserId).IsRequired();

            builder.HasOne(d => d.UserIdentity)
                .WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserId);

            builder.ToTable("UserLogins");
        }
    }
}
