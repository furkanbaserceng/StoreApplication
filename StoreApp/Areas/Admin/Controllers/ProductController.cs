using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {

            var products = _manager.ProductService.GetAllProducts(false).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Product product)
        {

            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateProduct(product);
                return RedirectToAction("Index");
                
            } 

            return View(product);
        }
    }
}
