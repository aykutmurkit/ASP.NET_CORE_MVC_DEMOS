﻿using Microsoft.AspNetCore.Mvc;
using Test.Web.Helper;
using Test.Web.Models;

namespace Test.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;
        private AppDbContext _context;
        private IHelper _helper;

        //singleton için constructor injection yapıldır.
        //DI container sadece iki tane enjekte etme yöntemi vardır.
        public ProductsController(AppDbContext context,IHelper helper)
        {   
            //contructor üzerinden oluşturmaya dependency injection denir. nesne örneği alıyoruz.
            //DI Container deniyor buna da
            _context = context;
            _helper = helper;
            _productRepository = new ProductRepository();

        }

        //şimdi method injection yapalım // dı containerden dolduracağm için böyle bir tag var
        public IActionResult Index([FromServices]IHelper helper2)
        {
            var text = "Asp.Net";

            var upperText = _helper.Upper(text);


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

        [HttpPost]
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

            _context.Products.Add(newProduct);

            _context.SaveChanges();
            TempData["status"] = "Ürün Başarıyla eklendi.";
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product updateProduct)
        {

            _context.Products.Update(updateProduct);
            _context.SaveChanges();

            TempData["status"] = "Ürün Başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}
