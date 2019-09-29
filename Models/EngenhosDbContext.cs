using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetos.Models
{
    public class EngenhosDbContext : DbContext
    {
        public EngenhosDbContext(DbContextOptions<EngenhosDbContext> options)
         : base(options)
        { }

        public DbSet<WorkItems> WorkItems { get; set; }
    }
}
