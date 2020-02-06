using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    class Menu
    {
        string input = "";

        string path = "vendingmachine.csv";
        string root = Environment.CurrentDirectory;
        

        using(StreamReader sr = new StreamReader(root + "\\" + path))
        {
            while (!sr.EndOfStream)
            {

            }

        }

 

    }
}
