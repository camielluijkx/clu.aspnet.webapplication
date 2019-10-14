using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class ConfigController : Controller
    {
        private IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Example #87

        [Route("Config/Index87")]
        public IActionResult Index87()
        {
            //string value = _configuration["firstName"];
            string value = _configuration["address:city"];

            return Content(value);
        }

        #endregion

        #region Example #88

        [Route("Config/Index88")]
        public IActionResult Index88()
        {
            var firstName = _configuration["firstName"];
            var lastName = _configuration["lastName"];

            var age = _configuration["age"];

            return Content($"{firstName} {lastName} is {age} years old");

            /*
             
            The firstName name appears in both the config.json and config.xml files. The reason that the value returned is the value from the config.xml file is because the XML configuration provider is added after the JSON configuration provider. 
            
            */
        }

        #endregion
    }
}