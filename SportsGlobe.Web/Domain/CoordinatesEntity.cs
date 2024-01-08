using System.ComponentModel.DataAnnotations.Schema;

namespace SportsGlobe.Web.Domain
{
    public class CoordinatesEntity : BaseEntity
    {
        public double? Latitude { get; set; } = 0;
        public double? Longitude { get; set; } = 0;

        private Coordinate coordinate = new Coordinate();

        [NotMapped]
        public Coordinate Coordinate
        {
            get {
                coordinate.Latitude = Latitude.HasValue ? Latitude.Value : 0;
                coordinate.Longitude = Longitude.HasValue ? Longitude.Value : 0;
                return coordinate;
            }
        }

    }
}
