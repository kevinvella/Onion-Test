using System;
using System.Linq;
using System.Linq.Expressions;

namespace EFCore.Repo.Interfaces
{
    public interface IRepository<T> where T : class
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
