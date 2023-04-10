using System;

namespace Wonga.ServiceA // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello what is your name?");

            var name = Console.ReadLine();


        }

        private static string MessageConsolidation(string name) {

            if (!String.IsNullOrEmpty(name))
                return "Hello my name is {1} " + name;
            else
                return "Exit";
        }
    }
}


