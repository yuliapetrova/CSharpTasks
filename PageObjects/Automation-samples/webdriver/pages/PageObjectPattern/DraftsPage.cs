using System;
using OpenQA.Selenium;

namespace Automation_samples.webdriver.pages.PageObjectPattern
{
    class DraftsPage
    {
        private const string DraftXPAth = "//a[@data-subject='Test']";

        private IWebDriver driver;

        public DraftsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Draft => driver.FindElement(By.XPath(DraftXPAth));

        public DraftContentPage OpenDraft()
        {
            Draft.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
           // Thread.Sleep(10000);
            return new DraftContentPage(driver);
        }

    }
}
