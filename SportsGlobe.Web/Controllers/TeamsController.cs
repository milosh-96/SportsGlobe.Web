using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsGlobe.Web.Data;
using SportsGlobe.Web.ViewModels.Teams;

namespace SportsGlobe.Web.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            ViewData["Title"] = "Add a Team";
            AddTeamViewModel viewModel = new AddTeamViewModel();
            viewModel.Sports = _context.Sports.Include(x => x.Stadiums).ToList();
            return View(viewModel);
        }
    }
}
