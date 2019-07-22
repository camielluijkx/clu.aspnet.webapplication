using clu.aspnet.webapplication.mvc.Models;
using clu.aspnet.webapplication.mvc.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.unittests.Fakes
{
    public class FakeWebStoreContext : IWebStoreContext
    {
        private class SetMap : KeyedCollection<Type, object>
        {
            public HashSet<T> Use<T>(IEnumerable<T> sourceData)
            {
                var set = new HashSet<T>(sourceData);
                if (Contains(typeof(T)))
                {
                    Remove(typeof(T));
                }
                Add(set);
                return set;
            }

            public HashSet<T> Get<T>() { return (HashSet<T>)this[typeof(T)]; }

            protected override Type GetKeyForItem(object item)
            {
                return item.GetType().GetGenericArguments().Single();
            }
        }

        //This object is a keyed collection we use to mock an entity framework context in memory
        SetMap _map = new SetMap();

        public IQueryable<Product> Products
        {
            get { return _map.Get<Product>().AsQueryable(); }
            set { _map.Use<Product>(value); }
        }

        public T Add<T>(T entity) where T : class
        {
            _map.Get<T>().Add(entity);
            return entity;
        }

        public Product FindProductById(int ID)
        {
            Product item = (from p in this.Products
                            where p.ProductID == ID
                            select p).First();
            return item;
        }

        public T Delete<T>(T entity) where T : class
        {
            _map.Get<T>().Remove(entity);
            return entity;
        }
    }
}