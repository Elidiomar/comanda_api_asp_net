using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Comanda.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Find Entity using id
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns>Entity</returns>
        TEntity GetById(Guid id);               

        /// <summary>
        /// Get All Entity
        /// </summary>
        /// <returns>Entity</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Find Entity using linq expression
        /// </summary>
        /// <param name="predicate">linq expression</param>
        /// <returns>Entity</returns>
        TEntity GetByExpression(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Find Entities using linq expression
        /// </summary>
        /// <param name="predicate">linq expression</param>
        /// <returns>List of entities</returns>
        IQueryable<TEntity> GetManyByExpression(Expression<Func<TEntity, bool>> predicate);

        void Insert(TEntity entity);
        
        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(TEntity entity);

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Remove(Guid id);        

        /// <summary>
        /// Save Changes
        /// </summary>
        int SaveChanges();
    }
}
