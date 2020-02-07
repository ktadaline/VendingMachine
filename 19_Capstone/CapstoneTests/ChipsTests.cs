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

    }
}
