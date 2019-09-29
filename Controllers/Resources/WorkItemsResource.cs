using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetos.Controllers.Resources
{
    public class WorkItemsResource
    {
        public Int64 Id { get; set; }
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
