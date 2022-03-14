using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Identity;
using Persistence.Database.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }
        public DbSet<Product> Products{ get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ClientConfig(modelBuilder.Entity<Client>());
            new ProductConfig(modelBuilder.Entity<Product>());
            new OrderConfig(modelBuilder.Entity<Order>());
            new OrderDetailConfig(modelBuilder.Entity<OrderDetail>());
            

        }

    }
}
