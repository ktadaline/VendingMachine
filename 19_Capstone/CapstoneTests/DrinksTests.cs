using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class DrinksTests
    {
         [TestMethod]
         public void DrinksQuantityLeft()
         {
            //arrange
            Drink drinks = new Drink("DrinksName", "A1", 1.00M);
            //act
            int ActualValue = drinks.QuantityLeft;
            //assert
            Assert.AreEqual(5, ActualValue);
         }

         [TestMethod]
         public void DrinksQuantityLeft2()
         {
            //arrange
            Drink drinks = new Drink("DrinksName", "A1", 1.00M);
            //act
            drinks.QuantitySold++;
            int ActualValue = drinks.QuantityLeft;
            //assert
            Assert.AreEqual(4, ActualValue);
         }
         [TestMethod]
         public void DrinksQuantityLeft3()
         {
            //arrange
            Drink drinks = new Drink("DrinksName", "A1", 1.00M);
            //act
            drinks.QuantitySold += 5;
            int ActualValue = drinks.QuantityLeft;
            //assert
            Assert.AreEqual(0, ActualValue);
         }

    }
}
