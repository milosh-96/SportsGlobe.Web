using SportsGlobe.Web.Domain;

namespace SportsGlobe.Web.ViewModels.Teams
{
    public class AddTeamViewModel
    {
        public List<Sport> Sports { get; set; } = new List<Sport>();
        public List<Stadium> Stadiums { get; set; } = new List<Stadium>();

        public Sport? SelectedSport { get; set; }
        //
        public string Name { get; set; } = "";
        public string LogoUrl { get; set; } = "";
        public int SelectedSportId { get; set; }
        public int SelectedStadiumId { get; set; }
    }
}
