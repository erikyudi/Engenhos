using AutoMapper;
using Projetos.Models;
using Projetos.Controllers.Resources;

namespace Projetos.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkItems, WorkItemsResource>();
        }
    }
}
