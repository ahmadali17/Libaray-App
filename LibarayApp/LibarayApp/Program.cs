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
            new Program().Choices();

            ////////// Show Book For Customer & Admin //////////////////
            //Staff s = new Staff();
            //s.show();
            //Console.WriteLine("***********************************");

            /* Customer c = new Customer();
             c.show();*/

            ///////////////// Add Book //////////////////
            /*  Staff s = new Staff();
              s.add_book();*/

            //////////////// delete book////////////

            /*Staff s = new Staff();
             s.delete();*/

            //new User().Register();

        }

        public void Choices()
        {
            int choice;

            Console.WriteLine("Select: ");
            Console.WriteLine("1: Login as a Customer.");
            Console.WriteLine("2: Login as an Admin.");
            Console.WriteLine("3: Register a new User.");

            Console.Write("\nYour Choice: ");
            choice = int.Parse(Console.ReadLine());


            if (choice == 1)
            {
                User CustomerUser = new Customer();
                CustomerUser.Login();

            }
            else if (choice == 2)
            {
                Console.Clear();


                //Admin Options HERE

                Console.Clear();
            }
            else if (choice == 3)
            {
                new User().Register();
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
