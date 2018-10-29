using Comanda.Domain.Interfaces.Repository.Catalog;
using Comanda.Domain.Models.Catalog;
using Comanda.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda.Infra.Data.Repository.Catalog
{
    public class ImageManagerRepository : Repository<Image>, IImageManagerRepository
    {
        #region Fields

        #endregion

        #region Constructor

        public ImageManagerRepository(ComandaDbContext context)
            : base(context)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all images
        /// </summary>
        /// <returns>List of image entities</returns>
        public override IQueryable<Image> GetAll()
        {
            var entites = GetAll()
                .OrderBy(x => x.FileName);

            return entites;
        }

        /// <summary>
        /// Search images
        /// </summary>
        /// <param name="keyword">keyword</param>
        /// <returns>List of image entities</returns>
        public IQueryable<Image> SearchImages(string keyword)
        {
            return GetManyByExpression(x => x.FileName.Contains(keyword))
                .OrderBy(x => x.FileName);
        }

        /// <summary>
        /// Delete product image mapping
        /// </summary>
        /// <param name="productId">Product id</param>
        public void DeleteAllProductImageMappings(Guid productId)
        {
            if (productId == null) throw new ArgumentNullException("productId");

            //var mappings = Db.ProductImageMappings.Where(x => x.ProductId == productId);

            //foreach (var mapping in mappings) Db.ProductImageMappings.Remove(mapping);

            Db.SaveChanges();
        }

        #endregion
    }
}
