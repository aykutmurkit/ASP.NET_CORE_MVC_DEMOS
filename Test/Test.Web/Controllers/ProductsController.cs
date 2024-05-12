﻿using Microsoft.AspNetCore.Mvc;
using Test.Web.Models;

namespace Test.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;
        private AppDbContext _context;


        public ProductsController(AppDbContext context)
        {   
            //contructor üzerinden oluşturmaya dependency injection denir. nesne örneği alıyoruz.
            //DI Container deniyor buna da
            _context = context;

            _productRepository = new ProductRepository();

        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
        }

        public IActionResult Remove(int id)
        {

            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SaveProduct(Product newProduct)
        {
            //1. yöntem

            //var name = HttpContext.Request.Form["name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();

            //2. yöntem
            //Product newProduct = new Product()
            //{
            //    Name = Name,
            //    Price = Price,  
            //    Stock = Stock,
            //    Color = Color
            //};

            // get ile yakalama da requesting bodysinde değil de querry stringinde gider. mantıklı değil

            _context.Products.Add(newProduct);

            _context.SaveChanges();

            return View();
        }

        public IActionResult Update(int id)
        {
            return View();
        }
    }
}
