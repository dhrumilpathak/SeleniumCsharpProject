using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;

using Selenium.Csharp.Framework.Utilies;
using WebDriverManager.DriverConfigs.Impl;
using Selenium.Csharp.Framework.DataHandler;
using System;
using System.IO;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace Selenium.Csharp.Framework
{
    public class BaseTest
    {

        protected ExtentReports _extent;
        protected ExtentTest _test;
       
        public ExtentReports extentReport;
       


        [OneTimeSetUp]
        protected void BeforeClassReport()
        {
            var TestName = TestContext.CurrentContext.Test.Name;
            var Datetamp = DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss");
            var str = DateTime.Now.TimeOfDay.ToString();
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
          //  var fileName = string.Format("{0}Reports\\"+TestName+ Datetamp+".html", projectPath, Datetamp);
       var fileName = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")) + "\\TestReport\\"+TestName +"_"+ Datetamp + ".html";
            var htmlReporter = new ExtentV3HtmlReporter(fileName);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
        }
        [SetUp]
        public void Setup()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Testing Started");
            Driver.InitDriver();
                

        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            DateTime time = DateTime.Now;
            string fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                   
                     _test.Log(Status.Fail, "Fail");
                    _test.Log(Status.Fail, "Snapshot below: ");
                    _test.Fail("Test failed", captureScreenShot(Driver.driver, fileName));
                    _test.Log(Status.Fail, "test failed with logtrace" + stacktrace);
                    break;
              
                default:
                    logstatus = Status.Pass;
                    break;


                   
            }
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);

            
            
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            _extent.Flush();
            Driver.driver.Quit();
        }

        public static string Capture(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)

        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }

    }
}
