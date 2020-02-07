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
            Console.WriteLine(@"
██╗   ██╗███████╗███╗   ██╗██████╗  ██████╗       ███╗   ███╗ █████╗ ████████╗██╗ ██████╗     █████╗  ██████╗  ██████╗ 
██║   ██║██╔════╝████╗  ██║██╔══██╗██╔═══██╗      ████╗ ████║██╔══██╗╚══██╔══╝██║██╔════╝    ██╔══██╗██╔═████╗██╔═████╗
██║   ██║█████╗  ██╔██╗ ██║██║  ██║██║   ██║█████╗██╔████╔██║███████║   ██║   ██║██║         ╚█████╔╝██║██╔██║██║██╔██║
╚██╗ ██╔╝██╔══╝  ██║╚██╗██║██║  ██║██║   ██║╚════╝██║╚██╔╝██║██╔══██║   ██║   ██║██║         ██╔══██╗████╔╝██║████╔╝██║
 ╚████╔╝ ███████╗██║ ╚████║██████╔╝╚██████╔╝      ██║ ╚═╝ ██║██║  ██║   ██║   ██║╚██████╗    ╚█████╔╝╚██████╔╝╚██████╔╝
  ╚═══╝  ╚══════╝╚═╝  ╚═══╝╚═════╝  ╚═════╝       ╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝ ╚═════╝     ╚════╝  ╚═════╝  ╚═════╝ ");
            Console.WriteLine("Welcome to Racoon City's Vendo-Matic 800 \n \n(1) Display Vending Machine Items \n(2) Purchase\n(3) Exit");
            Console.WriteLine();
            string input = Console.ReadLine();

            while (input != "3")
            {
                try
                {
                    if (input == "1")
                    {
                        Console.WriteLine(DisplayInventory());
                    }
                    else if (input == "2")
                    {
                        Console.WriteLine();
                        PurchaseMenu();
                    }
                    else if (input == "4")
                    {
                        Console.WriteLine("Secret Menu: Sales Report");
                        SalesReport();
                    }
                }
                catch(InvalidMenuSelectionException)
                {
                    Console.WriteLine("Not a valid input. TRY AGAIN!");
                }
                Console.WriteLine("\nPlease make another selection!");
                Console.WriteLine("\nWelcome to Racoon City's Vendo-Matic 800 \n(1) Display Vending Machine Items \n(2) Purchase\n(3) Exit\n");
                input = Console.ReadLine();
            }
            FinishTransaction();
            
        }

        public void PurchaseMenu()
        {
            Console.WriteLine("Please make a selection:\n(0) Return to Main Menu\n(1) Feed Money\n(2) Select Product\n(3) Finish Transaction");
            Console.WriteLine($"\nCurrent Money Provided: {Vend.Balance:C}");
            string input = Console.ReadLine();

            while (input != "3")
            {
                if (input == "0")
                {
                    Console.WriteLine("Returning to Main Menu");
                    DisplayMainMenu();
                    

                }
                else if (input == "1")
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
                    Console.WriteLine("Secret Menu: Sales Report");
                    SalesReport();
                }
                else
                {
                    Console.WriteLine("Not a valid input. TRY AGAIN!");
                }
                Console.WriteLine("\nPlease make another selection!");
                Console.WriteLine("Please make a selection:\n(0) Return to Main Menu\n(1) Feed Money\n(2) Select Product\n(3) Finish Transaction");
                Console.WriteLine($"\nCurrent Money Provided: {Vend.Balance:C}");
                Console.WriteLine();
                input = Console.ReadLine();
            }
            FinishTransaction();
            Console.WriteLine("Goodbye.");
        }
        public decimal FeedMoney(string money)
        {
            money = money.ToLower();
            try 
            {
                decimal dollarsAdded = Vend.FeedMoney(money);

                TransactionList.Add($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} FEED MONEY: {dollarsAdded:C} {Vend.Balance:C}");
            }


            catch(InvalidMoneyTypeException ex)
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
                        Console.WriteLine($"\nDispensing {product.ProductName}.....\n");
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
            using (StreamWriter sw = new StreamWriter($"{Environment.CurrentDirectory}\\{DateTime.Now.ToString("MMddyyyy_HHmmss")}SalesReport.txt"))
            {

                foreach (IProduct product in Vend.Products)
                {
                    sw.WriteLine($"{product.ProductName.ToString()}|{product.QuantitySold.ToString()}");
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

