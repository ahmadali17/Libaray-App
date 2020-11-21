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

        public void SetUserType(UserType ut)
        {
            userType = ut;
        }
        public UserType GetUserType()
        {
            return userType;
        }


        public virtual void Login()
        {
            Console.Clear();
            Console.Write("User Name: ");
            SetUserName(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Password: ");
            SetPassword(Console.ReadLine());
        }

        public override void Register()
        {
            base.Register();

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
                    show();

                else if (choice == 2)
                    Buy();
                else
                    CustomerOptions();
            }
        }



        public virtual void LogOut()
        {
            Console.Clear();
            new Program().Choices();
        }


        public virtual void Show()
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


        public void AddUserToFile()
        {
            StreamWriter sw = File.AppendText("UserData.txt");
            string line = GetUserID() + ";" + GetUserName() + ";" + GetPassword() + ";" + GetUserType();

            sw.Write(line + "\n");
            Console.WriteLine("New User Added");
            sw.Close();
        }

    }
}

