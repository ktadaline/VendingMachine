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

    }
}
