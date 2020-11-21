using System;
using System.Collections.Generic;
using System.IO;

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
            Console.WriteLine("All Books: \n\n");
            base.Show();

            //Show();            delete();            Buy_Data();            Console.WriteLine("buy is Successfully");
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
            List<string> list = new List<string>();
            foreach (var line in File.ReadAllLines("Login.txt"))
            {
                char[] spearator = { ';' };

                string[] strlist = line.Split(spearator);

                list.Add(strlist[0] + " " + strlist[1]);
            }
            string name_and_pass = GetUserName() + " " + GetPassword();
            if (list.Contains(name_and_pass))
            {
                Console.WriteLine("email exist");
                CustomerOptions();
                int choice;
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                    show();

                else if (choice == 2)
                    Buy();
                else
                    CustomerOptions();
            }
            else
            {
                Console.WriteLine("not exist");
            }
        }

        public void Buy_Data()        {            StreamWriter sw = File.AppendText("BuyData.txt");            string line = DateTime.Now.ToString("HH:mm:ss tt") + "\n" + "" + "\n" + "=====================================================================";            sw.Write(line + "\n");            Console.WriteLine("buy info Added");            sw.Close();        }

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

                //File.WriteAllLines("BuyData.txt", buy_list.ToArray());
                // string combindedString = string.Join(";", buy_list);

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

        public override void Register()
        {
            //base.Register();

            List<string> list = new List<string>();
            foreach (var line in File.ReadAllLines("Login.txt"))
            {
                char[] spearator = { ';' };

                string[] strlist = line.Split(spearator);

                list.Add(strlist[0]);
            }
            string name = GetUserName();
            if (list.Contains(name))
            {
                Console.WriteLine("this username already exist");
            }
            else
            {
                StreamWriter sw = File.AppendText("Login.txt");
                string line = GetUserName() + ";" + GetPassword();
                sw.Write(line + "\n");
                Console.WriteLine("Added successfully");
                sw.Close();

                CustomerOptions();
                int choice;
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                    Show();

                else if (choice == 2)
                    Buy();
                else
                    CustomerOptions();
            }
        }
    }
}

