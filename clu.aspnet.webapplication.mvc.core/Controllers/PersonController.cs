using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class PersonController : Controller
    {
        [Route("Person/GetName")]
        [HttpGet]
        public IActionResult GetName()
        {
            return View();

            //https://localhost:44395/Person/GetName         : form with two labels + text boxes and submit button
        }

        [Route("Person/GetName")]
        [HttpPost]
        public IActionResult GetName(Person person)
        {
            return View("ShowName", person);

            //https://localhost:44395/Person/GetName        : Hello first name last name is shown
        }

        [HttpGet]
        public IActionResult Index()
        {
            // TODO: Add logic here
            var people = new List<Person>();

            return View(people);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // TODO: Add logic here
            var person = new Person();

            return View(person);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // TODO: Add logic here

            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            // TODO: Add logic here

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // TODO: Add logic here
            var person = new Person();

            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(int id, Person person)
        {
            // TODO: Add logic here

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // TODO: Add logic here
            var person = new Person();

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add logic here

            return RedirectToAction("Index");
        }

        [Route("Person/GetDetails")]
        public IActionResult GetDetails()
        {
            return View();
        }

        //[Route("Person/ShowDetails")]
        //public IActionResult ShowDetails()
        //{
        //    Person person = new Person
        //    {
        //        FirstName = "James",
        //        LastName = "Smith",
        //        ContactMe = true
        //    };

        //    return View(person);
        //}

        [Route("Person/ShowDetails")]
        public IActionResult ShowDetails(Person person)
        {
            return View(person);
        }
    }
}