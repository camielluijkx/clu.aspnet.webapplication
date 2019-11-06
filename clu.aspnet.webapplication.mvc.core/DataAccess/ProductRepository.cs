using clu.aspnet.webapplication.mvc.core.Models;
using System;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.core.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        StoreContext _store;

        public ProductRepository(StoreContext store)
        {
            _store = store;
        }

        public IQueryable<Product> Products
        {
            get { return _store.Products; }
        }

        public Product Add(Product product)
        {
            _store.Products.Add(product);
            _store.SaveChanges();

            return _store.Products.Find(product);
        }

        public Product Delete(Product product)
        {
            _store.Products.Remove(product);
            _store.SaveChanges();

            return product;
        }

        public Product FindProductById(int id)
        {
            return _store.Products.First(product => product.Id == id);
        }

        public Product FindProductByComment(string comment)
        {
            try
            {
                return _store.Products.First(product => product.Comment == comment);
            }
            catch (ArgumentNullException ex)
            {
                // Handle the exception

                return null;
            }
        }
    }
}