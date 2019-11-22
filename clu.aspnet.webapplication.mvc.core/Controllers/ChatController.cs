using clu.aspnet.webapplication.mvc.core.Services;
using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class ChatController : Controller
    {
        private IChatManager _manager;

        public ChatController(IChatManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.GetUsers());
        }
    }
}