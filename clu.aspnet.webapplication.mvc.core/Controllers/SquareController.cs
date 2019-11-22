using clu.aspnet.webapplication.mvc.core.Services;
using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class SquareController : Controller
    {
        private ISquareManager _manager;

        public SquareController(ISquareManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.GetSquares());
        }
    }
}