using BankAppTask.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankAppTask.Services
{
    public class Validation
    {

        public static string EmailCheck()
        {
            string email = " ";
            
            while (!IsValidEmail(email))
            {
                Console.WriteLine("Input Your Email Here, Correctly");

                email = Console.ReadLine();

                Console.Clear();
            }
            return email;
        }


        public static bool IsValidEmail(string email)
        {
            return email.EndsWith("@yahoo.com") || email.EndsWith("@gmail.com");
        }


        public static string NameCheck(string name)
        {
            string nam = name;
            while (!IsNameValid(nam))
            {
                Logger.Log("Name is incorrect format. Try again");
                nam = Console.ReadLine();
            }

            return nam;

        }

        public static bool IsNameValid(string name)
        {
            return Regex.IsMatch(name, @"^[A-Za-z]+$");
        }


        public static string PasswordCheck(string password)
        {
            string pass = password;
            while (!CheckPassword(pass))
            {
                Console.WriteLine("Password is not in correct format. Try again");
                pass = Console.ReadLine();
            }
            return pass;
        }

        public static bool CheckPassword(string password)
        {
            if (Regex.IsMatch(password, @"^(?=.*[a-zA-Z0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        


        public static string PhoneCheck(string phoneNumber)
        {
            string phone = phoneNumber;

            while (!CheckValidPhone(phone))
            {
                Console.WriteLine("Phone number in not in correct format. Try again");
                phone = Console.ReadLine();
            }
            return phone;
        }

        public static bool CheckValidPhone(string phone)
        {
            if (Regex.IsMatch(phone, @"^[0]\d{10}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


       

        public static string ConfirmBvn(string bvn)
        {
            

            while (!IsValidBVN(bvn))
            {
                Console.WriteLine("Invalid BVN. \t Enter Your Correct BVN.");
                bvn = Console.ReadLine();   
            }
            return bvn;
             
        }

        static bool IsValidBVN(string bvn)
        {
            
            string pattern = @"^\d{11}$"; 

            
            return Regex.IsMatch(bvn, pattern);
        }
    }



}

