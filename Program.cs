using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumberSpeller;

namespace SpellOutNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            do
            {
                string numStr;

                Console.Write("Enter a number (q to quit) > ");
                numStr = Console.ReadLine();
                if (numStr.ToLower() != "q")
                {
                    long number;
                    if (long.TryParse(numStr, out number))
                        Console.WriteLine(number.ToText());
                    else
                        Console.WriteLine("Invalid Input String");
                }
                else
                    quit = true;
            } while (!quit);
        }
    }
}
