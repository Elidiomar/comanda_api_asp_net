using Comanda.Domain.Interfaces.Repository.Catalog;
using Comanda.Domain.Models.Catalog;
using Comanda.Domain.Models.Sale;
using Comanda.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Comanda.Infra.Data.Repository.Catalog
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        #region Fields

        #endregion

        #region Constructor

        public OrderRepository(ComandaDbContext context)
            : base(context)
        {

        }

        #endregion

        #region Methods
        #endregion
    }
}
