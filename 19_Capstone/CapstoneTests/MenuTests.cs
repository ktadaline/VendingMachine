using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void FeedMenuTest()
        {
            //Arrange
            VendingMachine vend = new VendingMachine();
            Menu menu = new Menu(vend);
            InvalidMoneyTypeException expectedException = null;

            //Act
            try
            {
                menu.FeedMoney("5");
            }
            catch (InvalidMoneyTypeException ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.IsNull(expectedException);
        }
    }


}

