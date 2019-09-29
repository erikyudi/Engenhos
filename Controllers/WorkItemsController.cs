using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projetos.Controllers.Resources;
using Projetos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Projetos.Controllers
{
    public class WorkItemsController : Controller
    {
        private readonly EngenhosDbContext context;
        private readonly IMapper mapper;
        public WorkItemsController(EngenhosDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("/api/workitems")]
        public async Task<IEnumerable<WorkItemsResource>> GetWorkItems()
        {
            var workitems = await context.WorkItems.ToListAsync();
            return mapper.Map<List<WorkItems>, List<WorkItemsResource>>(workitems);
        }
    }
}