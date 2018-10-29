using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comanda.Domain.Models.Identity
{
    [Table("Users", Schema = "Identity")]
    public partial class UserIdentity
    {
        public UserIdentity()
        {
            UserClaims = new HashSet<UserClaim>();
            UserLogins = new HashSet<UserLogin>();
            UserRoles = new HashSet<UserRole>();
            UserTokens = new HashSet<UserToken>();
        }

        public Guid BillingAddressId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string AvatarURL { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Registro")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd'T'HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime DateRegistered { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Controle")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd'T'HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime Control { get; set; }

        public string Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }

        public ICollection<UserClaim> UserClaims { get; set; }
        public ICollection<UserLogin> UserLogins { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserToken> UserTokens { get; set; }
    }
}
