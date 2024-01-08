namespace SportsGlobe.Web.Domain
{
    public class Sport : BaseEntity
    {
        public List<Team> Teams { get; set; } = new List<Team>();
        public List<Stadium> Stadiums { get; set; } = new List<Stadium>();
    }
}
