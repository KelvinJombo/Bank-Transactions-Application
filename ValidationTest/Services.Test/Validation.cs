using BankAppTask.Services;

namespace ValidationTest.Services.Test
{
    public class ValidationTests

    {
        

        // Check valid phone
        [Theory]
        [InlineData("08160417161", true)]
        [InlineData("081604161", false)]
        [InlineData("0816041d161", false)]
        [InlineData("09160417161", true)]
        public void PhoneCheck_ValidNumber_ReturnsSameNumber(string phone, bool expected)
        {
            //Arrange and Act
            bool result = Validation.CheckValidPhone(phone);

            //Assert
            Assert.Equal(expected, result);
        }

        //Check valid password


        [Theory]
        [InlineData("1234A$", true)]
        [InlineData("123456", false)]
        [InlineData("12ah@@", true)]
        [InlineData("kelvin", false)]
        public void CheckForValidPassword(string password, bool expected)
        {
            //Arrange and Act
            bool result = BankAppTask.Services.Validation.CheckPassword(password);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Kelvin", true)]
        [InlineData("2fine", false)]
        [InlineData("Jombo", true)]
        [InlineData("#ken!do", false)]

        public void CheckIsNameValid(string name, bool expected)
        {
            //Arrange and Act
            bool result = BankAppTask.Services.Validation.IsNameValid(name);

            //Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("kelly@yahoo.com", true)]
        [InlineData("2fineing", false)]
        [InlineData("Jombo2com", false)]
        [InlineData("kelly02@gmail.com", true)]

        public void CheckIsValidEmail(string email, bool expected)
        {
            //Arrange and Act
            bool result = BankAppTask.Services.Validation.IsValidEmail(email);

            //Assert
            Assert.Equal(expected, result);

        }




    }
}