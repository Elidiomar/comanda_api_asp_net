using System;
using System.Collections.Generic;

namespace Comanda.Domain.Models.Identity
{
    public partial class UserClaim
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string UserId { get; set; }

        public UserIdentity UserIdentity { get; set; }
    }
}
