using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Csharp.Framework.Utilies;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Selenium.Csharp.Framework.Pages
{
    public class HomePage:BaseTest

    {

        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        string btnLeavePage = ".//*[@class='quickLaunge']//*[contains(text(),'Leave List')]";

     
        private By link_welcome = By.Id("welcome");
        private By link_logout = By.XPath(".//a[text()='Logout']");
        public void waitforPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(".//*[@id='content']//*[text()='Dashboard']")));
        }

        public HomePage ClickWelcome()
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(2000));
            driver.FindElement(link_welcome).Click();
            return this;
        }

        public HomePage ClickLogout()
        {
            driver.FindElement(link_logout).Click();
            return this;
        }
    }
}
