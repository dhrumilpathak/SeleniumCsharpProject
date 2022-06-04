using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium.Csharp.Framework.Utilies
{
    public class CommonMethods
    {
        public CommonMethods()
        {
        }

        public static void explicitWait()
        {
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromMinutes(2));
             wait.Until(ExpectedConditions.ElementIsVisible(By.Id("menu_dashboard_index")));
        }
    }
}
