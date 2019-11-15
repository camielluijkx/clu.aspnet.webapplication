using System.Collections.Generic;
using clu.aspnet.webapplication.mvc.core.Models;

namespace clu.aspnet.webapplication.mvc.core.DataAccess
{
    public class ProductShop : IProductShop
    {
        public List<Product> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }

        public Product GetProduct(int productId)
        {
            throw new System.NotImplementedException();
        }

        public void PurchaseProduct(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}