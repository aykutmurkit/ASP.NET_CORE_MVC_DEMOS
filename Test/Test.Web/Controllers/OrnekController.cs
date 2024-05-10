using Microsoft.AspNetCore.Mvc;

namespace Test.Web.Controllers
{

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrnekController : Controller
    {
        // Bu bir ActionResult'dır
        public IActionResult Index()
        {

            var productList = new List<Product>()
            {
                new(){ Id = 1, Name = "Kalem"},
                new(){ Id = 2, Name = "Silgi"},
                new(){ Id = 3, Name = "Defer"}
            };
     
            return View(productList);
        }

        public IActionResult Index2()
        {


            // yada iki method arasnda da veri taşıma için 

            var surname2 = TempData["surname"];
            return View();
        }

        public IActionResult Index3()
        {
            return RedirectToAction("Index"); 
        }

        //------------------------------------------------------------

        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParametre","Ornek",new {id=id});
        }

        public IActionResult JsonResultParametre(int id)
        {
            return Json(new { Id = id }); 
        }

        //-------------------------------------------------------


        // bir contentresult yazalım
        //bunu da url ye yazarsan sana bir string döner sadece
        //https://localhost:44332/Ornek/contentresult yazarsan gelir .
        public IActionResult ContentResult()
        {
            return Content("ContentResult");
        }

        //https://localhost:44332/Ornek/jsonresult
        public IActionResult JsonResult()
        {
            return Json(new {Id=1,name="kalem"}); // isimsiz bir class oluşturuyoruz.
        }

        //hiçbir şey dönmüyorum.
        public IActionResult EmptyResult()
        {
            return new EmptyResult(); 
        }
    }
}
