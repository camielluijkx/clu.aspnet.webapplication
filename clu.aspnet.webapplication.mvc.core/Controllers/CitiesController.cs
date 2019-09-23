using clu.aspnet.webapplication.mvc.core.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    [Route("cities")]
    [ServiceFilter(typeof(LogActionFilter))]
    public class CitiesController : Controller
    {
        [HttpGet]
        public IActionResult ListCities()
        {
            var cities = "City 1, City 2, City 3";

            return Content(cities);
        }

        //[HttpGet("/cities/{id}")]
        [HttpGet("{id}")]
        public ActionResult GetCity(int id)
        {
            return Content($"City {id}");
        }
    }
}