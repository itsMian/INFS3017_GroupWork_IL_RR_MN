using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Burger20106733.Models;

namespace Burger20106733.Data
{
    public class Burger20106733Context : DbContext
    {
        public Burger20106733Context (DbContextOptions<Burger20106733Context> options)
            : base(options)
        {
        }

        public DbSet<Burger20106733.Models.Burger> Burger { get; set; } = default!;

        public DbSet<Burger20106733.Models.Customer> Customer { get; set; }
    }
}
