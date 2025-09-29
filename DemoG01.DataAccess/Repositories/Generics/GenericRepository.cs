using DemoG01.DataAccess.Data.Contexts;
using DemoG01.DataAccess.Models;
using DemoG01.DataAccess.Models.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.DataAccess.Repositories.Generics
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository( ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // CRUD Operations
        // Get All
        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true).ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true).AsNoTracking().ToList();
            }
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
           return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }
        // Get By Id
        public TEntity? GetById(int id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            return entity;
        }

        // Insert
        public void Add(TEntity entity)
        {
            _dbContext.Add(entity);
        }
        // Update
        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }
        // Remove
        public void Remove(TEntity entity)
        {
            _dbContext.Remove(entity);
        }

        public IEnumerable<TEntity> GetEnumerable()
        {
            return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true).ToList();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true);
        }

        public IEnumerable<TEntity> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            throw new NotImplementedException();
        }

       
    }
}
