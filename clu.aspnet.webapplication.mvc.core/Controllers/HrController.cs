using clu.aspnet.webapplication.mvc.core.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class HrController : Controller
    {
        private HrContext _context;

        public HrController(HrContext context)
        {
            _context = context;
        }

        [Route("Hr/Index")]
        public IActionResult Index()
        {
            //var candidates = _context.Candidates.ToList();

            var candidates =
                from c in _context.Candidates
                where c.LastName == "Smith"
                select c;

            return View(candidates);
        }
    }
}