using clu.aspnet.webapplication.mvc.Models;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.Repository
{
    public interface IWebStoreContext
    {
        IQueryable<Product> Products { get; }

        T Add<T>(T entity) where T : class;

        Product FindProductById(int ID);

        T Delete<T>(T entity) where T : class;
    }
}