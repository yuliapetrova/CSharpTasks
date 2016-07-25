using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

using NUnit.Framework;
using NUnit.Framework.Constraints;



namespace MailTest
{
    [TestFixture]
    public class UnitTest1
    {
        // Initialoozw driver
        private IWebDriver driver;
        private const String LOGIN = "yuliaautotest";
        private const String PASS = "impulse2016";
        private const String ADRESS = "yuliaautotest@mail.ru";
        private const String SUBJECT = "Test";
        private const String BODY = "Hello!";


        [SetUp]
        public void SetUp()
        {
          //  System.ProsetProperty("webdriver.chrome.driver", PATH_TO_CHROMEDRIVER_EXE);
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

            CreateMail(ADRESS, SUBJECT, BODY);
            SaveDfaft();
            
            FindInDfafts();
        }

        private void DoLogin(String login, String password)
        {
            // Find login input field 
            IWebElement loginInput = driver.FindElement(By.CssSelector(".login-page__external_input__login"));
            // Enter login
            loginInput.SendKeys(login);
            //Find password input field
            IWebElement passInput = driver.FindElement(By.CssSelector(".login-page__external_input__password"));
            // Enter passwprd
            passInput.SendKeys(password);
            //Find input buttton
            IWebElement inputButton = driver.FindElement(By.ClassName("js-login-page__external__submit"));
            //Click it
            inputButton.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        private void CreateMail(String adress, String subject, String body)
        {
            // Click "Написать письмо"
            IWebElement writeMailButton = driver.FindElement(By.ClassName("b-toolbar__btn__text"));
            writeMailButton.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Open adress book and select address
            IWebElement adressBook = driver.FindElement(By.ClassName("compose__header__label__box_addressbook"));
            adressBook.Click();
            IWebElement selectAdress = driver.FindElement(By.ClassName("b-filelabel__item_title__text"));
            selectAdress.Click();
            IWebElement addBtn = driver.FindElement(By.XPath("/html/body/div[8]/div[1]/div/div[2]/button[1]"));
            addBtn.Click();

            // Fill Subject
            IWebElement setSubject = driver.FindElement(By.XPath("//input[contains(@name, 'Subject')]"));
            setSubject.SendKeys(subject);

            // Fill mail Body
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@title='{#aria.rich_text_area}']")));
         //   driver.FindElement(By.XPath("//*[@id='tinymce']")).Click();
            driver.FindElement(By.XPath("//body[@id='tinymce']")).SendKeys(body);
            driver.SwitchTo().DefaultContent();
        }

        private void SaveDfaft()
        {
            
            driver.FindElement(By.XPath("//div[contains(@data-name,'saveDraft')]")).Click();
          //  driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(100));
            Thread.Sleep(10000);
        }
        private void FindInDfafts()
        {
            //Goto Drafts
            driver.FindElement(By.XPath("//a[contains(@data-mnemo,'drafts')]")).Click();
        }











        [TearDown]
        public void Teardown()
        {
          //  driver.Quit();
        }
    }
}
