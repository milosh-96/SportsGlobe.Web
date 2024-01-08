using System.Text.Json.Serialization;

namespace SportsGlobe.Web.Domain
{
    public class Team : CoordinatesEntity
    {
        public string? LogoUrl { get; set; }
        // relationships
        public int StadiumId { get; set; }

        public Stadium? Stadium { get; set; }

        public int SportId { get; set; }
        public Sport? Sport { get; set; }
    }
}
