using ConsoleApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEngenhos
{
    public class WorkItemContext: DbContext
    {
        public DbSet<WorkItems> WorkItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=engenhosDataBase;Trusted_Connection=True;");
        }
    }
}
