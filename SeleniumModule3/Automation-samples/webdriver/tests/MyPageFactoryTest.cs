using System;
using Automation_samples.webdriver.pages.PageFactoryPattern;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using static Automation_samples.webdriver.tests.TestBase;

namespace Automation_samples.webdriver.tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class MyPageFactoryTest
    {
        private const string LOGIN = "yuliaautotest";
        private const string PASS = "impulse2016";
        private const string ADRESS = "yuliaautotest@mail.ru";
        private const string SUBJECT = "Test";
        private const string BODY = "Hello!";

     [SetUp]
        public static void SetupTest()
        {
            DesiredCapabilities capability = DesiredCapabilities.Chrome();

            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability);

        }

        [Test]
        public void GotoLoginPage()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.OpenUrl();
            Assert.AreEqual("Вход - Почта Mail.Ru", driver.Title);
        }

       [Test]
        public void LoginTest()
        {
           LoginPage loginPage = new LoginPage(driver);
           loginPage.SignIn(LOGIN, PASS);
           StringAssert.Contains("Входящие - Почта Mail.Ru", driver.Title);
        }

       [Test]
        public void VerifyDfafts()
        {
            HomeMailPage homeMailPage = new HomeMailPage(driver);
            MailPage mailPage = homeMailPage.OpenCreateMailPage();
            mailPage.CreateMail(ADRESS, SUBJECT, BODY);
            homeMailPage.SaveDraft();
            homeMailPage.OpenDraftsFolder();
            Assert.True(isElementPresent(By.XPath(MailPage.DraftXPAth)), "Draft was not found in Drafts folder!");
        }

       [Test]
        public void VerifyDraftContent()
        {
            DraftsPage draftPage = new DraftsPage(driver);
            DraftContentPage draftContent = draftPage.OpenDraft();
            Assert.That(draftContent.AdressInput.GetAttribute("value"), Does.Contain(ADRESS), "Adress is not correct");
            Assert.That(draftContent.SubjectInput.GetAttribute("value"), Does.Contain(SUBJECT), "Subject is not correct");
            driver.SwitchTo().Frame(draftContent.Frame);
            Assert.That(draftContent.BodyInput.Text, Does.Contain(BODY), "Mail text is not correct");
            driver.SwitchTo().DefaultContent();
        }

       [Test]
        public void VerifyDraftDisappeared()
        {
            HomeMailPage homeMailPage = new HomeMailPage(driver);
            homeMailPage.SentDraft();
            homeMailPage.OpenDraftsFolder();
            Assert.True(isElementPresent(By.XPath(MailPage.NoDraftXPAth)), "Drafts folder is not emplty!");
        }

       [Test]
        public void VerifySendFolder()
        {
            HomeMailPage homeMailPage = new HomeMailPage(driver);
            homeMailPage.OpenSentFolder();
            Assert.True(isElementPresent(By.XPath(MailPage.DraftXPAth)), "Draft was not found in Sent folder!");
            homeMailPage.Logoff();
        }

        [TearDown]
        public static void Teardown()
        {
            driver.Quit();
        }

    }
}
