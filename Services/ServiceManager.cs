using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {

        private readonly IProductService _productService;

        public ServiceManager(IProductService productService)
        {
            _productService = productService;
        }

        public IProductService ProductService => _productService;
    }
}
