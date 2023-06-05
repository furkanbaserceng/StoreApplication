using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager,IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
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
            //Product product = new Product()
            //{
            //    ProductName = productDto.ProductName,
            //    CategoryId = productDto.CategoryId,
            //    Price = productDto.Price

            //};

            Product product=_mapper.Map<Product>(productDto);
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
