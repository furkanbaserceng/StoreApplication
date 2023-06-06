using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(

                new Product() { ProductId = 1,CategoryId=2, ProductName = "Computer",ImageUrl="/img/computer.jpg", Price = 18000 },
                new Product() { ProductId = 2, CategoryId = 2, ProductName = "Keyboard", ImageUrl = "/img/keyboard.jpg", Price = 850 },
                new Product() { ProductId = 3, CategoryId = 2, ProductName = "Mouse", ImageUrl = "/img/mouse.jpg", Price = 350 },
                new Product() { ProductId = 4, CategoryId = 2, ProductName = "Monitor", ImageUrl = "/img/monitor.jpg", Price = 1200 },
                new Product() { ProductId = 5, CategoryId = 2, ProductName = "Deck", ImageUrl = "/img/deck.jpg", Price = 30 },

                new Product() { ProductId=6, CategoryId=1, ProductName="Book1", ImageUrl = "/img/kimya.jpg", Price =44},
                new Product() { ProductId=7, CategoryId=1, ProductName="Book2", ImageUrl = "/img/kasem.jpg", Price =55},
                new Product() { ProductId=8, CategoryId=1, ProductName="Book3", ImageUrl = "/img/atlas.jpg", Price =66}


                );
        }
    }
}
