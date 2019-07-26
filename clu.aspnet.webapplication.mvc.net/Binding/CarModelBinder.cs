using clu.aspnet.webapplication.mvc.net.Models;
using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.net.Binding
{
    public class CarModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //Get the color for the car from the request form
            string color = controllerContext.HttpContext.Request.Form["color"];
            //Get the brand for the car from the request form
            string brand = controllerContext.HttpContext.Request.Form["brand"];

            //Create a new instance of the car model
            Car newCar = new Car();
            newCar.Color = color;
            newCar.Brand = brand;

            //return the car
            return newCar;
        }

    }
}