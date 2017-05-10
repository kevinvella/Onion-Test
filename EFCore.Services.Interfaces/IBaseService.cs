using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        List<T> GetAll();

        T GetSingle(int pk);

        T GetSingle(Guid uniqueIdentifier);

        T GetSingle(string name);

        void Add(T obj);

        void Update(T obj);

        void Delete(T obj);
    }
}
