using SportsGlobe.Web.Domain;

namespace SportsGlobe.Web.ViewModels.Stadiums
{
    public class AddStadiumViewModel
    {
        // 
        public List<Sport> Sports { get; set; } = new List<Sport>();
        public string Name { get; set; } = "";
        public int[] SelectedSports { get; set; } = {};

        public string LatLongInput { get; set; } = "0, 0";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
