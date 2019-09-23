using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class PhotoController : Controller
    {
        [Route("Photo/Choose")]
        public IActionResult Choose()
        {
            return View();
        }

        [Route("Photo/Display/{id}")]
        public IActionResult Display(int id)
        {
            string res = $"Photo number {id} was chosen";

            return Content(res);
        }

        public IActionResult GetImage(int id)
        {
            string path = "images/test.jpg";

            return File(path, "image/jpeg");
        }
    }
}