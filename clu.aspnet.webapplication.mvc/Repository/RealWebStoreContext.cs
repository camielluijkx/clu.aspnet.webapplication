using clu.aspnet.webapplication.mvc.Models;
using System.Data.Entity;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.Repository
{
    public class RealWebStoreContext : DbContext, IWebStoreContext
    {
        public DbSet<Product> Products { get; set; }

        IQueryable<Product> IWebStoreContext.Products
        {
            get
            {
                return Products;
            }
        }

        T IWebStoreContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        Product IWebStoreContext.FindProductById(int ID)
        {
            return Set<Product>().Find(ID);
        }

        T IWebStoreContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }
    }
}