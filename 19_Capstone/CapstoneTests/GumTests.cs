using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class GumTests
    {
        [TestMethod]
        public void GumQuantityLeft()
        {
            //arrange
            Gum gum = new Gum("GumName", "A1", 1.00M);
            //act
            int ActualValue = gum.QuantityLeft;
            //assert
            Assert.AreEqual(5, ActualValue);
        }
        [TestMethod]
        public void GumQuantityLeft2()
        {
            //arrange
            Gum gum = new Gum("GumName", "A1", 1.00M);
            //act
            gum.QuantitySold++;
            int ActualValue = gum.QuantityLeft;
            //assert
            Assert.AreEqual(4, ActualValue);
        }
        [TestMethod]
        public void GumQuantityLeft3()
        {
            //arrange
            Gum gum = new Gum("GumName", "A1", 1.00M);
            //act
            gum.QuantitySold += 5;
            int ActualValue = gum.QuantityLeft;
            //assert
            Assert.AreEqual(0, ActualValue);
        }

    }
}
