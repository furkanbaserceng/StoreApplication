using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


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

            modelBuilder.Entity<Category>().HasData(

                new Category() { CategoryId=1,CategoryName="Books"},
                new Category() { CategoryId=2,CategoryName="Electronics"}

                );

        }







    }
}
