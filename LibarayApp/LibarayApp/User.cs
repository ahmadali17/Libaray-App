using System;
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
        

        public void Login()
        {

        }

        public void Register()
        {

        }

        public void LogOut()
        {

        }
    }
}
