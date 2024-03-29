﻿using Entities.Dtos;
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
            
            ViewBag.Categories = GetCategoriesSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto,IFormFile file)
        {

            ViewBag.Categories = GetCategoriesSelectList();


            if (ModelState.IsValid)
            {

                //file operations
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file.FileName);
                using(var stream=new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/img/", file.FileName);

                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
                
            } 

            return View(productDto);
        }

        public IActionResult Update([FromRoute] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();

            var productDto = _manager.ProductService.GetProductForUpdate(id, false);

            return View(productDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
        {
            ViewBag.Categories = GetCategoriesSelectList();

            if (ModelState.IsValid)
            {
                //file operations
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file.FileName);
                using(var stream=new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/img/", file.FileName);

                _manager.ProductService.UpdateProduct(productDto);
                return RedirectToAction("Index");

            }
            return View(productDto);
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

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName", "1");
        }

    }
}
