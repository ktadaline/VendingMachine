using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Gum : IProduct
    {
        public int QuantityStart { get; }
        public int QuantitySold { get; set; }
        public int QuantityLeft
        {
            get
            {
                return QuantityStart - QuantitySold;
            }
        }
        public string ProductName { get; }
        public string SlotLocation { get; }
        public decimal Price { get; }

        public string Message { get; }

        public Gum(string productName, string slotLocation, decimal price)
        {
            this.QuantityStart = 5;
            this.ProductName = productName;  
            this.SlotLocation = slotLocation;
            this.Price = price;
            this.Message = "Chew Chew, Yum!";
            this.QuantitySold = 0;
        }

    }
}
