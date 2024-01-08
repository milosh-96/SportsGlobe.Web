using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsGlobe.Web.Application;
using SportsGlobe.Web.Data;
using SportsGlobe.Web.Domain;
using SportsGlobe.Web.ViewModels.Stadiums;

namespace SportsGlobe.Web.Controllers
{
    public class StadiumsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StadiumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "All Stadiums";
            var sports = _context.Sports.ToList();
            ViewData["Sports"] = sports;
            return View(_context.Stadiums.Include(x=>x.Sports).Take(100).ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Title"] = "Add new Stadium";
            AddStadiumViewModel viewModel = new AddStadiumViewModel()
            {
                Sports = _context.Sports.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Add([FromForm] AddStadiumViewModel data)
        {
            if(data.SelectedSports.Length == 0)
            {
                throw new Exception("You must choose at least one sport.!");
            }

            // check if sports have valid ids
            var sports = _context.Sports.ToList();
            foreach (int id in data.SelectedSports)
            {
                if (!sports.Any(s => s.Id == id))
                {
                    throw new Exception("Invalid Sports Ids!");
                }
            }

            Coordinate coordinate = CoordinatesService.ParseFromString(data.LatLongInput);
            data.Latitude = coordinate.Latitude;
            data.Longitude = coordinate.Longitude;

            Stadium stadium = new Stadium()
            {
                Name = data.Name.Trim(),
                Latitude = data.Latitude,
                Longitude = data.Longitude,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            
            _context.Stadiums.Add(stadium);
            foreach(int id in data.SelectedSports)
            {
                stadium.Sports.Add(sports.FirstOrDefault(x=>x.Id==id));
            }
            if(_context.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }
            throw new Exception("There was an error!");
        }
    }
}
