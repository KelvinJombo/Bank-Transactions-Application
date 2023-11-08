using BankAppTask.Model;
using BankAppTask.Services;

using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace TransactionsTest
{ 
    public class TransactionsTest

    {
        
            [Fact]
            public void DepositToAccount_ShouldIncreaseBalanceCorrectly()
            {     
                // Arrange
                
                 double initialBalance = 1000.0;
                 double depositAmount = 500.0;
                 double currentBalance = initialBalance + depositAmount;
                var customer = new Customer("Kelvin", "Jombo", "08063635197", "kelly20@yahoo.com", "Savings", "Kelvin22!", "22266548764");

                // Act       
                 Transactions.DepositToAccount(customer, currentBalance);

                // Assert

                double expectedBalance = initialBalance + depositAmount;
                Assert.Equal(expectedBalance, currentBalance, 2); 
            }


        [Fact]
        public void DepositToAccount_NotAcceptNegativeDeposite()
        {
            // Arrange

            double initialBalance = 1000.0;
            double depositAmount = -500.0;
            double currentBalance = initialBalance + depositAmount;
            var customer = new Customer("Kelvin", "Jombo", "08063635197", "kelly20@yahoo.com", "Savings", "Kelvin22!", "22266548764");

            // Act       
            Transactions.DepositToAccount(customer, currentBalance);

            // Assert

            double expectedBalance = initialBalance + depositAmount;
            Assert.Equal(expectedBalance, currentBalance, 2);
        }



        [Fact]
        public void WithdrawFromCustomerShouldReduceBalance()
        {
            // Arrange
            double initialBalance = 1000.0;

            double withdrawalAmount = 500.0;
            double currentBalance = initialBalance - withdrawalAmount;

            var customer = new Customer("Kelvin", "Jombo", "08063635197", "kelly20@gmail.com", "Savings", "Kenny23!", "2387980034");

            //Act 
            Transactions.WithdrawFromCustomerAccount(customer, withdrawalAmount);

            // Assert
            double expectedBalance = initialBalance - withdrawalAmount;

            Assert.Equal(expectedBalance, currentBalance, 2);

        }

            [Fact]
            public void WithdrawShouldNotBeMoreThanBalance()
            {
                // Arrange
                double initialBalance = 1000.0;

                double withdrawalAmount = 5000.0;
                double currentBalance = initialBalance - withdrawalAmount;

                var customer = new Customer("Kelvin", "Jombo", "08063635197", "kelly20@gmail.com", "Savings", "Kenny23!", "2387980034");

                //Act 
                Transactions.WithdrawFromCustomerAccount(customer, withdrawalAmount);

                // Assert
                double expectedBalance = initialBalance - withdrawalAmount;

                Assert.Equal(expectedBalance, currentBalance, 2);



            }



        [Fact]
        public void CheckBalance_ShouldReturnCustomerBalance()
        {
            // Arrange
            double expectedBalance = 100.0;

       
            var customer = new Customer("Kelvin", "Jombo", "08063635197", "jenny15@gmail.com", "Savings", "Jane35!", "28476590763");
            customer.SetBalance(100.0);

            var customerList = ListOfCustomers.customerList;
            customerList.Add("12345", customer);
            
            Logged.loggedAccount = "12345";
          

           
            // Act
            double balance = Transactions.CheckBalance();

            // Assert
            Assert.Equal(expectedBalance, balance, 2); 

        }

        [Fact]
        public void CheckBalance_CustomerNotFound_ShouldReturnZero()
        {
            // Arrange
            string loggedAccount = "12345";
            var customerList = new Dictionary<string, Customer>();

            // Act
            double balance = Transactions.CheckBalance();

            // Assert
            Assert.Equal(0.0, balance, 2);
        }



        [Fact]
        public void TransferMoney_ValidBeneficiary_ShouldPerformTransfer()
        {
            // Arrange

            string beneficiaryAccount = "67890";

            var loggedCustomer = new Customer("Kelvin", "Jombo", "08063635197", "kelly@yahoo.com", "Savings", "Kenny20!", "23233445566");
            var beneficiaryCustomer = new Customer("Kelvin", "Jombo", "08063635197", "kelly@yahoo.com", "Current", "Kenny20!", "23233445566");

            ListOfCustomers.AddCustomer("12345", loggedCustomer);
            ListOfCustomers.AddCustomer("67890", beneficiaryCustomer);

            Logged.loggedCustomer = loggedCustomer;
            Logged.loggedAccount = "12345";


            // Act
            bool transferSuccess = Transactions.TransferMoney(beneficiaryAccount, 200.0);

            // Assert
            Assert.True(transferSuccess);

        }

        [Fact]
        public void TransferMoney_InvalidBeneficiary_ShouldNotPerformTransfer()
        {
            // Arrange
            string loggedAccount = "12345";
            string beneficiaryAccount = "67890";
            double initialLoggedCustomerBalance = 1000.0;

            var loggedCustomer = new Customer("Kelvin", "Jombo", "08063635197", "kelly@yahoo.com", "Savings", "Kenny20!", "23233445566");
            ListOfCustomers.customerList.Add("12345", loggedCustomer);
           
            Logged.loggedAccount = "12345";
            Logged.loggedCustomer = loggedCustomer;

            // Act
            bool transferSuccess = Transactions.TransferMoney(beneficiaryAccount, 200.0);

            // Assert
            Assert.False(transferSuccess);

        }
    }
}


