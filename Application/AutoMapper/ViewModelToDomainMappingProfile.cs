using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AeronaveViewModel, Aeronave>()
                //.ForMember(d => d.DataCriacao, o => o.MapFrom(x => DateTime.ParseExact(x.DataCriacao, "ddMMyyyy", System.Globalization.CultureInfo.InstalledUICulture)));
                .ForMember(d => d.DataCriacao, o => o.MapFrom(x => DateTime.Now));

        }
    }
}