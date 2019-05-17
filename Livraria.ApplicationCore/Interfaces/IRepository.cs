using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Livraria.ApplicationCore.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Remove(int id);
        void RemoveRange(IEnumerable<TEntity> entities);
        int SaveChanges();
    }
}
