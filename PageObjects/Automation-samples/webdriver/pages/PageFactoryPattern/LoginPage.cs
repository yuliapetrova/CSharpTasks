using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_samples.webdriver.pages.PageFactoryPattern
{
    class LoginPage
    {

        [FindsBy(How = How.CssSelector, Using = ".login-page__external_input__login")]
        private IWebElement LoginInput;

        [FindsBy(How = How.CssSelector, Using = ".login-page__external_input__password")]
        private IWebElement PasswordInput;

        [FindsBy(How = How.ClassName, Using = "js-login-page__external__submit")]
        private IWebElement SubmitButton;

        public const string LoginPageUrl = "https://e.mail.ru/login";
  
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void OpenUrl()
        {
            driver.Navigate().GoToUrl(LoginPageUrl);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
        }

        public HomeMailPage SignIn(string username, string password)
        {
            LoginInput.Clear();
            LoginInput.SendKeys(username);
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
            SubmitButton.Click();
            return new HomeMailPage(driver);
        }
    }
}
