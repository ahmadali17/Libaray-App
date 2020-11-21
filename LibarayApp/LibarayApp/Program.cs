using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibarayApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Choices();
        }

        public void Choices()
        {
            string choice;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\t\t Welcome To Our Libray Management System\n\n");

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Select: ");
            Console.WriteLine("1: Login as a Customer.");
            Console.WriteLine("2: Login as an Admin.");
            Console.WriteLine("3: Register a new User.");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("\nYour Choice: ");
            choice = Console.ReadLine();


            if (choice == "1")
            {
                User CustomerUser = new Customer();
                CustomerUser.Login();
            }
            else if (choice == "2")
            {
                Console.Clear();
                new Staff().Login();

            }
            else if (choice == "3")
            {
                new User().Register();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Please enter a valid number");
                Thread.Sleep(2000);
                Console.Clear();
                Console.ResetColor();
                Choices();
            }
        }
    }
}
