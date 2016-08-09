using System;
using OpenQA.Selenium;

namespace Automation_samples.webdriver.pages.PageObjectPattern
{
    class HomeMailPage
    {
        private const string CreateMailButtonClassName = "b-toolbar__btn__text";
        private const string GotoDraftsXPath = "//a[contains(@data-mnemo,'drafts')]";
        private const string GotoSentMailXPath = "//a[@href='/messages/sent/']";
        private const string SentDraftXPath = "//div[@data-name='send']";
        private const string SaveDraftXPath = "//div[contains(@data-name,'saveDraft')]";
        private const string LogoffButtonId = "PH_logoutLink";


        private IWebDriver driver;

        public HomeMailPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public IWebElement CreateMailPage => driver.FindElement(By.ClassName(CreateMailButtonClassName));

        public IWebElement GotoDraftsFolder => driver.FindElement(By.XPath(GotoDraftsXPath));

        public IWebElement GotoSentMail => driver.FindElement(By.XPath(GotoSentMailXPath));

        public IWebElement LogoffButton => driver.FindElement(By.Id(LogoffButtonId));

        public IWebElement SentDraftButton => driver.FindElement(By.XPath(SentDraftXPath));

        public IWebElement SaveDraftButton => driver.FindElement(By.XPath(SaveDraftXPath));

        public MailPage OpenCreateMailPage()
        {
            CreateMailPage.Click();
            return new MailPage(driver);
        }
        
        public DraftsPage OpenDraftsFolder()
        {
            GotoDraftsFolder.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            return new DraftsPage(driver);
        }

        public void OpenSentFolder()
        {
            GotoSentMail.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        public void SentDraft()
        {
            SentDraftButton.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
         }

        public void SaveDraft()
        {
            SaveDraftButton.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        public void Logoff()
        {
            LogoffButton.Click();
        }
    }
}
