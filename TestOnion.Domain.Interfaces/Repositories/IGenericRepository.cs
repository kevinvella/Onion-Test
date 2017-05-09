using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TestOnion.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        void Add(params T[] items);

        T Add(T item);

        void Update(params T[] items);

        void Update(T item);

        void Remove(params T[] item);

        void Remove(T item);
    }
}
