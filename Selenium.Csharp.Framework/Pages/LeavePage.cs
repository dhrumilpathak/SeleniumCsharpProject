using System;
using OpenQA.Selenium;
using Selenium.Csharp.Framework.Utilies;
using SeleniumExtras.PageObjects;


namespace Selenium.Csharp.Framework.Pages
{
    public class LeavePage : PageActions

    {
        public IWebDriver driver;
        private LeavePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        string checkboxPendingApproval = "leaveList_chkSearchFilter_-1";

        public void checkBox_ClickPendingApproval()
        {
            driver.FindElement(By.Id(checkboxPendingApproval)).Click();
        }
    }
}
