namespace SportsGlobe.Web.Domain
{
    public class Coordinate
    {
        public double Latitude { get; set; } = 0;    
        public double Longitude { get; set; } = 0;

        public override string ToString()
        {
            return string.Format("{0}, {1}",Latitude,Longitude);
        }
    }
}
