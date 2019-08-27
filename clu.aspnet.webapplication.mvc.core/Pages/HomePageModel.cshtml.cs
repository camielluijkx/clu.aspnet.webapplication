using Microsoft.AspNetCore.Mvc.RazorPages;

namespace clu.aspnet.webapplication.mvc.core.Pages
{
    public class HomePageModel : PageModel
    {
        public string Description { get; set; }
        public string MoreInfo { get; set; }

        public void OnGet()
        {
            Description = "Your application description is here.";
            MoreInfo = "Your application extra information is here.";
        }
    }
}