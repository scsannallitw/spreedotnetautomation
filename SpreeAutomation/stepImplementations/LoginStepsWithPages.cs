using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium.Chrome;
using Xunit.Abstractions;

namespace SpreeAutomation.stepImplementations
{
    public class LoginStepsWithPages
    
    {
        private readonly ITestOutputHelper _testOutputHelper;
        
        public LoginStepsWithPages(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
   
        }

        public string Login(string email, string password)
        {
            _testOutputHelper.WriteLine(Directory.GetCurrentDirectory());
            var driver = new ChromeDriver(Directory.GetCurrentDirectory()+"/lib"); 
            // Navigate to login page
            driver.Navigate().GoToUrl("http://0.0.0.0:3000");
            driver.FindElementById("link-to-login").Click();
            
            // Enter username & password
            driver.FindElementById("spree_user_email").SendKeys(email);
            driver.FindElementById("spree_user_password").SendKeys(password);
            // Click login
            driver.FindElementByName("commit").Click();
            var text = driver.FindElementByLinkText("My Account").GetAttribute("text");
            driver.Close();
            return text;
        }
    }
}