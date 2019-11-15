using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Encodings.Web;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class AntiScriptController : Controller
    {
        private JavaScriptEncoder _javaScriptEncoder;
        private HtmlEncoder _htmlEncoder;
        private UrlEncoder _urlEncoder;

        public AntiScriptController(HtmlEncoder htmlEncoder, JavaScriptEncoder javaScriptEncoder, UrlEncoder urlEncoder)
        {
            _htmlEncoder = htmlEncoder;
            _javaScriptEncoder = javaScriptEncoder;
            _urlEncoder = urlEncoder;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index() // injecting encoder in controller
        {
            const string xssScript = "<script>alert('XSS')</script>";
            List<string> encodedScripts = new List<string>();
            encodedScripts.Add(_htmlEncoder.Encode(xssScript));
            encodedScripts.Add(_javaScriptEncoder.Encode(xssScript));

            return View("index", encodedScripts);
        }

        public IActionResult Unsafe() // unsafe javascript encoding in corresponding view
        {
            return View();
        }

        public IActionResult Safe() // safe javascript encoding in corresponding view
        {
            return View();
        }

        public IActionResult RemoveUser_(string userName) // potential url xss attack
        {
            string url = string.Format("~/RemovedUser/{0}", userName);

            return Redirect(url);

            /*
            
            In this example, if the username matches a valid relative path in the application, it can potentially cause serious problems. For example a user name such as "../../Account/Logout" would actually redirect the current user to a log out method, requiring them to log back in or even worse, the username could potentially be "../Admin" potentially deleting an administrator's user. 

            */
        }

        public IActionResult RemoveUser(string userName)
        {
            string url = string.Format("~/RemovedUser/{0}", _urlEncoder.Encode(userName));

            return Redirect(url);
        }
    }
}