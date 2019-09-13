using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class AnotherController : Controller
    {
        public ContentResult AnotherAction()
        {
            return Content("text from another controller");
        }
    }
}