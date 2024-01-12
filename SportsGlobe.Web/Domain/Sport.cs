using System.Text.Json.Serialization;

namespace SportsGlobe.Web.Domain
{
    public class Sport : BaseEntity
    {
        [JsonIgnore]
        public List<Team> Teams { get; set; } = new List<Team>();

        [JsonIgnore]
        public List<Stadium> Stadiums { get; set; } = new List<Stadium>();
    }
}
