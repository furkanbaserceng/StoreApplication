using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductService
    {

        IEnumerable<Product> GetAllProducts(bool trackChanges,Expression<Func<Product,bool>> expression=null);
        IEnumerable<Product> GetShowcaseProducts(bool trackChanges);
        Product? Get(int id, bool trackChanges);
        void CreateProduct(ProductDtoForInsertion productDto);
        void UpdateProduct(ProductDtoForUpdate productDto);
        void DeleteProduct(Product product);
        ProductDtoForUpdate GetProductForUpdate(int id, bool trackChanges);
    }
}
