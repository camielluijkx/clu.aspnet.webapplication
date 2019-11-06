using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace clu.aspnet.webapplication.mvc.core.unittests.Models
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TaxShouldCalculateCorrectly()
        {
            // Arrange
            Product product = new Product();
            product.BasePrice = 10;

            // Act
            float result = product.GetPriceWithTax(10);

            // Assert
            Assert.AreEqual(11, result);
        }
    }
}