using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> FullTextProducts = new List<string>();

            string path = "vendingmachine.csv";
            string root = Environment.CurrentDirectory;


            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    FullTextProducts.Add(line);
                }

            }



        }
    }
}
