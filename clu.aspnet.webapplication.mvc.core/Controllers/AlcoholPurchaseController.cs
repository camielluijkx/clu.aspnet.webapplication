using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    [Authorize(Policy = "AtLeast21")]
    public class AlcoholPurchaseController : Controller
    {
        public IActionResult Index() => View();
    }
}