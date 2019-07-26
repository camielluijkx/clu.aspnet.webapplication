using clu.aspnet.webapplication.mvc.net.Controllers;
using clu.aspnet.webapplication.mvc.net.Models;
using clu.aspnet.webapplication.mvc.net.unittests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace clu.aspnet.webapplication.mvc.net.unittests.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void Test_Index_Model_Type()
        {
            //Arrange phase
            var context = new FakeWebStoreContext();
            context.Products = new[] 
            {
                new Product(),
                new Product(),
                new Product()
            }.AsQueryable();

            //Act phase
            var controller = new ProductController(context);
            var result = controller.Index() as ViewResult;

            //Assert phase
            Assert.AreEqual(typeof(List<Product>), result.Model.GetType());
        }
    }
}