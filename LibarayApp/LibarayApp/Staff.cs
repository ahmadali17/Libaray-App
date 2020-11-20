using System;
using System.IO;
using System.Collections.Generic;
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
            b.set_price( double.Parse(Console.ReadLine()));
            
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
            List<int> list=new List<int>();
            foreach (var line in File.ReadAllLines("BookData.txt"))
            {
                char[] spearator = { ';' };

                string[] strlist = line.Split(spearator);
                //q.Enqueue(int.Parse(strlist[0]));
                list.Add(int.Parse(strlist[0]));
                
            }

            foreach(var r in list)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine("***************************");
            Console.WriteLine("Enter book id");
            int id = int.Parse(Console.ReadLine());
            if(list.Contains(id))
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

    }
}
