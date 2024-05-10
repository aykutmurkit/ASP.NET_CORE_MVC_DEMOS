using Microsoft.AspNetCore.Mvc;

namespace Test.Web.Controllers
{
    public class OrnekController : Controller
    {
        // Bu bir ActionResult'dır
        public IActionResult Index()
        {
            ViewBag.name = "Asp.net Core";

            ViewData["age"] = 30;

            ViewData["names"] = new List<string>() {"Ayşe","Fatma","Hayriye"};

            //insan nesnesi gönderme
            ViewBag.person = new { Id = 1, name = "Aykut", age = 28 };

            return View();
        }

        public IActionResult Index2()
        {
            return RedirectToAction("Index"); // ikinci parametresi Controller alıyor ama farklı bir controllera göndermek istersem ("index","Ornek") yapabilirsin.
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
