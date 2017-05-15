using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repo.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
