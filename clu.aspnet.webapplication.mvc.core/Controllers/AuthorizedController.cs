using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    [Authorize]
    public class AuthorizedController : Controller
    {
        private readonly UserManager<WebsiteUser> _userManager;

        public AuthorizedController(UserManager<WebsiteUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            WebsiteUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user != null)
            {
                UserDisplayViewModel model = new UserDisplayViewModel
                {
                    UserHandle = user.UserHandle,
                    UserName = user.UserName
                };

                return View(model);
            }

            return View();
        }
    }
}