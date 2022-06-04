using System;
using OpenQA.Selenium;
using Selenium.Csharp.Framework.Utilies;
using SeleniumExtras.PageObjects;

namespace Selenium.Csharp.Framework.Pages
{
    public class LoginPage : PageActions
    {
       private IWebDriver driver;


        /*        [FindsBy(How = How.Id, Using = "txtUsername")]
             private IWebElement Login_username;

               [FindsBy(How = How.Id, Using = "txtPassword")]
               private IWebElement Login_Password;

                //[FindsBy(How = How.Id, Using = "btnLogin")]
                // private IWebElement Login_Button;

                */

        private By Login_username = By.Id("txtUsername");
        private By Login_Button = By.Id("btnLogin");
        private By Login_Password = By.Id("txtPassword");

        public LoginPage EnterUserName(string username)
        {
            Driver.getDriver().FindElement(Login_username).SendKeys(username);
            //  Login_username.SendKeys(username);
            return this;
            
        }

        public LoginPage EnterPassword(string password )
        {
            Driver.getDriver().FindElement(Login_Password).SendKeys(password);
            return this;
            
        
        }
        public HomePage ClickLoginButton()
        {
            Click(Login_Button);
            CommonMethods.explicitWait();


            return new HomePage();
               

        }



        





    }
}
