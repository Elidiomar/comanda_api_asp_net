using Comanda.Domain.Models.Identity;

namespace Comanda.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<UserIdentity>
    {
        UserIdentity GetByEmail(string email);

        UserIdentity GetByUserName(string userName);

        UserIdentity Authorization(string userName, string password);
    }
}
