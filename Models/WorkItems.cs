using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projetos.Models
{
    [Table("WorkItems")]
    public class WorkItems
    {
        public Int32? Id { get; set; }
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
