using System;
using System.Linq;

namespace Domain.Contracts.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Func<T, bool> predicate);
        int Add(T entity);
        int Update(T entity);
        int Delete(int id);
    }
}