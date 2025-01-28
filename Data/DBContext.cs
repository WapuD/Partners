using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Partner_API.Data.Models;

namespace Partner_API.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Partner_API.Data.Models.Order> Order { get; set; } = default!;
        public DbSet<Partner_API.Data.Models.Partner> Partner { get; set; } = default!;
        public DbSet<Partner_API.Data.Models.Product> Product { get; set; } = default!;
        public DbSet<Partner_API.Data.Models.ProductType> ProductType { get; set; } = default!;
        public DbSet<Partner_API.Data.Models.Material> Material { get; set; } = default!;
    }
}
