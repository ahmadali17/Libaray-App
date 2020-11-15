using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibarayApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t Welcome To Our Libray Management System\n\n");
            Program p = new Program();
            p.Choices();

            Console.ReadKey();
        }

        public void Choices()
        {
            int choice;

            Console.WriteLine("Select: ");
            Console.WriteLine("1: Login as a Customer.");
            Console.WriteLine("2: Login as an Admin.");

            Console.Write("\nYour Choice: ");
            choice = int.Parse(Console.ReadLine());

            User u = new User();


            if (choice == 1)
            {
                User CustomerUser = new Customer();
                CustomerUser.Login();
            }
            else if (choice == 2)
            {
                Console.Clear();
                Console.WriteLine("\t\tEnter registeration details\n");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("\t\tEnter registeration details\n");

                Console.Write("Mobile: ");
                string asd = Console.ReadLine();

                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\t\t Welcome To Our Libray Management System\n\n");
                Choices();
            }
        }
    }
}

//Console.Clear();
//Console.WriteLine("\t\tWelcome \'UserName\'\n\n");

//Console.WriteLine("Select: ");
//Console.WriteLine("1: Browse All Books.");
//Console.WriteLine("2: Buy.");

//Console.Write("\nYour Choice: ");
//choice = int.Parse(Console.ReadLine());