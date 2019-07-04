using clu.aspnet.webapplication.mvc.Attributes;
using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.Controllers
{
    public class GeneralPurposeController : Controller
    {
        // GET: GeneralPurpose
        [SimpleActionFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}