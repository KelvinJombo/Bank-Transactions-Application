using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppTask.Model
{
    public class Customer
    {
        [JsonProperty]
        private string firstname { get; set; }
        [JsonProperty]
        private string lastname { get; set; }
        [JsonProperty]
        private string phoneNumber { get; set; }
        [JsonProperty]
        private string email { get; set; }
        [JsonProperty]
        private double balance { get; set; }
        [JsonProperty]
        private string accountType { get; set; }
        [JsonProperty]
        private string password { get; set; }
        [JsonProperty]
        private string BVN { get; set; }
    public Customer(string fname, string lname, string phone, string email,
        string accountType,string password, string bvn)
        {
            this.firstname = fname;
            this.lastname = lname;
            this.phoneNumber = phone;
            this.email = email;
            this.balance = 0;
            this.accountType = accountType;
            this.password = password;
            this.BVN = bvn;
        }

        public string GetFirstname()
        {
            return firstname;
        }
        public string GetFullname()
        {
            return GetFirstname() + " "+ GetLastname();
        }
        public void SetBalance(double amount)
        {
            balance = amount;
        }

        public string GetLastname()
        {
            return lastname;
        }

        public string GetPhoneNumber()
        {
            return phoneNumber;
        }

        public string GetEmail()
        {
            return email;
        }

        public string GetAccountType()
        {
            return accountType;
        }

        public string GetPassword()
        {
            return password;
        }
        public double GetBalance()
        {
            return balance;
        }

        public string GetBVN()
        {
            return BVN;
        }

    }
}
