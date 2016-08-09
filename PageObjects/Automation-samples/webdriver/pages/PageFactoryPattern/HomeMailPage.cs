using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_samples.webdriver.pages.PageFactoryPattern
{
    class HomeMailPage
    {
        [FindsBy(How = How.ClassName, Using = "b-toolbar__btn__text")]
        private IWebElement CreateMailPage;

        [FindsBy(How = How.XPath, Using = "//a[contains(@data-mnemo,'drafts')]")]
        private IWebElement GotoDraftsFolder;

        [FindsBy(How = How.XPath, Using = "//a[@href='/messages/sent/']")]
        private IWebElement GotoSentMail;

        [FindsBy(How = How.XPath, Using = "//div[@data-name='send']")]
        private IWebElement SentDraftButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@data-name,'saveDraft')]")]
        private IWebElement SaveDraftButton;

        [FindsBy(How = How.Id, Using = "PH_logoutLink")]
        private IWebElement LogoffButton;

        [FindsByAll]

        private IWebDriver driver;

        public HomeMailPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public MailPage OpenCreateMailPage()
        {
            CreateMailPage.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
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
