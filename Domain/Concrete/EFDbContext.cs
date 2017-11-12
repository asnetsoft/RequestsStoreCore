using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Domain.Concrete
{
    
    public class EFDbContext : DbContext
    {

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }

        public DbSet<RequestsStore> RequestsStore { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<Statuses> Statuses { get; set; }

    }
}
