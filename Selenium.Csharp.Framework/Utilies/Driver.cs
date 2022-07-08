using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium.Csharp.Framework.Utilies
{
    [SetUpFixture]
    public class Driver
    {


  

       // public static IWebDriver driver { get; set; }
        // public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();



        [SetUp]
        public static IWebDriver InitDriver()
        {
            string url = ConfigurationManager.AppSettings["URL"];
            if (driver is null)
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
                //setDriver(driver);
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
 
            }

            return driver;
        }
        public static void quitDriver() 
        {

            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
           
        }
    }
}