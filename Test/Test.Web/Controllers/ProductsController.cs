using Microsoft.AspNetCore.Mvc;
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

            //mesela burada any() methodu linq metodudur.
            //başlangıç esnasında product tablosunda kayıt yoksa aşağıdaki nesneleri ekler.
            if (!_context.Products.Any()) 
            {
                _context.Products.Add(new Product() { Name = "Telefon", Price = 30000, Stock = 100, Color="red",Height=20,Width=30});
                _context.Products.Add(new Product() { Name = "Bilgisayar", Price = 30000, Stock = 75 });
                _context.Products.Add(new Product() { Name = "Tablet", Price = 15000, Stock = 50 });

                //save changes demezsen memoryde tutulur bunlar dedikten sonra veritabanına yazılır flush gibi çalışıyor.
                _context.SaveChanges();
            }

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

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            return View();
        }
    }
}
