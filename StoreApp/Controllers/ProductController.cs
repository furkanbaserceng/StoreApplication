﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
