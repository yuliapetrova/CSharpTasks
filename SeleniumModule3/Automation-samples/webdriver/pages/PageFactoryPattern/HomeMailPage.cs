using System;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using static Automation_samples.webdriver.tests.TestBase;

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
            new Actions(driver).Click(CreateMailPage).Build().Perform(); 
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            return new MailPage(driver);
        }

        public DraftsPage OpenDraftsFolder()
        {
            driver.Navigate().GoToUrl("https://e.mail.ru/messages/drafts/");
            wait(d => d.Title.Contains("Черновики"));
            return new DraftsPage(driver);
        }

        public void OpenSentFolder()
        {
            GotoSentMail.Click();
            wait(d => d.Title.Contains("Отправленные"));
        }

        public void SentDraft()
        {
            SentDraftButton.Click();
            //  wait(d => d.FindElement(By.XPath("//a[contains(text(), 'Перейти во Входящие')]")).Displayed); 
         //   driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(10000);


        }

        public void SaveDraft()
        {
            SaveDraftButton.Click();
            wait(d => d.FindElement(By.CssSelector("[data-mnemo=saveStatus]")).Text.Contains("Сохранено в"));
        }

        public void Logoff()
        {
            LogoffButton.Click();
        }
    }
}
