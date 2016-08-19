using System;
using Automation_samples.webdriver.tests;
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
            MyPageFactoryTest.wait(d => d.Title.Contains("Новое письмо"));
            return new DraftContentPage(driver);
        }
    }
}
