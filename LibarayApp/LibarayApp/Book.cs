using System;
using System.IO;
namespace LibarayApp
{
    public class Book
    {
        private int ISBN;
        private string title;
        private string author;
        private int publication;
        private double price;


        public Book()
        {
        }

        public void set_isbn(int _isbn)
        {
            ISBN = _isbn;
        }
        public int get_isbn()
        {
            return ISBN;
        }
        /// //////////////////////////////
        public void set_title(string _title)
        {
            title = _title;
        }
        public string get_title()
        {
            return title;
        }
       
         ///////////////////////////////////////////////


        public void set_auther(string _author)
        {
            author = _author;
        }
        public string get_auther()
        {
            return author;
        }

        ////////////////////////////////////////////
       
        public void set_publication(int _publication)
        {
            publication = _publication;
        }
        public int get_publication()
        {
            return publication;
        }

        ///////////////////////////////////////////
        public void set_price(double _price)
        {
            price = _price;
        }
        public double get_price()
        {
            return price;
        }

        //setters & getters
        //info.

        public void book_info()
        {
            using (StreamWriter sw = File.AppendText("BookData.txt"))
            {
                string line = get_isbn() + ";" + get_title() + ";" + get_auther() + ";" + get_publication() + ";" + get_price();

                sw.Write(line + "\n");
                Console.WriteLine("book Added");
                sw.Close();
            }
        }

    }
}
