using Microsoft.AspNetCore.Mvc;

namespace Test.Web.Controllers
{
    public class OrnekController : Controller
    {
        // Bu bir ActionResult'dır
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return RedirectToAction("Index"); // ikinci parametresi Controller alıyor ama farklı bir controllera göndermek istersem ("index","Ornek") yapabilirsin.
        }




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
