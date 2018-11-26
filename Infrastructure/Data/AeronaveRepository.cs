using Domain.Contracts.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class AeronaveRepository : Repository<Aeronave>, IAeronaveRepository
    {
        public AeronaveRepository(AeronaveContext context)
           : base(context)
        {

        }
    }
}