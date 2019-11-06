using clu.aspnet.webapplication.mvc.core.DataAccess;
using clu.aspnet.webapplication.mvc.core.Models;
using System.Collections.Generic;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.core.unittests.Fakes
{
    public class FakeProductRepository : IProductRepository
    {
        private IQueryable<Product> _products;

        public FakeProductRepository()
        {
            List<Product> products = new List<Product>();

            _products = products.AsQueryable();
        }

        public IQueryable<Product> Products
        {
            get { return _products.AsQueryable(); }
            set { _products = value; }
        }

        public Product Add(Product product)
        {
            List<Product> products = _products.ToList();
            products.Add(product);

            _products = products.AsQueryable();

            return product;
        }

        public Product Delete(Product product)
        {
            List<Product> products = _products.ToList();
            products.Remove(product);

            _products = products.AsQueryable();

            return product;
        }

        public Product FindProductById(int id)
        {
            return _products.First(product => product.Id == id);
        }
    }
}