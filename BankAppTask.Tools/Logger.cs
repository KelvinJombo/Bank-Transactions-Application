using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;         

namespace BankAppTask.Tools
{
    public class Logger
    {

        // Just to reduce the occurrence of Console.WriteLine in the code.
        public static void Log(string message)
        {
           // Console.WriteLine(message);
            Console.WriteLine(message);
        }
    }
}
