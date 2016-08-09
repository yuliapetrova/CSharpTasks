using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_samples.webdriver.pages.PageFactoryPattern
{
    class DraftContentPage
    {
        [FindsBy(How = How.CssSelector, Using = "input[name*=To]")]
        public IWebElement AdressInput;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name, 'Subject')]")]
        public IWebElement SubjectInput;

        [FindsBy(How = How.XPath, Using = "//iframe[@title='{#aria.rich_text_area}']")]
        public IWebElement Frame;

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'style')]")]
        public IWebElement BodyInput;

        private IWebDriver driver;

        public DraftContentPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
