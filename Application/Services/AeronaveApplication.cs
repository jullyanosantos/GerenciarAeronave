using System.Linq;
using System.Collections.Generic;
using Domain.Contracts.Repository;
using Domain.Entities;
using System;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;

namespace Application.Services
{
    public class AeronaveApplication : IAeronaveApplication
    {
        #region Attributes
        private readonly IAeronaveRepository _aeronaveRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public AeronaveApplication(IAeronaveRepository aeronaveRepository, IMapper mapper)
        {
            _aeronaveRepository = aeronaveRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods

        public IEnumerable<AeronaveViewModel> GetAll()
        {
            var aeronaves = _aeronaveRepository.GetAll().ToList();

            var lstaAronave = new List<AeronaveViewModel>();

            foreach (var item in aeronaves)
            {
                lstaAronave.Add(Mapper<Aeronave, AeronaveViewModel>.CreateMapper(item));
            }
            return lstaAronave;
        }

        public IEnumerable<AeronaveViewModel> GetAll(AeronaveViewModel aeronave)
        {
            var query = _aeronaveRepository.GetAll();

            if (aeronave != null)
            {
                if (aeronave.Id > 0)
                    query = query.Where(x => x.Id == aeronave.Id);

                if (!string.IsNullOrEmpty(aeronave.Modelo))
                    query = query.Where(x => x.Modelo.Trim().ToUpper().Contains(aeronave.Modelo.Trim().ToUpper()));
            }

            var result = new List<AeronaveViewModel>();

            var aeronaves = query.ToList();

            if (aeronaves.Any())
            {
                foreach (var item in aeronaves)
                {
                    result.Add(Mapper<Aeronave, AeronaveViewModel>.CreateMapper(item));
                }
            }

            return result;
        }

        public int Add(AeronaveViewModel aeronaveViewModel)
        {
            var aeronave = Mapper.Map<AeronaveViewModel, Aeronave>(aeronaveViewModel);

            if (aeronaveViewModel.Id == 0)
            {
                _aeronaveRepository.Add(aeronave);
            }

            return aeronave.Id;
        }

        public int Update(AeronaveViewModel aeronaveViewModel)
        {
            var aeronave = Mapper<AeronaveViewModel, Aeronave>.CreateMapper(aeronaveViewModel);

            _aeronaveRepository.Update(aeronave);

            return aeronave.Id;
        }

        public int Delete(int id)
        {
            return _aeronaveRepository.Delete(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}