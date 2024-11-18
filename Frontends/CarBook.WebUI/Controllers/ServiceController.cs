using CarBook.Dto.ServiceDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {     
        public IActionResult Index()
        {
            ViewBag.V1 = "Hizmetler";
            ViewBag.V2 = "Hizmetlerimiz";
            return View();
        }
    }
}
