using System;
using System.Collections.Generic;
using System.IO;

namespace LibarayApp
{
    public class Customer : User
    {
        //buy
        //show


        public Customer()
        {
        }

        public override void Show()
        {
            Console.WriteLine("All Books: \n\n");
            base.Show();
        }

        public void Buy()
        {
            List<int> list = new List<int>();
            foreach (var line in File.ReadAllLines("BookData.txt"))
            {
                char[] spearator = { ';' };

                string[] strlist = line.Split(spearator);

                list.Add(int.Parse(strlist[0]));

            }

            foreach (var r in list)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine("***************************");
            Console.Write("Enter book id you want to buy: ");
            int id = int.Parse(Console.ReadLine());
            if (list.Contains(id))
            {
                Console.Clear();
                var File_data = File.ReadAllLines("BookData.txt");
                List<string> new_lines = new List<string>();

                foreach (var s in File_data)               
                    new_lines.Add(s);
                
                new_lines.RemoveAt(list.IndexOf(id));

                File.WriteAllLines("BookData.txt", new_lines.ToArray());
                Console.WriteLine("Congrats!\n\nYou have Successfully bought this book :D\n\n\n");
                Console.WriteLine("Check our new collection to buy again: \n\n");

                Console.Clear();
                Show();

            }
            else
            {
                Console.WriteLine("Book ID NOT exist \n Please Try Again");
                Console.Clear();
                CustomerOptions();
            }
        }

        public static void CustomerOptions()
        {
            Console.Clear();
            Console.WriteLine("\t Welcome Ahmed \t");
            Console.WriteLine("Select: ");
            Console.WriteLine("1: Show All Books.");
            Console.WriteLine("2: Buy a book.");
            Console.Write("\nYour Choice: ");
        }

        public override void Login()
        {
            base.Login();

            int customerChoice;

            if (GetUserName() == "ahmed" && GetPassword() == "123")
            {
                Customer.CustomerOptions();

                customerChoice = int.Parse(Console.ReadLine());
                if (customerChoice == 1)
                {
                    new Customer().Show();

                    Console.WriteLine();
                }
                else if (customerChoice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("All Books IDs: \n");
                    new Customer().Buy();
                }
                    
                else
                    Customer.CustomerOptions();
            }
        }
    }
}
