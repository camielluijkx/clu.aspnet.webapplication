using clu.aspnet.webapplication.mvc.core.Models;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.DataAccess
{
    public interface IRepository
    {
        IEnumerable<Person> GetPeople();

        void InsertPerson();

        void DeletePerson();

        void UpdatePerson();
    }
}