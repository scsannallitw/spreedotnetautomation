using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using SpreeAutomation.stepImplementations;
using Xunit;
using Xunit.Abstractions;

namespace SpreeAutomation.scenarios
{
    public class LoginTestsWithSteps
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public LoginTestsWithSteps(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void VerifyValidLogin()
        {
            LoginSteps loginSteps = new LoginSteps(_testOutputHelper);
            var loginText = loginSteps.Login("abc@abc.com", "password");
            Assert.Equal(loginText, "My Account");
        }
    }

  
}