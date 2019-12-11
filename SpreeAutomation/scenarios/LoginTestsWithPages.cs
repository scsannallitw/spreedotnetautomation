using SpreeAutomation.stepImplementations;
using Xunit;
using Xunit.Abstractions;

namespace SpreeAutomation.scenarios
{
    public class LoginTestsWithPages
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public LoginTestsWithPages(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void VerifyValidLogin()
        {
            LoginStepsWithPages loginSteps = new LoginStepsWithPages(_testOutputHelper);
            var loginText = loginSteps.Login("abc@abc.com", "password");
            Assert.Equal(loginText, "My Account");
        }
    }
}