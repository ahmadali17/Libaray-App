using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace LibarayApp
{
    public class Staff : User
    {
        public Staff()
        {

        }


        public void add_book()
        {
            Book b = new Book();
            Console.WriteLine("Enter Book Title");
            b.set_title(Console.ReadLine());//// use setter & getter in Book Class 
            Console.WriteLine("Enter Book auther");
            b.set_auther(Console.ReadLine());
            int isbn;
            Console.WriteLine("Enter the date of publication");
            b.set_publication(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter Book's Price");
            b.set_price(double.Parse(Console.ReadLine()));

            if (new FileInfo("BookData.txt").Length == 0)
            {
                isbn = 1;
                b.set_isbn(isbn);
                b.book_info();

            }

            else
            {
                string m = "";

                StreamReader r = new StreamReader("BookData.txt");
                while (r.EndOfStream == false)
                {
                    m = r.ReadLine();
                }
                r.Close();
                char[] spearator = { ';' };

                string[] strlist = m.Split(spearator);
                int id = int.Parse(strlist[0]);
                isbn = id + 1;
                b.set_isbn(isbn);
                ////////////
                b.book_info();
            }


        }

        public void delete()
        {

            // int id = int.Parse(Console.ReadLine());
            Queue<int> q = new Queue<int>();
            List<int> list = new List<int>();
            foreach (var line in File.ReadAllLines("BookData.txt"))
            {
                char[] spearator = { ';' };

                string[] strlist = line.Split(spearator);
                //q.Enqueue(int.Parse(strlist[0]));
                list.Add(int.Parse(strlist[0]));

            }

            Show();
            Console.WriteLine("***************************");
            Console.WriteLine("Enter book id");
            int id = int.Parse(Console.ReadLine());
            if (list.Contains(id))
            {
                // Console.WriteLine("yes");
                var File_data = File.ReadAllLines("BookData.txt");
                List<string> new_lines = new List<string>();
                foreach (var s in File_data)
                { new_lines.Add(s); }
                new_lines.RemoveAt(list.IndexOf(id));
                File.WriteAllLines("BookData.txt", new_lines.ToArray());
                Console.WriteLine("Deleted successfully *-*");


            }
            else
            {
                Console.WriteLine("No exist this ID");
            }

        }

        public override void Show()
        {
            base.Show();
        }

        public void StaffOptions()
        {
            Console.Clear();
            Console.WriteLine("\t Welcome Admin \t");
            Console.WriteLine("Select: ");
            Console.WriteLine("1: Show All Books.");
            Console.WriteLine("2: Add Books.");
            Console.WriteLine("3: Show All Users.");
            Console.WriteLine("4: Delete Book.");
            Console.WriteLine("5: Show Purchase History.");
            Console.WriteLine("6: Logout.");
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

                add_book();
                Return();

            }
            else if (customerChoice == "3")
            {
                ShowAllUsers();
                Return();
            }
            else if(customerChoice == "4")
            {
                delete();
                Return();
            }
            else if(customerChoice == "5")
            {
                ShowHistory();
                Return();
            }
            else if (customerChoice == "6")
            {
                LogOut();
            }
            else
            {
                Console.WriteLine("Please enter valid number");
                Thread.Sleep(2000);
                StaffOptions();
            }
                

        }

        public override void Login()
        {
            base.Login();

            if (GetUserName() == "admin" && GetPassword() == "123")
                StaffOptions();
            else
            {
                Console.WriteLine("Please Enter valid username & Password");
                Thread.Sleep(2000);
                Login();
            }
                

        }

        public void ShowAllUsers()
        {
            StreamReader sr = new StreamReader("UserData.txt");
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string Line_Without_delimiter = line.Replace(";", "           ");
                Console.WriteLine(Line_Without_delimiter);

            }
            sr.Close();
        }


        public void ShowHistory()
        {
            StreamReader sr = new StreamReader("BuyData.txt");
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string Line_Without_delimiter = line.Replace(";", "           ");
                Console.WriteLine(Line_Without_delimiter);

            }
            sr.Close();
        }

        public void Return()
        {
            Console.WriteLine("Return to main options? (Y/N)");
            string choice2 = Console.ReadLine();

            if (choice2 == "y" || choice2 == "Y")
            {
                StaffOptions();
            }
            else
                LogOut();
        }
    }
}
