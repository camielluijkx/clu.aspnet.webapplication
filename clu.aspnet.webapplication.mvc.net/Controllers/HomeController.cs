﻿using clu.aspnet.webapplication.mvc.net.Attributes;
using System;
using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.net.Controllers
{
    public class HomeController : BaseController
    {
        [SimpleActionFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HandleError]
        public ActionResult Details()
        {
            throw new NotImplementedException();
            //throw new InvalidOperationException();
        }
    }
}