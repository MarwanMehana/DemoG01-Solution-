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
            public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
            {
                return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true).Select(selector);
            }
        }
        // Get By Id
        public TEntity? GetById(int id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            return entity;
        }

        // Insert
        public int Add(TEntity entity)
        {
            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
        }
        // Update
        public int Update(TEntity entity)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }
        // Remove
        public int Remove(TEntity entity)
        {
            _dbContext.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetEnumerable()
        {
            return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true).ToList();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true);
        }
    }
}
