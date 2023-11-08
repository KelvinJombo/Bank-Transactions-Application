using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppTask.Model
{
    public class ListOfCustomers
    {
        public static Dictionary<string, Customer> customerList = new Dictionary<string, Customer>();

        public static string filePath = "customerList.json";

        public ListOfCustomers()
        {
            if (File.Exists(filePath))
            {
                LoadCustomerFromFile();
            }
        }

        public static void SaveCustomerToFile()
        {
            string json = JsonConvert.SerializeObject(customerList, Formatting.Indented);

            File.WriteAllText(filePath, json);

        }

        

        public static void LoadCustomerFromFile()
        {
            try
            {
                string json = File.ReadAllText(filePath);

                customerList = JsonConvert.DeserializeObject<Dictionary<string, Customer>>(json);

                // Check if loading is successful
                if (customerList != null && customerList.Count > 0)
                {
                    Console.WriteLine("Customer data loaded successfully.");
                }
                else
                {
                    Console.WriteLine("No customer data found in the file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading customer data: {ex.Message}");
                // Handle the exception as needed
            }
        }






        public static void AddCustomer(string accountNo, Customer customer)
        {
            customerList.Add(accountNo, customer);
        }






    }
}
