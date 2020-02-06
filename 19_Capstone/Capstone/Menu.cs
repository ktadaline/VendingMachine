using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class Menu
    {
        public VendingMachine  Vend { get; }

        public Menu(VendingMachine vend)
        {
            this.Vend = vend;
        }

        public string DisplayInventory()
        {
            string display = "";
            foreach (IProduct product in Vend.Products)
            {

                if (product.QuantityLeft != 0)
                {

                    display += $"{product.SlotLocation} {product.ProductName} {product.Price:C} {product.QuantityLeft.ToString()} \n";
                }
                else
                {
                    display += $"{product.SlotLocation} {product.ProductName} {product.Price:C} SOLD OUT \n";
                 
                }
            }
            return display;
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to Racoon City's Vendo-Matic 800 \n \n(1) Display Vending Machine Items \n(2) Purchase\n(3) Exit");
            Console.WriteLine();
      

            string input = Console.ReadLine();


            while (input != "3")
            {
                if (input == "1")
                {
                    Console.WriteLine(DisplayInventory());
                }
                else if (input == "2")
                {
                    //Console.WriteLine("Purchase");
                    Console.WriteLine();
                    PurchaseMenu();
                }
                else if (input == "4")
                {
                    Console.WriteLine("Secret Menu: Sales Report");
                }
                else
                {
                    Console.WriteLine("Not a valid input. TRY AGAIN!");
                }
                Console.WriteLine();
                Console.WriteLine("Please make another selection!");
                Console.WriteLine();
                Console.WriteLine("Welcome to Racoon City's Vendo-Matic 800 \n(1) Display Vending Machine Items \n(2) Purchase\n(3) Exit");
                Console.WriteLine();
                input = Console.ReadLine();

            }
            Console.WriteLine("Goodbye");
        }

        public void PurchaseMenu()
        {
            Console.WriteLine("Please make a selection:\n(1) Feed Money\n(2) Select Product\n(3) Finish Transaction");
            Console.WriteLine();
            Console.WriteLine($"Current Money Provided: {Vend.Balance:C}");
            string input = Console.ReadLine();

            while (input != "3")
            {
                if (input == "1")
                {
                    Console.WriteLine("Please insert bills now\n($1, $2, $5 and $10 accepted)");
                    string money = Console.ReadLine();

                    Console.WriteLine();
                    FeedMoney(money);

                }
                else if (input == "2")
                {
                    Console.WriteLine("Make Selection");
                }
                else
                {
                    Console.WriteLine("Not a valid input. TRY AGAIN!");
                }
                Console.WriteLine();
                Console.WriteLine("Please make another selection!");
                Console.WriteLine("Please make a selection:\n(1) Feed Money\n(2) Select Product\n(3) Finish Transaction");

                Console.WriteLine();
                Console.WriteLine($"Current Money Provided: {Vend.Balance:C}");
                Console.WriteLine();


                input = Console.ReadLine();
            }
            //FinishTransaction();

            Console.WriteLine("Goodbye");

            
        }


        public decimal FeedMoney(string money)
        {
            money = money.ToLower();
            if (money == "1" || money == "one" || money == "$1" || money == "1.00" || money == "$1.00")
            {
                Vend.Balance += 1M;
            }
            else if (money == "2" || money == "two" || money == "$2" || money == "2.00" || money == "$2.00")
            {
                Vend.Balance += 2M;
            }
            else if (money == "5" || money == "five" || money == "$5" || money == "5.00" || money == "$5.00")
            {
                Vend.Balance += 5M;
            }
            else if (money == "10" || money == "ten" || money == "$10" || money == "10.00" || money == "$10.00")
            {
                Vend.Balance += 10M;
            }
            else 
            {
                Console.WriteLine("Keep your monopoly money at home!!!");
            }
            Console.WriteLine();
        
            return Vend.Balance;
        }
        //public IProduct SelectProduct()
        //{ 
        //}
        //public decimal FinishTransaction()
        //{
            
        //}



    }
}

