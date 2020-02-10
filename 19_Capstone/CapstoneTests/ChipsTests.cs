using Capstone;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class ChipsTests
    {
        [TestMethod]
        public void ChipsQuantityLeft()
        {
            //arrange
            Chips chips = new Chips("ChipName", "A1", 1.00M);
            //act
            int ActualValue = chips.QuantityLeft;
            //assert
            Assert.AreEqual(5, ActualValue);
        }
        [TestMethod]
        public void ChipsQuantityLeft2()
        {
            //arrange
            Chips chips = new Chips("ChipName", "A1", 1.00M);
            //act
            chips.QuantitySold++;
            int ActualValue = chips.QuantityLeft;
            //assert
            Assert.AreEqual(4, ActualValue);
        }
        [TestMethod]
        public void ChipsQuantityLeft3()
        {
            //arrange
            Chips chips = new Chips("ChipName", "A1", 1.00M);
            //act
            chips.QuantitySold += 5;
            int ActualValue = chips.QuantityLeft;
            //assert
            Assert.AreEqual(0, ActualValue);
        }

    }
}
