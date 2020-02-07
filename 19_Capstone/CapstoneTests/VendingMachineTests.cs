using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
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
    }
}
