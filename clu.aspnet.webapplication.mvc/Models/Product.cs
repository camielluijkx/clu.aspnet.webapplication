using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Type { get; set; }

        public IEnumerable<Accessory> GetAccessories()
        {
            if (Type == "CompleteBike")
            {
                return new List<BikeAccessory>();
            }

            return new List<Accessory>();
        }
    }
}