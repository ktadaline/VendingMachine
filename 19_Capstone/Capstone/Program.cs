﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(120, 50);
            List<string> fullTextProducts = new List<string>();

            string path = "vendingmachine.csv";
            string root = Environment.CurrentDirectory;


            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    fullTextProducts.Add(line);
                }
            }

            VendingMachine vender = new VendingMachine();

            vender.StockVendingMachine(fullTextProducts);

            Menu menu = new Menu(vender);


            menu.DisplayMainMenu();

            menu.AuditEntry();
        }
    }
}
