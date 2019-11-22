using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class VisitCounterController : Controller
    {
        private const string VISIT_COUNT_KEY = "Visit_Count";

        public IActionResult Index()
        {
            int? visitorCount = HttpContext.Session.GetInt32(VISIT_COUNT_KEY);

            if (visitorCount.HasValue)
            {
                visitorCount++;
            }
            else
            {
                visitorCount = 1;
            }

            HttpContext.Session.SetInt32(VISIT_COUNT_KEY, visitorCount.Value);

            return Content(string.Format("Number of visits:{0}", visitorCount));
        }
    }
}