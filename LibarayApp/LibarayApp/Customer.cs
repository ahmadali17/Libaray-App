using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace LibarayApp
{
    public class Customer : User
    {
        //buy
        //show

        Book b = new Book();
        public Customer()
        {
        }

        public override void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("All Books: \n\n");
            Console.ResetColor();
            base.Show();
        }

        public void Buy()
        {

            Show();
            delete();
            Buy_Data();
            Console.WriteLine("buy is Successfully");
        }

        public void Buy_Data()
        {
            StreamWriter sw = File.AppendText("BuyData.txt");
            string line = DateTime.Now.ToString("HH:mm:ss tt") + "\n" + "" + "\n" + "=====================================================================";

            sw.Write(line + "\n");
            Console.WriteLine("buy info Added");
            sw.Close();
        }

        public void delete()
        {
            List<int> list = new List<int>();
            foreach (var line in File.ReadAllLines("BookData.txt"))
            {
                char[] spearator = { ';' };

                string[] strlist = line.Split(spearator);
                //q.Enqueue(int.Parse(strlist[0]));
                list.Add(int.Parse(strlist[0]));

            }

            Console.WriteLine("***************************");
            Console.WriteLine("Enter book id");
            //int id = int.Parse(Console.ReadLine());
            b.set_isbn(int.Parse(Console.ReadLine()));
            if (list.Contains(b.get_isbn()))
            {
                // Console.WriteLine("yes");
                var File_data = File.ReadAllLines("BookData.txt");
                List<string> new_lines = new List<string>();
                foreach (var s in File_data)
                { new_lines.Add(s); }
                int index = list.IndexOf(b.get_isbn());
                /*List<string> buy_list = new List<string>();
                buy_list.Add(new_lines[index]);*/
                string combindedString = new_lines[index];
                new_lines.RemoveAt(list.IndexOf(b.get_isbn()));
                File.WriteAllLines("BookData.txt", new_lines.ToArray());


                StreamWriter sw = File.AppendText("BuyData.txt");
                sw.Write(combindedString + "\n");
                sw.Close();
                Console.WriteLine("Deleted successfully *-*");


            }
            else
            {
                Console.WriteLine("No exist this ID");
            }
        }
        public void CustomerOptions()
        {
            Console.Clear();
            Console.WriteLine("\t Welcome, " + GetUserName());
            Console.WriteLine("Select: ");
            Console.WriteLine("1: Show All Books.");
            Console.WriteLine("2: Buy a book.");
            Console.WriteLine("3: Logout.");
            Console.Write("\nYour Choice: ");

            string customerChoice;


            customerChoice = Console.ReadLine();
            if (customerChoice == "1")
            {
                Show();
                Console.WriteLine();
                Return();

            }
            else if (customerChoice == "2")
            {
                Console.Clear();
                Buy();
                Return();
            }
            else if (customerChoice == "3")
            {
                LogOut();
            }
            else
            {
                Console.WriteLine("Please enter valid number");
                Thread.Sleep(2000);
                CustomerOptions();
            }
                
        }

        public override void Login()
        {
            base.Login();
            List<string> list = new List<string>();
            foreach (var line in File.ReadAllLines("UserData.txt"))
            {
                char[] spearator = { ';' };

                string[] strlist = line.Split(spearator);

                list.Add(strlist[1] + " " + strlist[2]);
            }
            string name_and_pass = GetUserName() + " " + GetPassword();
            if (list.Contains(name_and_pass))
            {
                CustomerOptions();
            }
            else
            {
                Console.WriteLine("not exist");
            }
        }

        public void Return()
        {
            Console.WriteLine("Return to main options? (Y/N)");
            string choice2 = Console.ReadLine();

            if (choice2 == "y" || choice2 == "Y")
            {
                CustomerOptions();
            }
            else
                LogOut();
        }
    }
}

