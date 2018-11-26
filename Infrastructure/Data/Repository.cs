using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Domain.Contracts.Repository;

namespace Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Attributes

        protected readonly AeronaveContext _context;

        #endregion

        #region Constructor
        public Repository(AeronaveContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        public int Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public int Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> Get(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).AsQueryable();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public int Delete(int id)
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges();
        }
        #endregion
    }
}