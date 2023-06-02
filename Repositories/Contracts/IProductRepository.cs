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

        Product? Get(bool trackChanges, Expression<Func<Product, bool>> expression);


    }
}
