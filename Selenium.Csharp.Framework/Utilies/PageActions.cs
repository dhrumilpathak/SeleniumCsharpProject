using System;
using OpenQA.Selenium;

namespace Selenium.Csharp.Framework.Utilies
{
    public class PageActions 
    {
        IWebDriver driver;


        protected void Click(By by)
        {

            Driver.driver.FindElement(by).Click();

        }

    }
}
