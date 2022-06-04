using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Csharp.Framework.Utilies;
using WebDriverManager.DriverConfigs.Impl;
using Selenium.Csharp.Framework.DataHandler;

namespace Selenium.Csharp.Framework
{
    public class BaseTest
    {
       

       [SetUp]
        public void Setup()
        {
            Driver.InitDriver();
        }

        [TearDown]
        public void quit()
        {
            Driver.quitDriver();
        }

    }
}
