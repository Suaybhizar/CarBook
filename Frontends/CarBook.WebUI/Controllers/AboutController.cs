using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.V1 = "Hakkımızda";
            ViewBag.V2 = "Vizyonumuz & Misyonumuz";
            return View();
        }
    }
}
