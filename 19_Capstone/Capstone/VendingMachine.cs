using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {

        public List<IProduct> Products { get; private set; } = new List<IProduct>();
        public decimal Balance { get; set; } = 0;
        public int Count { get; set; }

        public void StockVendingMachine(List<string> input)
        {
            foreach (string str in input)
            {
                string[] arr = str.Split("|");
                string SlotLocation = arr[0];
                string ProductName = arr[1];
                string StringCost = arr[2];
                decimal Cost = decimal.Parse(StringCost);
                string type = arr[3];

                if (type == "Candy")
                {
                    Candy candy = new Candy(ProductName, SlotLocation, Cost);
                    Products.Add(candy);
                }
                if (type == "Chip")
                {
                    Chips chip = new Chips(ProductName, SlotLocation, Cost);
                    Products.Add(chip);
                }
                if (type == "Drink")
                {
                    Drink drink = new Drink(ProductName, SlotLocation, Cost);
                    Products.Add(drink);
                }
                if (type == "Gum")
                {
                    Gum gum = new Gum(ProductName, SlotLocation, Cost);
                    Products.Add(gum);
                }
            }
        }
    }
}
