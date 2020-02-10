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


        [TestMethod]
        public void CandyQuantityLeft2()
        {
            //arrange
            Candy candy = new Candy("CandyName", "A1", 1.00M);
            //act

            candy.QuantitySold++;
            int ActualValue = candy.QuantityLeft;
            //assert
            Assert.AreEqual(4, ActualValue);
        }

        [TestMethod]
        public void CandyQuantityLeft3()
        {
            //arrange
            Candy candy = new Candy("CandyName", "A1", 1.00M);
            //act

            candy.QuantitySold+=5;
            int ActualValue = candy.QuantityLeft;
            //assert
            Assert.AreEqual(0, ActualValue);
        }
    }
}
