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
           

            display += "\t\t\t\t#     Product              Price      Quantity\n";

            display += "\t\t\t\t...............................................\n";

            foreach (IProduct product in Vend.Products)
            {
                if (product.QuantityLeft != 0)
                {

                    display += $"\t\t\t\t{product.SlotLocation,-5} {product.ProductName, -20} {product.Price.ToString("C"), -13} {product.QuantityLeft.ToString(), -20} \n";

                }
                else
                {
                    display += $"\t\t\t\t{product.SlotLocation,-5} {product.ProductName,-20} {product.Price.ToString("C"),-10} SOLD OUT \n";

                }
            }
            return display;
        }

        public void DisplayMainMenu()
        {
            Console.Clear();
            vendoMaticGraphic();
            Console.WriteLine("Welcome to Racoon City's Vendo-Matic 800 \n \nMAKE A SELECTION:\n\n(1) Display Vending Machine Items \n(2) Purchase\n(3) Exit");
            Console.WriteLine();
            string input = Console.ReadLine();
            while (input != "3")
            {
                    if (input == "1")
                    {
                        Console.Clear();
                        vendoMaticGraphic();
                        Console.WriteLine();
                        Console.WriteLine(DisplayInventory());
                    }
                    else if (input == "2")
                    {
                        Console.Clear();
                        Console.WriteLine();
                        PurchaseMenu();
                    }
                    else if (input == "4")
                    {
                        Console.Clear();
                        vendoMaticGraphic();
                        Console.WriteLine("Secret Menu: Sales Report\n");
                        SalesReport();
                    }
                else
                {
                    Console.Clear();
                    vendoMaticGraphic();
                    Console.WriteLine("Not a valid input. TRY AGAIN!");
                }
                
                
                Console.WriteLine("\nMAKE ANOTHER SELECTION: \n\n(1) Display Vending Machine Items \n(2) Purchase\n(3) Exit\n");
                input = Console.ReadLine();
            }
            FinishTransaction();
            
        }

        public void PurchaseMenu()
        {
            Console.Clear();
            vendoMaticGraphic();
            Console.WriteLine("\nPLEASE MAKE A SELECTION: \n\n(0) Return to Main Menu\n(1) Feed Money\n(2) Select Product\n(3) Finish Transaction");
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
                    Console.Clear();
                    vendoMaticGraphic();
                    Console.WriteLine($"\nCurrent Money Provided: {Vend.Balance:C}");
                    Console.WriteLine("\nPlease insert bills now\n($1, $2, $5 and $10 accepted)");
                    string money = Console.ReadLine();

                    Console.WriteLine();
                    decimal initalBalance = Vend.Balance;
                    decimal newBalance = FeedMoney(money);

                    if (initalBalance < newBalance)
                    {
                        Console.WriteLine($"***Depositing cash. Balance is updating to {newBalance:C}.***");

                    }

                }
                else if (input == "2")
                {
                    Console.Clear();
                    vendoMaticGraphic();

                    bool validSelection;

                    validSelection = SelectProduct();
                    if (!validSelection)
                    {
                        Console.Clear();
                        vendoMaticGraphic();
                        Console.WriteLine("NOT A VALID SELECTION");
                    }
          
                }
                else if (input == "4")
                {
                    Console.WriteLine();
                    Console.Clear();
                    vendoMaticGraphic();
                    Console.WriteLine("Secret Menu: Sales Report\n");
                    SalesReport();
                }
                else
                {
                    Console.Clear();
                    vendoMaticGraphic();
                    Console.WriteLine("Not a valid input. TRY AGAIN!");
                }
         
        
                Console.WriteLine("\nMAKE ANOTHER SELECTION: \n(0) Return to Main Menu\n(1) Feed Money\n(2) Select Product\n(3) Finish Transaction");
                Console.WriteLine($"\nCurrent Money Provided: {Vend.Balance:C}");
                Console.WriteLine();
                input = Console.ReadLine();
            }
            FinishTransaction();
        }
        public decimal FeedMoney(string money)
        {
            money = money.ToLower();
            try 
            {
                decimal dollarsAdded = Vend.FeedMoney(money);

                TransactionList.Add($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} FEED MONEY: {dollarsAdded:C} {Vend.Balance:C}");
            }
            catch(InvalidMoneyTypeException)
            {
                Console.WriteLine("Keep your monopoly money at home!!!");
            }
            Console.WriteLine();
            return Vend.Balance;
        }

        //make sure this works
        public bool SelectProduct()
        {
            bool validSelection = false;
            Console.WriteLine(DisplayInventory());
            Console.WriteLine($"Current Money Provided: {Vend.Balance:C}");
            Console.WriteLine("\nMAKE A SELECTION:\n");
            string input = Console.ReadLine();
            foreach (IProduct product in Vend.Products)
            {
                if (input.ToUpper() == product.SlotLocation)
                {
                    validSelection = true;

                    if (product.QuantityLeft > 0)
                    {
                        if (Vend.Balance >= product.Price)
                        {
                            product.QuantitySold++;
                            Vend.Balance -= product.Price;
                            Console.Clear();
                            vendoMaticGraphic();
                            Console.WriteLine($"\nDispensing {product.ProductName}.....\n");
                            Console.WriteLine(product.Message);
                            Console.WriteLine();
                            TransactionList.Add($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} {product.ProductName} {product.SlotLocation} {Vend.Balance + product.Price:C} {Vend.Balance:C}");
                            
                        }
                        else
                        {
                            Console.Clear();
                            vendoMaticGraphic();
                            Console.WriteLine("\nTo make this selection, you need to enter more money!");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        vendoMaticGraphic();
                        Console.WriteLine("\n***SORRY, THIS ITEM IS SOLD OUT***");
                    }
                }
            }
            return validSelection;
        }
        public void FinishTransaction()
        {
            TransactionList.Add($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} GIVE CHANGE: {Vend.Balance:C} $0.00");
            int quarters = (int)(Vend.Balance / .25m);
            Vend.Balance -= quarters * .25m;
            int dimes = (int)(Vend.Balance / .1m);
            Vend.Balance -= dimes * .1m;
            int nickels = (int)(Vend.Balance / .05m);
            Vend.Balance -= nickels * .05m;

            Console.Clear();
            vendoMaticGraphic();
            Console.WriteLine();

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
        private void vendoMaticGraphic()
        {
            ConsoleColor savedColor = Console.ForegroundColor;
            SetRandomColor();
            Console.WriteLine("██╗   ██╗███████╗███╗   ██╗██████╗  ██████╗       ███╗   ███╗ █████╗ ████████╗██╗ ██████╗     █████╗  ██████╗  ██████╗ ");
            SetRandomColor();
            Console.WriteLine("██║   ██║██╔════╝████╗  ██║██╔══██╗██╔═══██╗      ████╗ ████║██╔══██╗╚══██╔══╝██║██╔════╝    ██╔══██╗██╔═████╗██╔═████╗");
            SetRandomColor();
            Console.WriteLine("██║   ██║█████╗  ██╔██╗ ██║██║  ██║██║   ██║█████╗██╔████╔██║███████║   ██║   ██║██║         ╚█████╔╝██║██╔██║██║██╔██║");
            SetRandomColor();
            Console.WriteLine("╚██╗ ██╔╝██╔══╝  ██║╚██╗██║██║  ██║██║   ██║╚════╝██║╚██╔╝██║██╔══██║   ██║   ██║██║         ██╔══██╗████╔╝██║████╔╝██║");
            SetRandomColor();
            Console.WriteLine(" ╚████╔╝ ███████╗██║ ╚████║██████╔╝╚██████╔╝      ██║ ╚═╝ ██║██║  ██║   ██║   ██║╚██████╗    ╚█████╔╝╚██████╔╝╚██████╔╝");
            SetRandomColor();
            Console.WriteLine("  ╚═══╝  ╚══════╝╚═╝  ╚═══╝╚═════╝  ╚═════╝       ╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝ ╚═════╝     ╚════╝  ╚═════╝  ╚═════╝ ");
            Console.ForegroundColor = ConsoleColor.White;

        }

        static private void SetRandomColor()
        {
            Array colors = Enum.GetValues(typeof(ConsoleColor));
            Random rand = new Random();
            int ix = rand.Next(1, colors.Length);
            ConsoleColor color = (ConsoleColor)colors.GetValue(ix);
            Console.ForegroundColor = color;
        }

    }
}

