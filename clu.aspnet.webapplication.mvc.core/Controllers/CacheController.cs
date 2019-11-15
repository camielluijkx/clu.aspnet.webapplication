using clu.aspnet.webapplication.mvc.core.Models;
using clu.aspnet.webapplication.mvc.core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class CacheController : Controller
    {
        private IProductService _productService;

        private IMemoryCache _memoryCache;
        private IDistributedCache _distributedCache;

        private const string PRODUCT_KEY = "Products";
        private const string CURRENT_DATE = "TheDate";

        public CacheController(IProductService productService, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _productService = productService;

            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexSingle()
        {
            ViewBag.IsStoreOpen = true;

            Product product = new Product
            {
                Id = 1,
                Name = "Coffee",
                BasePrice = 0.00f
            };

            return View(product);
        }

        public IActionResult IndexMultiple()
        {
            List<Product> products;

            if (!_memoryCache.TryGetValue(PRODUCT_KEY, out products))
            {
                products = _productService.GetProducts();

                _memoryCache.Set(PRODUCT_KEY, products);
            }

            return View(products);
        }

        public IActionResult UsingGetOrCreate()
        {
            List<Product> products = _memoryCache.GetOrCreate(PRODUCT_KEY, entry =>
            {
                return _productService.GetProducts();
            });

            return View(products);
        }

        public IActionResult UsingMemoryCacheEntryOptions()
        {
            List<Product> products;

            if (!_memoryCache.TryGetValue(PRODUCT_KEY, out products))
            {
                products = _productService.GetProducts();

                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions();
                cacheOptions.SetPriority(CacheItemPriority.Low);
                cacheOptions.SetSlidingExpiration(new TimeSpan(6000));

                _memoryCache.Set(PRODUCT_KEY, products, cacheOptions);
            }

            return View(products);
        }

        public IActionResult IndexDistributed()
        {
            string currentTime;

            byte[] value = _distributedCache.Get(CURRENT_DATE);

            if (value != null)
            {
                currentTime = Encoding.UTF8.GetString(value);
            }
            else
            {
                currentTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm");

                DistributedCacheEntryOptions cacheEntryOptions = new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromSeconds(60)
                };

                _distributedCache.Set(CURRENT_DATE, Encoding.UTF8.GetBytes(currentTime), cacheEntryOptions);
            }

            return Content(currentTime);
        }
    }
}