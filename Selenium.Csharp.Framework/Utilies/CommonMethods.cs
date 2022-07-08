using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Selenium.Csharp.Framework.Utilies
{
    public class CommonMethods 
    {
        IWebDriver driver = null;
        public void explicitWait()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("menu_dashboard_index")));
        }
    } 
}
