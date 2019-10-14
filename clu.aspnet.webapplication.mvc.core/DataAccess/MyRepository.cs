using clu.aspnet.webapplication.mvc.core.Models;
using System.Collections.Generic;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.core.DataAccess
{
    public class MyRepository : IRepository
    {
        private HrContext _context;

        public MyRepository(HrContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetPeople()
        {
            return _context.Candidates;
        }

        public void InsertPerson()
        {
            var person = new Person
            {
                FirstName = "John",
                LastName = "Smith"
            };

            _context.Candidates.Add(person);
            _context.SaveChanges();
        }

        public void DeletePerson()
        {
            var person = _context.Candidates.FirstOrDefault(c => c.LastName == "Smith");

            _context.Candidates.Remove(person);
            _context.SaveChanges();
        }

        public void UpdatePerson()
        {
            var person = (
                from c in _context.Candidates
                where c.FirstName == "James"
                select c).Single();

            person.FirstName = "Mike";

            _context.SaveChanges();
        }
    }
}