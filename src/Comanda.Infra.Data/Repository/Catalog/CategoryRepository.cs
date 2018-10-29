using Comanda.Domain.Interfaces.Repository.Catalog;
using Comanda.Domain.Models.Catalog;
using Comanda.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Comanda.Infra.Data.Repository.Catalog
{
    //public class CategoryRepository : Repository<Category>, ICategoryRepository
    //{
    //    #region Fields

    //    #endregion

    //    #region Constructor

    //    public CategoryRepository(ComandaDbContext context)
    //        : base(context)
    //    {

    //    }

    //    #endregion

    //    #region Methods

    //    /// <summary>
    //    /// Get all categories by name
    //    /// </summary>
    //    /// <returns>List of category entities</returns>
    //    public override IQueryable<Category> GetAll()
    //    {
    //        return DbSet.OrderBy(x => x.Name);
    //    }

    //    /// <summary>
    //    /// Get all categories without parent
    //    /// </summary>
    //    /// <returns>List of category entities without parent</returns>
    //    public IQueryable<Category> GetAllCategoriesWithoutParent()
    //    {
    //        var entities = GetManyByExpression(x => x.ParentCategoryId == Guid.Empty)
    //            .OrderBy(x => x.Name);

    //        return entities;
    //    }

    //    /// <summary>
    //    /// Get category using seo
    //    /// </summary>
    //    /// <param name="seo">Category SEO</param>
    //    /// <returns>Category entity</returns>
    //    public Category GetCategoryBySeo(string seo)
    //    {
    //        if (seo == "")
    //            return null;

    //        return GetByExpression(x => x.SeoUrl == seo);
    //    }
                
    //    /// <summary>
    //    /// Insert product category mappings
    //    /// </summary>
    //    /// <param name="productCategoryMappings">List of product category mapping</param>
    //    public void InsertProductCategoryMappings(IList<ProductCategoryMapping> productCategoryMappings)
    //    {
    //        if (productCategoryMappings == null)
    //            throw new ArgumentNullException("productCategoryMappings");

    //        foreach (var mapping in productCategoryMappings)
    //            Db.ProductCategoryMappings.Add(mapping);
    //            Db.SaveChanges();
    //    }

    //    /// <summary>
    //    /// Delete all product category mappings using product id
    //    /// </summary>
    //    /// <param name="productId">Product id</param>
    //    public void DeleteAllProductCategoryMappingsByProductId(Guid productId)
    //    {
    //        if (productId == null)
    //            throw new ArgumentNullException("productId");

    //        var mappings = Db.ProductCategoryMappings.Where(x => x.ProductId == productId);

    //        foreach (var mapping in mappings) Db.ProductCategoryMappings.Remove(mapping);

    //            Db.SaveChanges();
    //    }        
    //    #endregion
    //}
}
