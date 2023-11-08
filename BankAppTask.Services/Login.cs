using BankAppTask.Model;
using BankAppTask.Tools;
using System;

namespace BankAppTask.Services
{

    // Typical Inheritance senario to accomplish OOP
    public class Login : Logged
    {
        public static void LoginUser()
        {
            Console.WriteLine("Enter your account number to login");
            string accountNo = Console.ReadLine();

            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            if(accountNo=="" || password == "")
            {
                Console.WriteLine("All fields are required. Try again");
                LoginUser();
            }
            else
            {
                Customer foundCustomer = null;

                //Names of registered customers of the bank to be scanned for the credentials of the customer in attendance.
                var customerList = ListOfCustomers.customerList;
                bool found = false;
                foreach(var item in customerList)
                {
                    if (item.Key == accountNo)
                    {   
                        foundCustomer = item.Value;
                        if (CheckLogin(foundCustomer,password))
                        {
                            found = true;
                        }
                        string passwd = foundCustomer.GetPassword();

                        
                    }
                }


                //matching the found customer with the entered credentials for authorization.
                if (found)
                {
                    loggedAccount = accountNo;
                    loggedCustomer = foundCustomer;
                    Console.WriteLine("Login successful");
                    Welcome.Options();

                }
                else
                {
                    Console.WriteLine("Invalid login Details. Try again");
                    LoginUser();
                }
            }

        }

        public static bool CheckLogin(Customer foundCustomer, string password)
        {
            string passwd = foundCustomer.GetPassword();

            if (password == passwd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
