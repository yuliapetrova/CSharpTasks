using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_samples.webdriver.pages.PageFactoryPattern
{
    class DraftsPage
    {

        [FindsBy(How = How.XPath, Using = "//a[@data-subject='Test']")]
        private IWebElement Draft;
 
        private IWebDriver driver;

        public DraftsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        public DraftContentPage OpenDraft()
        {
            Draft.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            return new DraftContentPage(driver);
        }
    }
}
