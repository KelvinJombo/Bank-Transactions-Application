using BankAppTask.Model;
using BankAppTask.Tools;
using System;
using System.Collections.Generic;

namespace BankAppTask.Services
{

    internal class CreateAccount : ListOfCustomers
    {
        public static List<KeyValuePair<string, string[]>> statements = AccountStatement.statements;
        
        public static void CreateCustomerAccount()
        {
            Console.WriteLine("Input your BVN");
            string bvn = Console.ReadLine();
            bvn =Validation.ConfirmBvn(bvn);

            Console.WriteLine("Input Firstname");
            string firstname = Console.ReadLine();
            firstname = Validation.NameCheck(firstname);

            Console.WriteLine("Input Lastname");

            string lastname = Console.ReadLine();
            lastname = Validation.NameCheck(lastname);


            Console.WriteLine("Input your phone number");
            string phoneNumber = Console.ReadLine();
            phoneNumber = Validation.PhoneCheck(phoneNumber);


            string email = Validation.EmailCheck();


            Console.WriteLine("Input your password");
            string password = Console.ReadLine();
            password = Validation.PasswordCheck(password);
            

            Console.WriteLine("What type of account do you want?\nPress S for savings and C for current");
            string acctype = Console.ReadLine();
            Console.Clear();

            string accounttype = "";

            if (acctype == "S")
            {
                accounttype = "SAVINGS";
            }
            if (acctype == "C")
            {
                accounttype = "CURRENT";
            }



            bool found = false;
            foreach (var registeredUsers in customerList)
            {
                Customer user = registeredUsers.Value;
                if (user.GetBVN() == bvn)
                {
                    if (user.GetAccountType() == accounttype)
                    {
                        Logger.Log($"You already have a {accounttype} account");    
                        found = true;
                        
                    }
                }
            }

            if (!found)
            {
                Customer customer = new Customer(firstname, lastname, phoneNumber, email, accounttype, password, bvn);
                string accountNumber = AccountNoGenerator.GenerateNewAccountNumber();

                AddCustomer(accountNumber, customer);

                string[] values = {firstname+" "+lastname,"0", accountNumber, accounttype, "0", "New Account" };
                statements.Add(new KeyValuePair<string, string[]>(accountNumber,values));

                Logger.Log("Account created successfully. Your account number is " + accountNumber);
                SaveCustomerToFile();
                AccountStatement.SaveStatementToFile();

            }

            Login.LoginUser();
        }



    }
}
