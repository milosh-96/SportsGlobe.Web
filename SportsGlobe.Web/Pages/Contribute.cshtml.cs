using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportsGlobe.Web.Pages
{
    public class ContributeModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Title"] = "Contribute";

        }
    }
}
