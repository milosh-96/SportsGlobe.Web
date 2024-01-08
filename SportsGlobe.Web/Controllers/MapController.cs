using Microsoft.AspNetCore.Mvc;

namespace SportsGlobe.Web.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Map";
            return View();
        }
    }
}
