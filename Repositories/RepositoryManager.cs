using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;

        public RepositoryManager(RepositoryContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public IProductRepository Product => _productRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
