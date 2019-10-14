using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.Models
{
    public class Country
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        //public List<City> Cities { get; set; }
        public virtual ICollection<City> Cities { get; set; }

        //public List<Person> People { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}