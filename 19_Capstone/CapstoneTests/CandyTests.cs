using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class CandyTests
    {
        [TestMethod]
        public void CandyQuantityLeft()
        {
            //arrange
            Candy candy = new Candy("CandyName", "A1", 1.00M);
            //act
            int ActualValue = candy.QuantityLeft;
            //assert
            Assert.AreEqual(5, ActualValue);
        }
    }
}
