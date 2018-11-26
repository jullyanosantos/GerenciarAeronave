using Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IAeronaveApplication : IDisposable
    {
        IEnumerable<AeronaveViewModel> GetAll(AeronaveViewModel aeronave);
        IEnumerable<AeronaveViewModel> GetAll();
        int Add(AeronaveViewModel aeronave);
        int Update(AeronaveViewModel aeronave);
        int Delete(int id);
    }
}