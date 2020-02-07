using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class Menu
    {
        public VendingMachine Vend { get; }

        public Menu(VendingMachine vend)
        {
            this.Vend = vend;
        }
        List<string> TransactionList = new List<string>();
        List<string> SalesReportList = new List<string>();

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
                    SelectProduct();
                }
                else if (input == "4")
                {
                    SalesReport();
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
            FinishTransaction();
            Console.WriteLine("Goodbye.");


        }


        public decimal FeedMoney(string money)
        {
            money = money.ToLower();
            if (money == "1" || money == "one" || money == "$1" || money == "1.00" || money == "$1.00")
            {
                Vend.Balance += 1M;
                TransactionList.Add($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} FEED MONEY: $1.00 {Vend.Balance:C}");
            }
            else if (money == "2" || money == "two" || money == "$2" || money == "2.00" || money == "$2.00")
            {
                Vend.Balance += 2M;
                TransactionList.Add($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} FEED MONEY: $2.00 {Vend.Balance:C}");
            }
            else if (money == "5" || money == "five" || money == "$5" || money == "5.00" || money == "$5.00")
            {
                Vend.Balance += 5M;
                TransactionList.Add($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} FEED MONEY: $5.00 {Vend.Balance:C}");
            }
            else if (money == "10" || money == "ten" || money == "$10" || money == "10.00" || money == "$10.00")
            {
                Vend.Balance += 10M;
                TransactionList.Add($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} FEED MONEY: $10.00 {Vend.Balance:C}");
            }
            else
            {
                Console.WriteLine("Keep your monopoly money at home!!!");
            }
            Console.WriteLine();

            return Vend.Balance;
        }
        public void SelectProduct()
        {
            Console.WriteLine(DisplayInventory());
            Console.WriteLine("Make Selection:");
            string input = Console.ReadLine();
            foreach (IProduct product in Vend.Products)
            {
                if (input.ToUpper() == product.SlotLocation)
                {
                    if (Vend.Balance >= product.Price)
                    {
                        product.QuantitySold++;
                        Vend.Balance -= product.Price;
                        Console.WriteLine(product.Message);
                        TransactionList.Add($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} {product.ProductName} {product.SlotLocation} {Vend.Balance + product.Price:C} {Vend.Balance:C}");
                    }
                    else
                    {
                        Console.WriteLine("To make this selection, you need to enter more money!");
                    }

                }
            }
        }
        public void FinishTransaction()
        {
            TransactionList.Add($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} GIVE CHANGE: {Vend.Balance} $0.00");
            int quarters = (int)(Vend.Balance / .25m);
            Vend.Balance -= quarters * .25m;
            int dimes = (int)(Vend.Balance / .1m);
            Vend.Balance -= dimes * .1m;
            int nickels = (int)(Vend.Balance / .05m);
            Vend.Balance -= nickels * .05m;

            if (quarters > 0)
            {
                Console.WriteLine($"Dispensing {quarters} quarter(s).");
            }
            if (dimes > 0)
            {
                Console.WriteLine($"Dispensing {dimes} dime(s).");
            }
            if (nickels > 0)
            {
                Console.WriteLine($"Dispensing {nickels} nickel(s).");
            }
            Console.WriteLine("\nThank you for using Racoon City's Vendo-Matic 800!");
            AuditEntry();
        }
        public void SalesReport()
        {
            foreach (IProduct product in Vend.Products)
            {
                Console.WriteLine($"{product.ProductName}|{product.QuantitySold}");
            }
            using (StreamWriter sw = new StreamWriter($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}SalesReport.txt"))
            {
                
                foreach (IProduct product in Vend.Products)
                {
                    sw.WriteLine($"{product.ProductName}|{ product.QuantitySold}");
                }
            }
        }
        public void AuditEntry()
        {
            using (StreamWriter sw = new StreamWriter("Log.txt", true))
            {
                foreach (string transaction in TransactionList)
                {
                    sw.WriteLine(transaction);
                }
            }
        }
    }
}

