using System;
using OpenQA.Selenium;

namespace Selenium.Csharp.Framework.Utilies
{
    public class PageActions :BaseTest
    {


        public IWebDriver driver;

        
        protected void Click(By by)
        {

            driver.FindElement(by).Click();

        }

    }
}
