using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Comanda.Domain.Interfaces;
using Comanda.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Comanda.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        #region Fields

        protected readonly ComandaDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        #endregion

        #region Constructor

        public Repository(ComandaDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get All Entity
        /// </summary>
        /// <returns>Entity</returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        /// <summary>
        /// Find Entity using id
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns>Entity</returns>
        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(TEntity entity)
        {
        
            DbSet.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(TEntity entity)
        {  

            DbSet.Update(entity);
            SaveChanges();
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

        /// <summary>
        /// Find Entity using linq expression
        /// </summary>
        /// <param name="predicate">linq expression</param>
        /// <returns>Entity</returns>
        public TEntity GetByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet
                .AsNoTracking()
                .FirstOrDefault(predicate);
        }

        /// <summary>
        /// Find Entities using linq expression
        /// </summary>
        /// <param name="predicate">linq expression</param>
        /// <returns>List of entities</returns>
        public IQueryable<TEntity> GetManyByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet
                .AsNoTracking()
                .Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            if (Db != null) Db.Dispose();            
            GC.SuppressFinalize(this);
        }
        
        #endregion
        
    }
}
