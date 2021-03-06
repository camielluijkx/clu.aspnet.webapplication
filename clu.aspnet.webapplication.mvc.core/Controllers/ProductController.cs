﻿using clu.aspnet.webapplication.mvc.core.Attributes;
using clu.aspnet.webapplication.mvc.core.DataAccess;
using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;  
        private IProductShop _productShop;

        #region Example #57

        [Route("Product/Index57")]
        public IActionResult Index57()
        {
            return View();
        }

        #endregion

        #region Example #58

        [Route("Product/Index58")]
        public IActionResult Index58()
        {
            ViewBag.Price = 2;

            return View();
        }

        #endregion

        #region Example #60

        [Route("Product/Index60")]
        public IActionResult Index60()
        {
            Product p1 = new Product() { Name = "Product1" };
            Product p2 = new Product() { Name = "Product2" };

            List<Product> products = new List<Product>() { p1, p2 };

            return View(products);
        }

        #endregion

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _productShop = new ProductShop();
        }

        public ProductController(IProductRepository productRepository, IProductShop productShop)
        {
            _productRepository = productRepository;
            _productShop = productShop;
        }

        public IActionResult Index()
        {
            var products = _productRepository.Products.ToList();

            return View(products);
        }

        [MyExceptionFilter]
        public IActionResult Index(Product product)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }

            return View(product);
        }

        public IActionResult GetAllProducts()
        {
            var allProducts = _productShop.GetAllProducts();

            return View(allProducts);
        }

        public IActionResult GetProductById(int productId)
        {
            var product = _productShop.GetProduct(productId);

            return View(product);
        }

        [Authorize]
        public IActionResult BuyProduct(int productId)
        {
            _productShop.PurchaseProduct(productId);

            return View();
        }
    }
}