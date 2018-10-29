using Comanda.Domain.Core.Commands;
using Comanda.Domain.Interfaces;
using Comanda.Infra.Data.Context;

namespace Comanda.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ComandaDbContext _context;

        public UnitOfWork(ComandaDbContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
