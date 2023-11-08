using BankAppTask.Model;
using BankAppTask.Tools;
using System;
using System.Collections.Generic;


namespace BankAppTask.Services
{

    //Using a generic data structure for holding of value pair data,
    public class Transactions : Logged
    {
        static List<KeyValuePair<string, string[]>> statements = AccountStatement.statements;

        static Dictionary<string, Customer> customerList = ListOfCustomers.customerList;

        public static void Deposit(double amount)
        {
            foreach (var item in customerList)
            {
                if (item.Key == loggedAccount)
                {
                    if (amount > 0)
                    {
                        Customer customer = item.Value;
                        double currentBalance = DepositToAccount(customer, amount);
                        string[] values = { customer.GetFullname(), amount.ToString(), loggedAccount, customer.GetAccountType(), currentBalance.ToString(), "CREDIT" };
                        statements.Add(new KeyValuePair<string, string[]>(loggedAccount, values));
                        Logger.Log($"{amount} naira has been credited to your account.");
                        AccountStatement.SaveStatementToFile();
                        ListOfCustomers.SaveCustomerToFile();
                    }
                    else
                    {
                        Logger.Log("Transaction failed. Invalid amount");
                    }
                }
            }
        }

        public static double DepositToAccount(Customer customer, double amount)
        {
            double balance = customer.GetBalance();
            double currentBalance = balance + amount;
            customer.SetBalance(currentBalance);
            return currentBalance;
        }

        public static void Withdraw(double amount)
        {
            bool withdrawalSuccessful = false;

            foreach (var item in customerList)
            {
                if (item.Key == loggedAccount)
                {
                    WithdrawFromCustomerAccount(item.Value, amount);
                    break;
                }

               
            }
             
            if (withdrawalSuccessful == true)
            {
                HandleWithdrawal(amount);
            }
        }
            

        public static void WithdrawFromCustomerAccount(Customer customer, double amount)
        {
            double balance = customer.GetBalance();
            double currentBalance = balance - amount;
            customer.SetBalance(currentBalance);

            string[] values = { customer.GetFullname(), amount.ToString(), loggedAccount, customer.GetAccountType(), currentBalance.ToString(), "DEBIT" };
            statements.Add(new KeyValuePair<string, string[]>(loggedAccount, values));
            Logger.Log("Withdrawal successful");
            AccountStatement.SaveStatementToFile();
            ListOfCustomers.SaveCustomerToFile();
        }

        private static void HandleWithdrawal(double amount)
        {
            string accountType = GetAccountType();
            double balance = CheckBalance();

            if (amount > 0 && accountType == "SAVINGS")
            {
                if ((balance - 1000) >= amount)
                {
                    Transactions.Withdraw(amount);
                    Logger.Log("Withdrawal successful");
                }
                else
                {
                    Logger.Log("Insufficient Funds");
                }
            }
            else if (accountType == "CURRENT")
            {
                if (balance >= amount)
                {
                    Transactions.Withdraw(amount);
                    Logger.Log("Withdrawal successful");
                }
                else
                {
                    Logger.Log("Insufficient Funds");
                }
            }
            else
            {
                Console.Clear();
                Logger.Log("Invalid withdrawal amount.");
            }
        }



        public static double CheckBalance()
        {
            double bal = 0;
            foreach (var item in customerList)
            {
                if (item.Key == loggedAccount)
                {
                    Customer customer = item.Value;
                    bal = customer.GetBalance();
                    break;
                }
            }
            return bal;
        }

        

        public static string GetAccountType()
        {
            string accountType = "";
            foreach (var item in customerList)
            {
                if (item.Key == loggedAccount)
                {
                    Customer customer = item.Value;
                    accountType = customer.GetAccountType();
                    break;
                }
            }
            return accountType;
        }



        public static void Transfer(double amount)
        {
            if (amount < 0)
            {
                Logger.Log("Invalid transfer amount.");
            }
            else
            {
                Logger.Log("Input beneficiary account number");
                string beneficiaryAcc = Console.ReadLine();
                if (beneficiaryAcc == loggedAccount)
                {
                    Logger.Log("You cannot transfer to your account.");
                }
                else
                {
                    double balance = loggedCustomer.GetBalance();
                    string accountType = loggedCustomer.GetAccountType();

                    if (accountType == "SAVINGS" && (balance - 1000) < amount)
                    {
                        Logger.Log("Insufficient funds");
                        return;
                    }

                    if (balance >= amount)
                    {
                        bool transferSuccess = TransferMoney(beneficiaryAcc, amount);

                        if (transferSuccess)
                        {
                            Logger.Log("Transfer successful");
                        }
                        else
                        {
                            Logger.Log("Invalid recipient account");
                        }
                    }
                    else
                    {
                        Logger.Log("Insufficient balance");
                    }
                }
            }
        }

        public static bool TransferMoney(string beneficiaryAcc, double amount)
        {
            foreach (var regUsers in customerList)
            {
                if (regUsers.Key == beneficiaryAcc)
                {
                    double currentBalance = loggedCustomer.GetBalance() - amount;
                    loggedCustomer.SetBalance(currentBalance);

                    double beneBalance = regUsers.Value.GetBalance() + amount;
                    regUsers.Value.SetBalance(beneBalance);

                    string[] values = { regUsers.Value.GetFullname(), amount.ToString(), beneficiaryAcc, regUsers.Value.GetAccountType(), currentBalance.ToString(), "CREDIT" };
                    statements.Add(new KeyValuePair<string, string[]>(beneficiaryAcc, values));


                    string[] value = { loggedCustomer.GetFullname(), amount.ToString(), loggedAccount, loggedCustomer.GetAccountType(), currentBalance.ToString(), "DEBIT" };
                    statements.Add(new KeyValuePair<string, string[]>(loggedAccount, value));
                    AccountStatement.SaveStatementToFile();
                    ListOfCustomers.SaveCustomerToFile();
                    return true;
                }
            }

            return false;
        }




    }
}
