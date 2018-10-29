using Comanda.Domain.Interfaces.Repository.Catalog;
using Comanda.Domain.Models.Catalog;
using Comanda.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Comanda.Infra.Data.Repository.Catalog
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        #region Fields

        #endregion

        #region Constructor

        public ProductRepository(ComandaDbContext context)
            : base(context)
        {

        }

        public Product GetBySeo(string seo)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> SearchProduct(string nameFilter = null, string seoFilter = null, string[] categoryFilter = null, string[] manufacturerFilter = null, string[] priceFilter = null, bool isPublished = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Table()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Methods

        #endregion

    }

}
