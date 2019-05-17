using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Livraria.ApplicationCore.Entity;
using Livraria.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infrastructure.Repository.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected LivrariaContext _context;
        protected DbSet<TEntity> _dbSet;

        #region Constructor

        public Repository(LivrariaContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        #endregion

        public TEntity Add(TEntity entity)
        {
            _context.Add(entity);
            return entity;
        }
        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            _context.AddRange(entities);
            return entities;
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Remove(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
