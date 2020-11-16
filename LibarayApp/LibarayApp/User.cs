using System;
using System.IO;
namespace LibarayApp
{
    public class User
    {
        private int userID;
        private string userName;
        private string password;
        private UserType userType;

        public User()
        {
        }


        //check account
        //login
        //register
        //show
        //logout

        public void SetUserID(int id)
        {
            userID = id;
        }

        public int GetUserID()
        {
            return userID;
        }

        public void SetUserName(string name)
        {
            userName = name;
        }

        public string GetUserName()
        {
            return userName;
        }

        public void SetPassword(string pass)
        {
            password = pass;
        }

        public string GetPassword()
        {
            return password;
        }

        public virtual void Login()
        {
            Console.Write("User Name: ");
            SetUserName(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Password: ");
            SetPassword(Console.ReadLine()); 
        }

        public void Register()
        {

        }

        public void LogOut()
        {

        }
        public  void show()
        {
            StreamReader sr = new StreamReader("BookData.txt");
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string Line_Without_delimiter = line.Replace(";", "           ");
                Console.WriteLine(Line_Without_delimiter);

            }
            sr.Close();
        }
       
    }
}
