using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApuStoreDb.Models;

    public class ApuStoreDbContext : DbContext
    {
        public ApuStoreDbContext (DbContextOptions<ApuStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApuStoreDb.Models.ProductosTipo> ProductosTipo { get; set; } = default!;
    }
