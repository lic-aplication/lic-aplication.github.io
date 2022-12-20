using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreCodeBased.Models;

namespace CoreCodeBased.Models
{
    public class CoreCodeBasedContext : DbContext
    {
        public CoreCodeBasedContext (DbContextOptions<CoreCodeBasedContext> options)
            : base(options)
        {
        }

        public DbSet<CoreCodeBased.Models.Department> Department { get; set; }

        public DbSet<CoreCodeBased.Models.Employee> Employee { get; set; }
    }
}
