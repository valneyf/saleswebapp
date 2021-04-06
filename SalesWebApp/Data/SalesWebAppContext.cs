using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebApp.Models;

namespace SalesWebApp.Data
{
    public class SalesWebAppContext : DbContext
    {
        public SalesWebAppContext (DbContextOptions<SalesWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebApp.Models.Department> Department { get; set; }
        public DbSet<SalesWebApp.Models.Seller> Seller { get; set; }
        public DbSet<SalesWebApp.Models.SalesRecord> SalesRecord { get; set; }
    }
}
