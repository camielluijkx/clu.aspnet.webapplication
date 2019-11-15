using clu.aspnet.webapplication.mvc.core.Models;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.core.DataAccess
{
    public interface IProductShop
    {
        List<Product> GetAllProducts();

        Product GetProduct(int productId);

        void PurchaseProduct(int productId);
    }
}