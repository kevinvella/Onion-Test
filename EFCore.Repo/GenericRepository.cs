using EFCore.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using EFCore.Repo.Context;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repo
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        ApplicationContext context;

        public GenericRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public T Add(T item)
        {
            context.Entry(item).State = EntityState.Added;
            return item;
        }

        public void Add(params T[] items)
        {
            foreach (T item in items)
            {
                context.Entry(item).State = EntityState.Added;
            }
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public IQueryable<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = context.Set<T>();

            foreach (var navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            dbQuery = dbQuery.Where(where).AsQueryable<T>();

            return dbQuery;
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;

            IQueryable<T> dbQuery = context.Set<T>();

            foreach (var navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = dbQuery.FirstOrDefault(where);
            return item;
        }

        public void Remove(T item)
        {
            context.Set<T>().Remove(item);
        }

        public void Remove(params T[] item)
        {
            foreach (var it in item)
            {
                context.Set<T>().Remove(it);
            }
        }

        public void Update(T item)
        {
            context.Set<T>().Attach(item);
            context.Entry<T>(item).State = EntityState.Modified;
        }

        public void Update(params T[] items)
        {
            foreach (var item in items)
            {
                context.Set<T>().Attach(item);
                context.Entry<T>(item).State = EntityState.Modified;
            }
        }
    }
}
