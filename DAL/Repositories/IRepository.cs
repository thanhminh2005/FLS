using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(Object id);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Insert(T Entities);
        void Update(T Entities);
        void Delete(Object id);
    }
}