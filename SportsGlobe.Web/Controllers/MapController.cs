using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsGlobe.Web.Data;
using SportsGlobe.Web.ViewModels.Map;

namespace SportsGlobe.Web.Controllers
{
    public class MapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MapController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            MainMapViewModel viewModel = new MainMapViewModel();
            viewModel.Sports = _context.Sports.Include(x=>x.Teams).Where(x=>x.Teams.Count > 0).ToList();
            ViewData["Sports"] = viewModel.Sports;
            ViewData["Title"] = "Map";
            return View(viewModel);
        }
    }
}
