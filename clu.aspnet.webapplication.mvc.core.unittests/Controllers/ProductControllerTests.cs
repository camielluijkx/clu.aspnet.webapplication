using clu.aspnet.webapplication.mvc.core.Controllers;
using clu.aspnet.webapplication.mvc.core.DataAccess;
using clu.aspnet.webapplication.mvc.core.Models;
using clu.aspnet.webapplication.mvc.core.unittests.Fakes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace clu.aspnet.webapplication.mvc.core.unittests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void IndexModelShouldBeListOfProducts_UsingFake()
        {
            // Arrange
            var productRepository = new FakeProductRepository();
            productRepository.Products = new List<Product> { new Product(), new Product(), new Product() }.AsQueryable();
            var productController = new ProductController(productRepository);

            // Act
            var result = productController.Index() as ViewResult;

            // Assert
            Assert.AreEqual(typeof(List<Product>), result.Model.GetType());
        }

        [TestMethod]
        public void IndexModelShouldBeListOfProducts_UsingMoq()
        {
            // Arrange
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.SetupGet(repos => repos.Products).Returns(new[] { new Product(), new Product(), new Product() }.AsQueryable());
            var repository = productRepositoryMock.Object;
            var productController = new ProductController(repository);

            // Act
            var result = productController.Index() as ViewResult;

            // Assert
            Assert.AreEqual(typeof(List<Product>), result.Model.GetType());
        }
    }
}