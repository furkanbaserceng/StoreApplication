using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly RepositoryContext _context;
        public ProductController(RepositoryContext context) {


            _context = context;

        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
        }

        public IActionResult Get([FromRoute]int id)
        {
            var product=_context.Products.Find(id);

            return View(product);
        }


    }
}
