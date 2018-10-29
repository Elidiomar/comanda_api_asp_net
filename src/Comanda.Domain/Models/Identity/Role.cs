using System.Collections.Generic;

namespace Comanda.Domain.Models.Identity
{
    public partial class Role
    {
        public Role()
        {
            RoleClaims = new HashSet<RoleClaim>();
            UserRoles = new HashSet<UserRole>();
        }

        public string Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public ICollection<RoleClaim> RoleClaims { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
