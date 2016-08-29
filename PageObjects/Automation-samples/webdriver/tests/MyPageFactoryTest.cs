using Automation_samples.webdriver.pages.PageFactoryPattern;
using NUnit.Framework;
using OpenQA.Selenium;
using static Automation_samples.webdriver.tests.TestBase;

namespace Automation_samples.webdriver.tests
{
    [TestFixture]
    public class MyPageFactoryTest
    {
        private const string LOGIN = "yuliaautotest";
        private const string PASS = "impulse2016";
        private const string ADRESS = "yuliaautotest@mail.ru";
        private const string SUBJECT = "Test";
        private const string BODY = "Hello!";
        private LoginPage loginPage = new LoginPage(driver);
        private HomeMailPage homeMailPage = new HomeMailPage(driver);
        private DraftsPage draftPage = new DraftsPage(driver);

        [Test]
        public void GotoLoginPage()
        {
            loginPage.OpenUrl();
            Assert.AreEqual("Вход - Почта Mail.Ru", driver.Title);
        }

        [Test]
        public void LoginTest()
        {
            loginPage.SignIn(LOGIN, PASS);
            StringAssert.Contains("Входящие - Почта Mail.Ru", driver.Title);
        }

        [Test]
        public void VerifyDfafts()
        {
            MailPage mailPage = homeMailPage.OpenCreateMailPage();
            mailPage.CreateMail(ADRESS, SUBJECT, BODY);
            homeMailPage.SaveDraft();
            wait(d => d.FindElement(By.CssSelector("[data-mnemo=saveStatus]")).Text.Contains("Сохранено в"));
            homeMailPage.OpenDraftsFolder();
            wait(d => d.Title.Contains("Черновики"));
            Assert.True(isElementPresent(By.XPath(MailPage.DraftXPAth)), "Draft was not found in Drafts folder!");
        }

        [Test]
        public void VerifyDraftContent()
        {
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
            homeMailPage.SentDraft();
            homeMailPage.OpenDraftsFolder();
            Assert.False(isElementPresent(By.XPath(MailPage.DraftXPAth)), "Draft is still presented in Drafts folder!");
        }

        [Test]
        public void VerifySendFolder()
        {
            homeMailPage.OpenSentFolder();
            Assert.True(isElementPresent(By.XPath(MailPage.DraftXPAth)), "Draft was not found in Sent folder!");
            homeMailPage.Logoff();
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
        }
        
    }
}
