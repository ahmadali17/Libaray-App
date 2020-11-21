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
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("User Name: ");
            SetUserName(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Password: ");
            SetPassword(Console.ReadLine());

            Console.ResetColor();
        }

        public virtual void Register()
        {
            User u = new User();
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.Write("Enter your user name: ");
            string user = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter password: ");
            string pass = Console.ReadLine();

            Console.WriteLine("Repeat password: ");
            string repeatedPassword = Console.ReadLine();
            if (repeatedPassword == pass)
            {
                u.SetUserName(user);
                u.SetPassword(pass);

                u.SetUserType(UserType.customer);

                if (new FileInfo("UserData.txt").Length == 0)
                {
                    userID = 1;
                    u.SetUserID(userID);

                    u.AddUserToFile();
                }
                else
                {
                    string m = "";

                    StreamReader r = new StreamReader("UserData.txt");
                    while (r.EndOfStream == false)
                    {
                        m = r.ReadLine();
                    }
                    r.Close();
                    char[] spearator = { ';' };

                    string[] strlist = m.Split(spearator);
                    int id = int.Parse(strlist[0]);
                    userID = id + 1;
                    u.SetUserID(userID);

                    u.AddUserToFile();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Password not matched!");
                Console.ResetColor();
                new User().Register();
            }

            Console.ResetColor();
        }



        public virtual void LogOut()
        {
            Console.Clear();
            new Program().Choices();
        }


        public virtual void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            StreamReader sr = new StreamReader("BookData.txt");
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string Line_Without_delimiter = line.Replace(";", "           ");
                Console.WriteLine(Line_Without_delimiter);

            }
            sr.Close();

            Console.ResetColor();
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

