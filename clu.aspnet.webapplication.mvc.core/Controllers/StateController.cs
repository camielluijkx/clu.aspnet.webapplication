using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index1()
        {
            object tempDataValue = TempData["myKey1"];

            if (tempDataValue != null)
            {
                return Content($"TempData1 exists: {tempDataValue}");
            }

            TempData["myKey1"] = "Temporary Value";

            return Content("TempData1 does not exist!");
        }

        public IActionResult Index2()
        {
            object tempDataValue = TempData["myKey2"];
            TempData.Keep("myKey2");

            if (tempDataValue != null)
            {
                return Content($"TempData2 exists: {tempDataValue}");
            }

            TempData["myKey2"] = "Temporary Value";

            return Content("TempData2 does not exist!");
        }

        public IActionResult Index3()
        {
            object tempDataValue = TempData.Peek("myKey3");

            if (tempDataValue != null)
            {
                return Content($"TempData3 exists: {tempDataValue}");
            }

            TempData["myKey3"] = "Temporary Value";

            return Content("TempData3 does not exist!");
        }
    }
}