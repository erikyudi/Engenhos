using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp
{
    
    public class WorkItems
    {
        public Int64? Id { get; set; }
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
