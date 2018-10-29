using Comanda.Domain.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda.Domain.Interfaces.Repository.Catalog
{
    public interface IImageManagerRepository : IRepository<Image>
    {

        /// <summary>
        /// Search images
        /// </summary>
        /// <param name="keyword">keyword</param>
        /// <returns>List of image entities</returns>
        IQueryable<Image> SearchImages(string keyword);
        

        /// <summary>
        /// Delete product image mapping
        /// </summary>
        /// <param name="productId">Product id</param>
        void DeleteAllProductImageMappings(Guid productId);
    }
}
