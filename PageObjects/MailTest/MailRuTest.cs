using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using NUnit.Framework.Constraints;



namespace MailTest
{
    [TestFixture]
    public class MailRuTest
    {
        // Initialoozw driver
        private IWebDriver driver;
        private const String LOGIN = "yuliaautotest";
        private const String PASS = "impulse2016";
        private const String ADRESS = "yuliaautotest@mail.ru";
        private const String SUBJECT = "Test";
        private const String BODY = "Hello!";


        [OneTimeSetUp]
        public void Init()
        {
            driver = new FirefoxDriver();
            // Open web page
            driver.Navigate().GoToUrl("https://e.mail.ru/login");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            Assert.AreEqual("Вход - Почта Mail.Ru", driver.Title);
        }

        [Test]
        public void LoginTest()
        {
            DoLogin(LOGIN, PASS);
            StringAssert.Contains("Входящие - Почта Mail.Ru", driver.Title);
         }

        [Test]
        public void VerifyDfafts()
        {
            CreateMail(ADRESS, SUBJECT, BODY);
            SaveDfaft();
            GoToDraftsFolder();
        // Veify if draft is presented
            Assert.True(isElementPresent(By.XPath("//a[@data-subject='Test']")), "Draft was not found in Drafts folder!");
        }

        [Test]
        public void VerifyDraftContent()
        {
            //Go to the Draft Content
            driver.FindElement(By.XPath("//a[@data-subject='Test']")).Click();
            Thread.Sleep(10000);
            //Verify Address
            IWebElement adressInput = driver.FindElement(By.XPath("//input[contains(@name,'To')]"));
            Assert.That(adressInput.GetAttribute("value"), Does.Contain(ADRESS), "Adress is not correct");

            //Verify Subject
            IWebElement subjectInput = driver.FindElement(By.XPath("//input[contains(@name,'Subject')]"));
            Assert.That(subjectInput.GetAttribute("value"), Does.Contain(SUBJECT), "Subject is not correct");

            //Verify Body
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@title='{#aria.rich_text_area}']")));
            IWebElement mailBody = driver.FindElement(By.XPath("//div[contains(@id,'style')]"));
            
        }

        [Test]
        public void VerifyDraftDisappeared()
        {
            SendMail(); 
            GoToDraftsFolder();
            Assert.False(isElementPresent(By.XPath("//a[@data-subject='Test']")), "Draft is still presented in Drafts folder!");
        }

        [Test]
        public void VerifySendFolder()
        {
            //Go to sent folder
            driver.FindElement(By.XPath("//a[@href='/messages/sent/']")).Click();
            Thread.Sleep(10000);
            // Veify if email is presented
            Assert.True(isElementPresent(By.XPath("//a[@data-subject='Test']")), "Draft was not found in Sent folder!");
            Logoff();
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        private void DoLogin(String login, String password)
        {
            // Find login input field 
            IWebElement loginInput = driver.FindElement(By.CssSelector(".login-page__external_input__login"));
            // Enter login
            loginInput.Clear();
            loginInput.SendKeys(login);
            //Find password input field
            IWebElement passInput = driver.FindElement(By.CssSelector(".login-page__external_input__password"));
            // Enter passwprd
            passInput.Clear();
            passInput.SendKeys(password);
            //Find input buttton
            IWebElement inputButton = driver.FindElement(By.ClassName("js-login-page__external__submit"));
            //Click it
            inputButton.Click();
        }

      
        private void CreateMail(String adress, String subject, String body)
        {
            // Click "Написать письмо"
            IWebElement writeMailButton = driver.FindElement(By.ClassName("b-toolbar__btn__text"));
            writeMailButton.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            //Fill address
            IWebElement setAdress = driver.FindElement(By.XPath("//textarea[contains(@data-original-name,'To')]"));
            setAdress.Clear();
            setAdress.SendKeys(adress);

            // Fill Subject
            IWebElement setSubject = driver.FindElement(By.XPath("//input[contains(@name, 'Subject')]"));
            setSubject.Clear();
            setSubject.SendKeys(subject);

            // Fill mail Body
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@title='{#aria.rich_text_area}']")));
            IWebElement mailBody = driver.FindElement(By.XPath("//*[@id='tinymce']"));
           // mailBody.Click();
            mailBody.Clear();
            mailBody.SendKeys(body);
            driver.SwitchTo().DefaultContent();
        }

        private void SaveDfaft()
        {
            driver.FindElement(By.XPath("//div[contains(@data-name,'saveDraft')]")).Click();
            Thread.Sleep(5000);
        }

        private void GoToDraftsFolder()
        {
            driver.FindElement(By.XPath("//a[contains(@data-mnemo,'drafts')]")).Click();
            Thread.Sleep(10000);
        }

        private void SendMail()
        {
            //Click "Send"
            driver.FindElement(By.XPath("//div[@data-name='send']")).Click();
            Thread.Sleep(10000);
        }
     
        private void Logoff()
        {
            driver.FindElement(By.Id("PH_logoutLink")).Click();
        }

        private bool isElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
            return true;
        }

    }
}
