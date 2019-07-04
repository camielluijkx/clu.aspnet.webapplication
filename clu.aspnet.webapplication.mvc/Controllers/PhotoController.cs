using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.Controllers
{
    public class PhotoController : Controller
    {
        // GET: Photo
        public ActionResult Index()
        {
            return View();
        }
    }
}