using clu.aspnet.webapplication.mvc.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace clu.aspnet.webapplication.mvc.unittests.Models
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void Test_Product_Reviews()
        {
            //Arrange phase
            Product testProduct = new Product();
            testProduct.Type = "CompleteBike";

            //Act phase
            var result = testProduct.GetAccessories();
            
            //Assert phase
            Assert.AreEqual(typeof(List<BikeAccessory>), result.GetType());
        }
    }
}