using clu.aspnet.webapplication.mvc.Models;
using clu.aspnet.webapplication.mvc.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebStoreContext _context;

        //The parameterless version of the constructor is used by the MVC controller factory
        public ProductController()
        {
            //Instantiate an actual Entity Framework context
            _context = new RealWebStoreContext();
        }

        //This constructor is used by unit tests. They pass a test double context
        public ProductController(IWebStoreContext context)
        {
            //Use the context passed to the constructor
            _context = context;
        }

        //Add action methods here
        public ActionResult Index()
        {
            var model = new List<Product>();

            return View(model);
        }
    }
}