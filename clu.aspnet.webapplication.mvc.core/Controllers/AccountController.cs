using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<WebsiteUser> _signInManager;
        private readonly UserManager<WebsiteUser> _userManager;

        public AccountController(SignInManager<WebsiteUser> signInManager, UserManager<WebsiteUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

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

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, true); // enabling lockout

                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View();
        }

        public IActionResult Logout()
        
{
            if (User.Identity.IsAuthenticated)
            {
                _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                WebsiteUser user = new WebsiteUser
                {
                    UserHandle = model.UserHandle,
                    UserName = model.Username,
                    // no password
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return await Login(model);
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterWithRole(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                WebsiteUser user = new WebsiteUser
                {
                    UserHandle = model.UserHandle,
                    UserName = model.Username,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var addedUser = await _userManager.FindByNameAsync(model.Username);

                    await _userManager.AddToRoleAsync(addedUser, "Administrator");
                    await _userManager.AddToRoleAsync(addedUser, "User");

                    return await Login(model);
                }
            }

            return View();
        }

        [Authorize(Roles = "Administrator, Manager")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterWithClaim(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                WebsiteUser user = new WebsiteUser
                {
                    UserHandle = model.UserHandle,
                    UserName = model.Username,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var addedUser = await _userManager.FindByNameAsync(model.Username);

                    if (!string.IsNullOrWhiteSpace(model.Email))
                    {
                        Claim claim = new Claim(ClaimTypes.Email, model.Email);

                        await _userManager.AddClaimAsync(addedUser, claim);
                    }

                    return await Login(model);
                }
            }

            return View();
        }

        [Authorize(Policy = "RequireEmail")]
        [Authorize(Roles = "Administrator")]
        public IActionResult DoSomething()
        {
            return View();
        }
    }
}