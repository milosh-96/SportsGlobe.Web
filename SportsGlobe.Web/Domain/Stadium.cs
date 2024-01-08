using System.Text.Json.Serialization;

namespace SportsGlobe.Web.Domain
{
    public class Stadium : CoordinatesEntity
    {
        // relationships
        [JsonIgnore]
        public List<Team> Teams { get; set; } = new List<Team>();

        [JsonIgnore]
        public List<Sport> Sports { get; set; } = new List<Sport>();

    }
}
