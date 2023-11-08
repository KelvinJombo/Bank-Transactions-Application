using BankAppTask.Model;
using BankAppTask.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace BankAppTask.Services
{
    public class AccountStatement : Logged
    {
         public static List<KeyValuePair<string, string[]>> statements = new List<KeyValuePair<string, string[]>>();

        public static string filePath = "customerStatement.json";  

        public AccountStatement()
        {
            if (File.Exists(filePath))
            {
                LoadStatementFromFile();  
            }
        }

        public static void SaveStatementToFile()
        {
            string json = JsonConvert.SerializeObject(statements, Formatting.Indented);

            File.WriteAllText(filePath, json);

        }


        public static void LoadStatementFromFile()
        {
            try
            {
                string json = File.ReadAllText(filePath);

                statements = JsonConvert.DeserializeObject<List<KeyValuePair<string, string[]>>>(json);

                 
                if (statements != null && statements.Count > 0)
                {
                    Console.WriteLine("Statement data loaded successfully.");
                }
                else
                {
                    Console.WriteLine("No statement data found in the file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading statement data: {ex.Message}");
                 
            }
        }

        

        static void PrintTable()
        {
            Console.Clear();
            Logger.Log("---------------------------------- ACCOUNT STATEMENT ---------------------------------");
            Logger.Log("|   Customer Name   | Amount | Account Number | Account Type | Balance |   Remarks   |");
            Logger.Log("--------------------------------------------------------------------------------------");


        }
        public static void PrintAccountStatement()
        {
            PrintTable();

            foreach(var item in statements)
            {
                if(item.Key == loggedAccount)
                {
                    string[] value = item.Value;
                    Logger.Log(value[0]+ "   |   " + value[1] + "   |   " + value[2] + "   |   " + value[3] + "   |   " + value[4] + "   |   " + value[5]);
                }
            }
        }
    }
}
