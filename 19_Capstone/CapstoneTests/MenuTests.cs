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
                vend.FeedMoney("7");
            }
            catch (InvalidMoneyTypeException ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.IsNotNull(expectedException);
        }
        [TestMethod]
        public void FeedMenuTest2()
        {
            //Arrange
            VendingMachine vend = new VendingMachine();
            Menu menu = new Menu(vend);
            InvalidMoneyTypeException expectedException = null;

            //Act
            try
            {
                vend.FeedMoney("5");
            }
            catch (InvalidMoneyTypeException ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.IsNull(expectedException);
        }
        [TestMethod]
        public void FeedMenuTest3()
        {
            //Arrange
            VendingMachine vend = new VendingMachine();
            Menu menu = new Menu(vend);
            InvalidMoneyTypeException expectedException = null;

            //Act
            try
            {
                vend.FeedMoney("0");
            }
            catch (InvalidMoneyTypeException ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.IsNotNull(expectedException);
        }
        [TestMethod]
        public void FeedMenuTest4()
        {
            //Arrange
            VendingMachine vend = new VendingMachine();
            Menu menu = new Menu(vend);
            InvalidMoneyTypeException expectedException = null;

            //Act
            try
            {
                vend.FeedMoney("blah");
            }
            catch (InvalidMoneyTypeException ex)
            {
                expectedException = ex;
            }

            //Assert
            Assert.IsNotNull(expectedException);
        }

    }
}

