using clu.aspnet.webapplication.mvc.core.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class HrController : Controller
    {
        //private HrContext _context;
        private IRepository _repository;

        //public HrController(HrContext context)
        //{
        //    _context = context;
        //}

        public HrController(IRepository repository)
        {
            _repository = repository;
        }

        //[Route("Hr/Index")]
        //public IActionResult Index()
        //{
        //    //var candidates = _context.Candidates.ToList();

        //    var candidates =
        //        from c in _context.Candidates
        //        where c.LastName == "Smith"
        //        select c;

        //    return View(candidates);
        //}

        [Route("Hr/Index")]
        public IActionResult Index()
        {
            var list = _repository.GetPeople();

            return View(list);
        }

        [Route("Hr/Insert")]
        public IActionResult Insert()
        {
            _repository.InsertPerson();

            return RedirectToAction("Index");
        }

        [Route("Hr/Delete")]
        public IActionResult Delete()
        {
            _repository.DeletePerson();

            return RedirectToAction("Index");
        }

        [Route("Hr/Update")]
        public IActionResult Update()
        {
            _repository.UpdatePerson();

            return RedirectToAction("Index");
        }
    }
}