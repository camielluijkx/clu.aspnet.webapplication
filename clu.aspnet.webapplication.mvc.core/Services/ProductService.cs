using System.Collections.Generic;
using clu.aspnet.webapplication.mvc.core.Models;

namespace clu.aspnet.webapplication.mvc.core.Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Coffee"
                },
                new Product
                {
                    Name = "Beer"
                }
            };
        }
    }
}