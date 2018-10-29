using System;
using System.Linq;
using Comanda.Domain.Interfaces.Repository;
using Comanda.Domain.Models.Identity;
using Comanda.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Comanda.Infra.Data.Repository
{
    public class UserRepository : Repository<UserIdentity>, IUserRepository
    {
        public UserRepository(ComandaDbContext context)
            : base(context)
        {

        }

        public override UserIdentity GetById(Guid id)
        {
            return Db.Users.AsNoTracking().SingleOrDefaultAsync(m => m.Id == id.ToString()).Result;
        }

        public UserIdentity GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }

        public UserIdentity GetByUserName(string userName)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.UserName == userName);
        }

        public UserIdentity Authorization(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return null;

            var user = Db.Users.AsNoTracking().SingleOrDefault(x => x.UserName == userName && x.PasswordHash == password);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            // if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //     return null;

            // authentication successful
            return user;

        }
    }
}
