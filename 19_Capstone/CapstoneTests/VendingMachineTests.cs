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
        [TestMethod]
        public void StockVendingMachineTest2()
        {
            //Arrange
            VendingMachine vend2 = new VendingMachine();
            IProduct chip = new Chips("Potato Crisps", "A1", 3.05M);
            IProduct gum = new Gum("BubblePop", "A2", 4.05M);
            List<IProduct> productstest = new List<IProduct>();
            string line1 = "A1|Potato Crisps|3.05|Chip";
            string line2 = "A2|BubblePop|4.05|Gum";
            List<string> lines = new List<string>();
            lines.Add(line1);
            lines.Add(line2);
            productstest.Add(chip);
            productstest.Add(gum);

            //Act
            vend2.StockVendingMachine(lines);
            List<IProduct> actualResult = vend2.Products;

            //Assert

            Assert.AreEqual(productstest[1].ProductName, actualResult[1].ProductName);
            Assert.AreEqual(productstest[1].SlotLocation, actualResult[1].SlotLocation);
            Assert.AreEqual(productstest[1].Price, actualResult[1].Price);
            Assert.AreEqual(productstest[1].Message, actualResult[1].Message);
            Assert.AreEqual(productstest[1].QuantityStart, actualResult[1].QuantityStart);
            Assert.AreEqual(productstest[1].QuantityLeft, actualResult[1].QuantityLeft);
            Assert.AreEqual(productstest[1].QuantitySold, actualResult[1].QuantitySold);
        }

        [TestMethod]
        public void StockVendingMachineTest3()
        {
            //Arrange
            VendingMachine vend2 = new VendingMachine();
            IProduct chip = new Chips("Potato Crisps", "A1", 3.05M);
            IProduct gum = new Gum("BubblePop", "A2", 4.05M);
            IProduct drink = new Drink("Orangina", "C2", 5.05M);
            List<IProduct> productstest = new List<IProduct>();
            string line1 = "A1|Potato Crisps|3.05|Chip";
            string line2 = "A2|BubblePop|4.05|Gum";
            string line3 = "C2|Orangina|5.05|Drink";
            List<string> lines = new List<string>();
            lines.Add(line1);
            lines.Add(line2);
            lines.Add(line3);
            productstest.Add(chip);
            productstest.Add(gum);
            productstest.Add(drink);

            //Act
            vend2.StockVendingMachine(lines);
            List<IProduct> actualResult = vend2.Products;

            //Assert

            Assert.AreEqual(productstest[2].ProductName, actualResult[2].ProductName);
            Assert.AreEqual(productstest[2].SlotLocation, actualResult[2].SlotLocation);
            Assert.AreEqual(productstest[2].Price, actualResult[2].Price);
            Assert.AreEqual(productstest[2].Message, actualResult[2].Message);
            Assert.AreEqual(productstest[2].QuantityStart, actualResult[2].QuantityStart);
            Assert.AreEqual(productstest[2].QuantityLeft, actualResult[2].QuantityLeft);
            Assert.AreEqual(productstest[2].QuantitySold, actualResult[2].QuantitySold);
        }
    }
}
