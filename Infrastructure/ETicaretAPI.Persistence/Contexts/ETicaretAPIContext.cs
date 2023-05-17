﻿using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIContext : DbContext
    {
        public ETicaretAPIContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.CreatedDate = DateTime.UtcNow;
                }
                if(item.State==EntityState.Modified)
                {
                    item.Entity.UpdatedDate = DateTime.UtcNow;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
