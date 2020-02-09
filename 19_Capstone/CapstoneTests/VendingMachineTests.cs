using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void FeedMenuTest()
        {
            //Arrange
            VendingMachine vend = new VendingMachine();
            //Menu menu = new Menu(vend);

            //Act

            Assert.ThrowsException<InvalidMoneyTypeException>(
                () => vend.FeedMoney("8")
                );
        }

        [TestMethod]
        public void StockVendingMachineTest()
        {
            //Arrange
            VendingMachine vend2 = new VendingMachine();  
            IProduct chip = new Chips("Potato Crisps", "A1", 3.05M);
            List<IProduct> productstest = new List<IProduct>();
            string line1 = "A1|Potato Crisps|3.05|Chip"; 
            //string line2 = "A2 | Potato Crispies | 4.05 | Gum";
            List<string> lines = new List<string>();
            lines.Add(line1);
            productstest.Add(chip);

            //Act
            vend2.StockVendingMachine(lines);
            List<IProduct>  actualResult = vend2.Products;


            //Assert

            Assert.AreEqual(productstest[0].ProductName, actualResult[0].ProductName);
            Assert.AreEqual(productstest[0].SlotLocation, actualResult[0].SlotLocation);
            Assert.AreEqual(productstest[0].Price, actualResult[0].Price);
            Assert.AreEqual(productstest[0].Message, actualResult[0].Message);
            Assert.AreEqual(productstest[0].QuantityStart, actualResult[0].QuantityStart);
            Assert.AreEqual(productstest[0].QuantityLeft, actualResult[0].QuantityLeft);
            Assert.AreEqual(productstest[0].QuantitySold, actualResult[0].QuantitySold);
        }
    }
}
