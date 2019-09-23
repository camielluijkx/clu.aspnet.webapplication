using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class NameController : Controller
    {
        #region Example #59

        [Route("Name/Index")]
        public IActionResult Index()
        {
            ViewBag.Names = new List<string>() { "name1", "name2", "name3" };

            return View();
        }

        #endregion

        #region Example #61

        [Route("Name/AnotherAction")]
        public IActionResult AnotherAction()
        {
            return Content("AnotherAction result");
        }

        #endregion
    }
}