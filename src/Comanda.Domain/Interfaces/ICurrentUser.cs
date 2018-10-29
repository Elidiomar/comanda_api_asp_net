
using System.Collections.Generic;
using System.Security.Claims;

namespace Comanda.Domain.Interfaces
{
    public interface ICurrentUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
