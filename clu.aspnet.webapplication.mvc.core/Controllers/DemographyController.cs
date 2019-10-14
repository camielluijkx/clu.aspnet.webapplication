using clu.aspnet.webapplication.mvc.core.DataAccess;
using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class DemographyController : Controller
    {
        private DemographyContext _context;

        public DemographyController(DemographyContext context)
        {
            _context = context;
        }

        #region Example #81

        [Route("Demography/Index81")]
        public IActionResult Index81()
        {
            var city = _context.Cities
                .Single(c => c.CityId == 1);

            _context.Entry(city)
                .Collection(c => c.People)
                .Load();

            _context.Entry(city)
                .Reference(c => c.Country)
                .Load();

            return View(city);

            /*
            
            In the preceding code, when the city variable is initialized, its People property is null. Only after the first call to the Load method is completed does the People property contain a list of people who live in the city. Similarly, when the city variable is initialized, its Country property is null. Only after the second call to the Load method is completed does the Country property contain the country to which the city belongs. 

            */
        }

        #endregion

        #region Example #82

        [Route("Demography/Index82")]
        public IActionResult Index82()
        {
            var city = _context.Cities
                .Single(c => c.CityId == 1);

            int num = _context.Entry(city)
                .Collection(c => c.People)
                .Query()
                .Count();

            return View(city);

            /*
      
            You can also use the explicit loading ORM pattern in conjunction with LINQ. To do so, you should first call the Query method, and then you can call the LINQ methods such as Count and Where.

            */
        }

        #endregion

        #region Example #83

        [Route("Demography/Index83")]
        public IActionResult Index83()
        {
            var cities = _context.Cities
                .Include(c => c.People)
                .Include(c => c.Country)
                .ToList();

            return View(cities);
        }

        #endregion

        #region Example #84

        [Route("Demography/Index84")]
        public IActionResult Index84()
        {
            var countries = _context.Countries
                .Include(country => country.Cities)
                    .ThenInclude(city => city.People)
                .ToList();

            return View(countries);
        }

        #endregion

        #region Example #86

        [Route("Demography/Index86")]
        public IActionResult Index86()
        {
            City city = _context.Cities.First(c => c.CityId == 1);

            int numOfPeople = city.People.Count;

            Country country = city.Country;

            return View(country);
        }

        #endregion

        public IActionResult Create()
        {
            var person = new Person
            {
                FirstName = "Nathan",
                LastName = "Owen"
            };

            _context.Add(person);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var person = _context.People.SingleOrDefault(m => m.PersonId == id);

            _context.People.Remove(person);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var person = _context.People.SingleOrDefault(m => m.PersonId == id);
            person.FirstName = "Brandon";

            _context.Update(person);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}