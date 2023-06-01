﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class RepositoryContext : DbContext
    {

        public DbSet<Product> Products { get; set; }


        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(

                new Product() { ProductId = 1, ProductName = "Computer", Price = 18000 },
                new Product() { ProductId = 2, ProductName = "Keyboard", Price = 850 },
                new Product() { ProductId = 3, ProductName = "Mouse", Price = 350 },
                new Product() { ProductId = 4, ProductName = "Monitor", Price = 1200 },
                new Product() { ProductId = 5, ProductName = "Deck", Price = 30 }
                );
        }







    }
}
