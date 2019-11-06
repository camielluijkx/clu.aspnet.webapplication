using clu.aspnet.webapplication.mvc.core.Models;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.core.DataAccess
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        Product Add(Product product);

        Product FindProductById(int id);

        Product Delete(Product product);
    }
}