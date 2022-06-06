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


  

        public static IWebDriver driver { get; set; }

   
       
     

        //private static ThreadLocal<IWebDriver> dr = new ThreadLocal<IWebDriver>();

        //public static IWebDriver getDriver()
        //{
        //    return dr.Value;
        //}
        //public static void setDriver(IWebDriver driver)
        //{
        //    dr.Value = driver;
        // }

        //[SetUp]
        //public static void InitDriver()
        //{
        //    string url = ConfigurationManager.AppSettings["URL"];
        //    if (driver is null)
        //    {
        //        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        //        driver = new ChromeDriver();
        //       setDriver(driver);
        //        getDriver().Navigate().GoToUrl(url);
        //        getDriver().Manage().Window.Maximize();
        //    }
        //}


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