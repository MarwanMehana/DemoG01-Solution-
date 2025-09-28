using DemoG01.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.DataAccess.Repositories.Generics
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        int Add(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        IEnumerable<TEntity> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetById(int id);
        int Remove(TEntity entity);
        int Update(TEntity entity);

    }
}
