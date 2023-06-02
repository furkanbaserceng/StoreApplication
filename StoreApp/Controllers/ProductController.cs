using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        public ProductController(IServiceManager manager) {


            _manager = manager;

        }

        public IActionResult Index()
        {
            var products = _manager.ProductService.GetAllProducts(false);

            return View(products);
        }

        public IActionResult Get([FromRoute(Name ="id")]int id)
        {
            var product = _manager.ProductService.Get(id, false);

            return View(product);

            throw new NotImplementedException();
            
        }


    }
}
