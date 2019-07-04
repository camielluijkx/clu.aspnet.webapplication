using clu.aspnet.webapplication.mvc.Models;
using clu.aspnet.webapplication.mvc.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebStoreContext _context;

        public ProductController(IWebStoreContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var model = new List<Product>();

            return View(model);
        }
    }
}