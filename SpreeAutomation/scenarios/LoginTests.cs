using System.IO;
using OpenQA.Selenium.Chrome;
using SpreeAutomation.stepImplementations;
using Xunit;
using Xunit.Abstractions;

namespace SpreeAutomation.scenarios
{
    public class LoginTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public LoginTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void VerifyValidLogin()
        {
            _testOutputHelper.WriteLine(Directory.GetCurrentDirectory());
            var driver = new ChromeDriver(Directory.GetCurrentDirectory()+"/lib");
           
            // Navigate to login page
            driver.Navigate().GoToUrl("http://0.0.0.0:3000");
            driver.FindElementById("link-to-login").Click();
            
            // Enter username & password
            driver.FindElementById("spree_user_email").SendKeys("abc@abc.com");
            driver.FindElementById("spree_user_password").SendKeys("password");
            // Click login
            driver.FindElementByName("commit").Click();
            string loginText = driver.FindElementByLinkText("My Account").GetAttribute("text");

            driver.Close();
            Assert.Equal(loginText, "My Account");
        }
    }
}