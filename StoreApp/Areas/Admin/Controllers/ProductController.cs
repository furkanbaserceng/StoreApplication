using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var categories = _manager.CategoryService.GetAllCategories(false);
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", "1");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ProductDtoForInsertion productDto)
        {
            var categories = _manager.CategoryService.GetAllCategories(false);
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", "1");


            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
                
            } 

            return View(productDto);
        }

        public IActionResult Update([FromRoute] int id)
        {
            var product = _manager.ProductService.Get(id, false);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.UpdateProduct(product);
                return RedirectToAction("Index");

            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {



            var selectedProduct = _manager.ProductService.Get(id, false);

            if (selectedProduct != null)
            {
                _manager.ProductService.DeleteProduct(selectedProduct);

                return RedirectToAction("Index");
            }

            return RedirectToAction("index");
        }

    }
}
