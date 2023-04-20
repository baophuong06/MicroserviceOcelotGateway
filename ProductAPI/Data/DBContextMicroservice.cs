using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductAPI.Configuration;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Data
{
    public class DBContextMicroservice : DbContext
    {
        protected readonly IConfiguration _configuration;
        public DBContextMicroservice(DbContextOptions<DBContextMicroservice> option,IConfiguration configuration) : base(option)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            var conn = "Server=ADMIN;Database=NgocMicrosevices;Trusted_Connection=True;";

            modelBuilder.UseSqlServer(conn);
        }
        public DbSet<Products> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProductConfiguration());
        }

    }
}
