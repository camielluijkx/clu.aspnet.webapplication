using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AntiForgeController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ViewUser(string userName)
        {
            return View(userName);

            /*
            
            Post calls to the Index action will require that the user possess a valid anti-forgery token to call this action. Any attempts to access this index from outside a valid form will result in an error instead. 

            */
        }

        public IActionResult Index()
        {
            return View();

            /*
             
            The normal Index action (GET) will work regardless of origin, while both the Index action with a POST method and the RemoveUser action which is a DELETE method will both require the client to utilize anti-forgery tokens. 
            
            */
        }

        [HttpPost]
        //[IgnoreAntiforgeryToken]
        public IActionResult Index(string userName)
        {
            return View("Index", userName);
        }

        [HttpDelete]
        public IActionResult RemoveUser(string userName)
        {
            string url = string.Format("~/RemovedUser/{0}", userName);

            return RedirectToAction("Account", "RemoveUser", "User");
        }
    }
}