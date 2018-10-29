using System;
using System.Collections.Generic;

namespace Comanda.Domain.Models.Identity
{
    public partial class UserToken
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public UserIdentity UserIdentity { get; set; }
    }
}
