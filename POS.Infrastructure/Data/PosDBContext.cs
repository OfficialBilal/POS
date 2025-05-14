using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Data
{
    public class PosDBContext : DbContext
    {
        public PosDBContext()
        {
            
        }
        public PosDBContext(DbContextOptions<PosDBContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
