using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsGlobe.Web.Data;
using SportsGlobe.Web.Domain;
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

        [HttpGet]
        public IActionResult Add([FromQuery]AddTeamViewModel queryParams)
        {
            ViewData["Title"] = "Add a Team";
            AddTeamViewModel viewModel = new AddTeamViewModel();
            viewModel.SelectedSportId = queryParams.SelectedSportId;

            IQueryable<Sport> sportsQuery = _context.Sports;
            viewModel.Sports = sportsQuery.ToList();

            if (viewModel.SelectedSportId > 0)
            {
                viewModel.SelectedSport = sportsQuery.Where(x => x.Id == queryParams.SelectedSportId).Include(x => x.Stadiums.OrderBy(x => x.Latitude).ThenBy(x => x.Longitude)).FirstOrDefault();
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add([FromForm]AddTeamViewModel data,int? sportId)
        {
            Team team = new Team()
            {
                Name = data.Name.Trim(),
                SportId = data.SelectedSportId,
                StadiumId = data.SelectedStadiumId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            string logoUrl = "https://uploads.dbmilos.com/sportsglobe/default.png";
            if (!string.IsNullOrEmpty(data.LogoUrl))
            {
                logoUrl = data.LogoUrl.Trim();
            }
            team.LogoUrl = logoUrl;

            _context.Teams.Add(team);
            if(_context.SaveChanges() > 0)
            {
                TempData["Status"] = "Stadium has been added successfully.";
                return RedirectToAction("Add", new { SelectedSportId = data.SelectedSportId });
            }
            throw new Exception("There was an error!");
        }
    }
}
