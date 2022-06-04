
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Csharp.Framework.DataHandler;
using Selenium.Csharp.Framework.Pages;

[assembly:Parallelizable(ParallelScope.Fixtures)]
[assembly:LevelOfParallelism(3)]
namespace Selenium.Csharp.Framework.Tests
{
    [TestFixture]
      public sealed class HomePage_Test : BaseTest
    {
       private IWebDriver driver;

        [TestCaseSource(typeof(ReadJsonData), nameof(ReadJsonData.ReadJsonLoginArray))]
   
        public void TestPass(User data)
        {
          
            LoginPage _loginPage = new LoginPage();
            _loginPage.EnterUserName(data.Username).
               EnterPassword(data.password).ClickLoginButton().
               ClickWelcome().ClickLogout();
        }

        [Parallelizable]
        [TestCase("Admin","admin123")]
        public void LoginHRM_Test1(string username, string password)
        {
            LoginPage _loginPage = new LoginPage();
            _loginPage.EnterUserName(username).
            EnterPassword(password).ClickLoginButton().
            ClickWelcome().ClickLogout();

        }
        [Parallelizable]
        [TestCase("Admin", "admin123")]
        public void LoginHRM_Test(string username, string password)
        {
            LoginPage _loginPage = new LoginPage();
            _loginPage.EnterUserName(username).
            EnterPassword(password).ClickLoginButton().
            ClickWelcome().ClickLogout();

        }




    }
}

