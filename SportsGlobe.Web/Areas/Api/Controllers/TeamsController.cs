using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsGlobe.Web.Data;
using SportsGlobe.Web.Domain;

namespace SportsGlobe.Web.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TeamsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Get()
        {
            List<Team> teams = new List<Team>();
            teams.AddRange(await _dbContext.Teams.Include(x=>x.Stadium).ToListAsync());
            return new JsonResult(teams);
        }
    }
}
