
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Csharp.Framework.DataHandler;
using Selenium.Csharp.Framework.Pages;
using System.Threading;

//[assembly:Parallelizable(ParallelScope.Fixtures)]
//[assembly:LevelOfParallelism(3)]

namespace Selenium.Csharp.Framework.Tests
{
    [TestFixture]
      public sealed class HomePage_Test : BaseTest
    {


        [TestCaseSource(typeof(ReadJsonData), nameof(ReadJsonData.ReadJsonLoginArray))]

        public void TestPass(User data)
        {



        }
     //   [Parallelizable(ParallelScope.All)]
        [TestCase("Admin","admin123")]
        public void LoginHRM_Test1(string username, string password)
        {
                LoginPage _loginPage = new LoginPage(getDriver());
                HomePage _homePage = new HomePage(getDriver());
                _loginPage.EnterUserName(username);
                _loginPage.EnterPassword(password);
                _loginPage.ClickLoginButton();
                 Thread.Sleep(5000);
                _homePage.ClickWelcome();
                _homePage.ClickLogout();

            }
        //[Parallelizable(ParallelScope.All)]
        [TestCase("Admin", "admin123")]
        public void LoginHRM_Test(string username, string password)
        {
            LoginPage _loginPage = new LoginPage(getDriver());
            HomePage _homePage = new HomePage(getDriver());
            _loginPage.EnterUserName(username);
            _loginPage.EnterPassword(password);
            _loginPage.ClickLoginButton();
            _homePage.ClickWelcome();
            _homePage.ClickLogout();

        }

    }
}

