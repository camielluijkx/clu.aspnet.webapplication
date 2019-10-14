using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.Models
{
    public class City
    {
        public int CityId { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public int CountryId { get; set; }

        //public Country Country { get; set; }
        public virtual Country Country { get; set; }

        //public List<Person> People { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}