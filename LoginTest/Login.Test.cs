using BankAppTask.Model;
using BankAppTask.Services;

namespace LoginTest
{
    public class LoginTests

    {

        
            [Fact]
            public void CheckLogin_PasswordMatches_ReturnsTrue()
            {
                // Arrange
                var foundCustomer = new Customer("Kelvin", "Okey", "080111111111", "ada@gmail.com", "savings","ada123@", "11111222223");
                var password = "ada123@";

                // Act
                bool result = Login.CheckLogin(foundCustomer, password);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void CheckLogin_PasswordDoesNotMatch_ReturnsFalse()
            {
                // Arrange
                var foundCustomer = new Customer("Kelvin", "Okey", "080111111111", "ada@gmail.com", "savings", "ada123@", "11111222223");
                var password = "invalidPassword";

                // Act
                bool result = Login.CheckLogin(foundCustomer, password);

                // Assert
                Assert.False(result);
            }
        


    }

}
    
