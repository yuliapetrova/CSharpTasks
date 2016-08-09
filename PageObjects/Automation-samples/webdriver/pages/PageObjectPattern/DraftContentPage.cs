using OpenQA.Selenium;

namespace Automation_samples.webdriver.pages.PageObjectPattern
{
    class DraftContentPage
    {
        private IWebDriver driver;

        private const string AdressXPAth = "//input[contains(@name,'To')]";
        private const string SubjectXPAth = "//input[contains(@name, 'Subject')]";
        private const string FraneXPath = "//iframe[@title='{#aria.rich_text_area}']";
        private const string BodyXPAth = "//div[contains(@id,'style')]";

        public DraftContentPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement AdressInput => driver.FindElement(By.XPath(AdressXPAth));

        public IWebElement SubjectInput => driver.FindElement(By.XPath(SubjectXPAth));

        public IWebElement BodyInput => driver.FindElement(By.XPath(BodyXPAth));

        public IWebElement Frame => driver.FindElement(By.XPath(FraneXPath));
    }
}
