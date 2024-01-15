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

        public async Task<IActionResult> Get([FromQuery]int? sportId)
        {
            List<Team> teams = new List<Team>();
            IQueryable<Team> query = _dbContext.Teams
                .Include(x => x.Stadium)
                .Include(x => x.Sport);
            if(sportId.HasValue && sportId > 0)
            {
                query = query.Where(x => x.SportId == sportId);
            }
            teams.AddRange(
                await query.ToListAsync());
            return new JsonResult(teams);
        }
    }
}
