using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

       
        public IQueryable<Product> GetAllProducts(bool trackChanges, Expression<Func<Product,bool>> expression = null)
        {
            if (trackChanges != true)
            {
                if(expression != null)
                {
                    return GetAll(false,expression);
                }
                return GetAll(false);
            }
            else
            {
                if (expression != null)
                {
                    return GetAll(true,expression);
                }
                return GetAll(true);
            }
        }

        public Product? Get(int id, bool trackChanges)
        {
            

            return GetByCondition(trackChanges, p=>p.ProductId.Equals(id));

        }

        public void CreateProduct(Product product) => Create(product);
       

        public void UpdateProduct(Product product) => Update(product);
        
    }
}
