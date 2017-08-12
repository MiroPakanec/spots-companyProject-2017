using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace spots.DAL.Queries.Repositories.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        int FindAndDelete(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
    }
}
