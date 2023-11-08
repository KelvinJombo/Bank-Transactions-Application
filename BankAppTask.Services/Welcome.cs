
using BankAppTask.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppTask.Services
{
    public class Welcome
    {

        // first point of call from the program class.
        public void WelcomeUser()
        {
            Console.WriteLine("WELCOME TO .NET BANKING SYSTEM");
            Console.WriteLine("Press 1 to create account\nPress 2 to login");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateAccount.CreateCustomerAccount();   //far new customers majorly.
                break;

                case "2":
                    Login.LoginUser();
                break;

            }
        }


        public static void Options()
        {
            
            Console.WriteLine("\nPress 1 to deposit\nPress 2 to withdraw");
            Console.WriteLine("Press 3 to transfer\nPress 4 to print account statement");
            Console.WriteLine("Press 5 to check balance\nPress 6 to create another account");
            Console.WriteLine("Press 7 to login to another\nPress 8 to exit");

            //Customer and transaction interface. 
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Input amount to deposit");
                    string inputAmount = Console.ReadLine();

                    double amount = Convert.ToDouble(inputAmount);

                    Transactions.Deposit(amount);
                    Options();
                    break;

                case "2":
                    Console.WriteLine("Input amount to withdraw");
                    string inputWithrawAmount = Console.ReadLine();
                    double amountToWithdaw = Convert.ToDouble(inputWithrawAmount);

                    Transactions.Withdraw(amountToWithdaw);
                    Options();
                    break;

                case "3":
                    Logger.Log("Input amount to transfer");
                    double amountt = double.Parse(Console.ReadLine());
                    Transactions.Transfer(amountt);
                    Options();
                    break;

                case "4":
                    AccountStatement.PrintAccountStatement();
                    Options();
                    break;
                case "5":
                    double bal = Transactions.CheckBalance();
                    Console.Clear();
                    Logger.Log($"Your current balance is {bal}");
                    Options();
                    break;

                case "6":
                    CreateAccount.CreateCustomerAccount();
                   // Options();
                    break;

                case "7":
                    Login.LoginUser();
                    break;
                case "8":

                    break;
            }
        }

    }
}
