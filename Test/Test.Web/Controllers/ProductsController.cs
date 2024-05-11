using Microsoft.AspNetCore.Mvc;
using Test.Web.Models;

namespace Test.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductsController()
        {
            _productRepository = new ProductRepository();

            //dummy data ekliyoruz.

            if (!_productRepository.GetAll().Any())
            {
                _productRepository.Add(new() { Id = 1, Name = "Acer", Price = 30,Stock = 0 });
                _productRepository.Add(new() { Id = 1, Name = "Toshiba", Price = 30, Stock = 10 });
                _productRepository.Add(new() { Id = 1, Name = "Asus", Price = 30, Stock = 3 });
                _productRepository.Add(new() { Id = 1, Name = "MSI", Price = 30, Stock = 2 });
                _productRepository.Add(new() { Id = 1, Name = "Apple", Price = 30, Stock = 1 });

            }
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();

            return View(products);
        }
    }
}
