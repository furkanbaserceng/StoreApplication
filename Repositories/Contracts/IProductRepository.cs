﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAllProducts(bool trackChanges,Expression<Func<Product,bool>> expression=null);
        IQueryable<Product> GetShowcaseProducts(bool trackChanges);
        Product? Get(int id, bool trackChanges);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
