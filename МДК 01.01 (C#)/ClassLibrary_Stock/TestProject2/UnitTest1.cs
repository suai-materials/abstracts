using ClassLibrary_Stock;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProductTest()
        {
            Product product = new Product();
            Product product2 = new Product();
            Assert.AreEqual(product.Name, product2.Name);
        }

        [TestMethod]
        public void ProductToString()
        {
            Product product = new Product("Товар1", "123-123-13", 120, UnitMessure.кг, 1.5f);
            Assert.AreEqual(product.ToString(), "Товар1, 123-123-13, 120, 0, кг, 1/1/0001 12:00:00 AM, 1.5");
        }
    }
}