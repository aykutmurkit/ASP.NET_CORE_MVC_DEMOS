using Microsoft.AspNetCore.Mvc;

namespace Test.Web.Controllers
{
    public class OrnekController : Controller
    {
        // Bu bir ActionResult'dır
        public IActionResult Index()
        {
            TempData["surname"] = "mürkit";
            return View();
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
