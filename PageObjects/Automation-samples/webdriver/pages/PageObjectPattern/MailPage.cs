using OpenQA.Selenium;

namespace Automation_samples.webdriver.pages.PageObjectPattern
{
    class MailPage
    {
        private const string AdressXPAth = "//textarea[contains(@data-original-name,'To')]";
        private const string SubjectXPAth = "//input[contains(@name, 'Subject')]";
        private const string FraneXPath = "//iframe[@title='{#aria.rich_text_area}']";
        private const string BodyXPAth = "//*[@id='tinymce']";
        public static string DraftXPAth = "//a[@data-subject='Test']";
        
        private IWebDriver driver;

        public MailPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement AdressInput => driver.FindElement(By.XPath(AdressXPAth));

        public IWebElement SubjectInput => driver.FindElement(By.XPath(SubjectXPAth));

        public IWebElement Frame => driver.FindElement(By.XPath(FraneXPath));

        public IWebElement BodyInput => driver.FindElement(By.XPath(BodyXPAth));


        public void CreateMail(string adress, string subject, string body)
        {
            AdressInput.Clear();
            AdressInput.SendKeys(adress);
            SubjectInput.Clear();
            SubjectInput.SendKeys(subject);
            driver.SwitchTo().Frame(Frame);
            BodyInput.Clear();
            BodyInput.SendKeys(body);
            driver.SwitchTo().DefaultContent();
        }
 
    }
}

