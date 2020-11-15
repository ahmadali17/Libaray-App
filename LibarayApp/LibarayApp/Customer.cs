using System;
namespace LibarayApp
{
    public class Customer : User
    {
        //buy
        //show

        
        public Customer()
        {
        }

        public static void Show()
        {

        }

        public static void Buy()
        {

        }

        public static void CustomerOptions()
        {
            Console.Clear();
            Console.WriteLine("Welcome Ahmed");
            Console.WriteLine("Select: ");
            Console.WriteLine("1: Show All Books.");
            Console.WriteLine("2: Buy a book.");
            Console.Write("\nYour Choice: ");

        }

        public override void Login()
        {
            base.Login();
            int choice;

            if (GetUserName() == "ahmed" && GetPassword() == "123")
            {
                Customer.CustomerOptions();

                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                    Customer.Show();
                else if (choice == 2)
                    Customer.Buy();
                else
                    Customer.CustomerOptions();
            }
        }
    }
}
