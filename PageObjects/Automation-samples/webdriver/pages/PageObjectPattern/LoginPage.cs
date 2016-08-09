using System;
using OpenQA.Selenium;

namespace Automation_samples.webdriver.pages.PageObjectPattern
{
    class LoginPage
    {
        public const string LoginPageUrl = "https://e.mail.ru/login";
        private const string LoginCssLocator = ".login-page__external_input__login";
        private const string PasswordCssLocator = ".login-page__external_input__password";
        private const string SubmitButtonClassName = "js-login-page__external__submit";

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement LoginInput => driver.FindElement(By.CssSelector(LoginCssLocator));

        public IWebElement PasswordInput => driver.FindElement(By.CssSelector(PasswordCssLocator));

        public IWebElement SubmitButton => driver.FindElement(By.ClassName(SubmitButtonClassName));

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
