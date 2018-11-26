using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AeronaveContext context)
        {
            if (context.Aeronaves.Any())
            {
                return;
            }

            var aeronaves = new Domain.Entities.Aeronave[]
             {
                 new Domain.Entities.Aeronave{ Id= 1, DataCriacao = new DateTime(1991, 12, 01), Modelo = "Boeing 737"},
                 new Domain.Entities.Aeronave{ Id= 2, DataCriacao = new DateTime(1980, 12, 01), Modelo = "Boeing 222"},
                 new Domain.Entities.Aeronave{ Id= 3, DataCriacao = new DateTime(1985, 12, 01), Modelo = "Boeing 333"},
             };

            foreach (var item in aeronaves)
            {
                context.Add(item);
            }
            context.SaveChanges();
        }
    }
}