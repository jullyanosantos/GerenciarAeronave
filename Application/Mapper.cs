using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Entities;

namespace Application
{
    public class Mapper<T1, T2>
    {
        public static T2 CreateMapper(T1 obj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());

            var mapper = config.CreateMapper();

            return mapper.Map<T2>(obj);
        }
    }
}