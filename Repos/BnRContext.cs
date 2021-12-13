using BuildNRent.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildNRent.Repos
{
    public class BnRContext : DbContext
    {
        public BnRContext(DbContextOptions<BnRContext> options) : base(options) { }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Renter> Renters { get; set; }
    }
}
