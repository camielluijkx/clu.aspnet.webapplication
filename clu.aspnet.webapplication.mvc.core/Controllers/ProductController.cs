using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class ProductController : Controller
    {
        #region Example #57

        [Route("Product/Index57")]
        public IActionResult Index57()
        {
            return View();
        }

        #endregion

        #region Example #58

        [Route("Product/Index58")]
        public IActionResult Index58()
        {
            ViewBag.Price = 2;

            return View();
        }

        #endregion

        #region Example #60

        [Route("Product/Index")]
        public IActionResult Index()
        {
            Product p1 = new Product() { Name = "Product1" };
            Product p2 = new Product() { Name = "Product2" };

            List<Product> products = new List<Product>() { p1, p2 };

            return View(products);
        }

        #endregion
    }
}