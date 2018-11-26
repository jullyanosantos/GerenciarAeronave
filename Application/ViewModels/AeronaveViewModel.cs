using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class AeronaveViewModel
    {
        public int Id { get; set; }

        public string Modelo { get; set; }

        public int QuantidadeDePassageiros { get; set; }

        public string DataCriacao { get; set; }
    }
}