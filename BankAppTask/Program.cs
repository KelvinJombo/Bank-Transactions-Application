using BankAppTask.Model;
using BankAppTask.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filePath = ListOfCustomers.filePath;

            if (File.Exists(filePath))
            {
                ListOfCustomers.LoadCustomerFromFile();
            }

            var statementFilePath = AccountStatement.filePath;

            if (File.Exists(statementFilePath))
            {
                AccountStatement.LoadStatementFromFile();

            }

            


            Welcome welcome = new Welcome();

            welcome.WelcomeUser();


        }


    }
}
