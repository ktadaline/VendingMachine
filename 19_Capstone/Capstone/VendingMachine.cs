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

        public decimal FeedMoney(string money)
        {

            decimal dollarsAdded = 0M;

            money = money.ToLower();

            if (money == "1" || money == "one" || money == "$1" || money == "1.00" || money == "$1.00")
            {

                dollarsAdded = 1M;
            }
            else if (money == "2" || money == "two" || money == "$2" || money == "2.00" || money == "$2.00")
            {
                dollarsAdded = 2M;

            }
            else if (money == "5" || money == "five" || money == "$5" || money == "5.00" || money == "$5.00")
            {
                dollarsAdded = 5M; ;

            }
            else if (money == "10" || money == "ten" || money == "$10" || money == "10.00" || money == "$10.00")
            {
                dollarsAdded = 10M;
            }
            else
            {
                throw new InvalidMoneyTypeException();
            }

            Balance += dollarsAdded;

            return Balance;
        }

    }
}
