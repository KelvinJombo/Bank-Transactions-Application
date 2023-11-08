using BankAppTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppTask.Services
{
    public class Logged
    {
        //Demonstration of fields encapsulation and properties get and set methods.
        public static string loggedAccount { get; set; }

        public static Customer loggedCustomer { get; set; }

    }
}
