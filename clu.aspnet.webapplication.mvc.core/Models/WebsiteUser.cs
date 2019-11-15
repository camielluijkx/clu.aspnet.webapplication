using Microsoft.AspNetCore.Identity;

namespace clu.aspnet.webapplication.mvc.core.Models
{
    public class WebsiteUser : IdentityUser
    {
        public string UserHandle { get; set; }
    }
}