using clu.aspnet.webapplication.mvc.core.Exceptions;

namespace clu.aspnet.webapplication.mvc.core.Models
{
    public class Product
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public float BasePrice { get; set; }

        public string Comment { get; set; }

        public float GetPriceWithTax(float taxPercent)
        {
            if (taxPercent < 0)
            {
                throw new InvalidTaxException();
            }

            return BasePrice + (BasePrice * (taxPercent / 100));
        }
    }
}