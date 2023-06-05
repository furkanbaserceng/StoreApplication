using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public Product? Get(int id, bool trackChanges)
        {
            var product= _manager.Product.Get(id, trackChanges);
            if(product is null)
            {
                return null;
            }
            return product;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product = new Product()
            {
                ProductName = productDto.ProductName,
                CategoryId = productDto.CategoryId,
                Price = productDto.Price

            };

            _manager.Product.CreateProduct(product);
            _manager.Save();
        }

        public void UpdateProduct(Product product)
        {
            _manager.Product.UpdateProduct(product);
            _manager.Save();
        }

        public void DeleteProduct(Product product)
        {
            _manager.Product.DeleteProduct(product);
            _manager.Save();
        }
    }
}
