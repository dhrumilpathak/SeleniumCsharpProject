using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Csharp.Framework.Utilies;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Selenium.Csharp.Framework.Pages
{
    public class LoginPage : BaseTest
    {

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {

            this.driver = driver;
          //  PageFactory.InitElements(driver, this);

        }
     

        private By Login_username = By.Id("txtUsername");
        private By Login_Button = By.Id("btnLogin");
        private By Login_Password = By.Id("txtPassword");

        public LoginPage EnterUserName(string username)
        {
            driver.FindElement(Login_username).SendKeys(username);
            //  Login_username.SendKeys(username);
            return this;
        }

        public LoginPage EnterPassword(string password )
        {
            driver.FindElement(Login_Password).SendKeys(password);
            return this;
        }
        public HomePage ClickLoginButton()
        {

           
            driver.FindElement(Login_Button).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("menu_dashboard_index")));
            
            return new HomePage(getDriver());


        }



        





    }
}
