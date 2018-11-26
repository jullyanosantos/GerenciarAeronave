using Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AeronaveContext _context;

        public UnitOfWork(AeronaveContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}