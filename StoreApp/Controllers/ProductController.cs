using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Repositories;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepositoryManager _manager;
        public ProductController(IRepositoryManager manager) {


            _manager = manager;

        }

        public IActionResult Index()
        {
            var products = _manager.Product.GetAllProducts(false);

            return View(products);
        }

        public IActionResult Get([FromRoute]int id)
        {
            var product = _manager.Product.Get(id, false);

            return View(product);

            throw new NotImplementedException();
            
        }


    }
}
