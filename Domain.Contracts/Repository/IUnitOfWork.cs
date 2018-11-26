using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}