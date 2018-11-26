using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Aeronave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Modelo { get; set; }

        public int QuantidadeDePassageiros { get; set; }

        public DateTime DataCriacao { get; set; }        
    }
}