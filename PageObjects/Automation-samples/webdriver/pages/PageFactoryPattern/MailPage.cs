using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Automation_samples.webdriver.pages.PageFactoryPattern
{
    class MailPage
    {
        [FindsBy(How = How.XPath, Using = "//textarea[contains(@data-original-name,'To')]")]
        private IWebElement AdressInput;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name, 'Subject')]")]
        private IWebElement SubjectInput;

        [FindsBy(How = How.XPath, Using = "//iframe[@title='{#aria.rich_text_area}']")]
        private IWebElement Frame;

        [FindsBy(How = How.XPath, Using = "//*[@id='tinymce']")]
        private IWebElement BodyInput;

        public static string DraftXPAth = "//a[@data-subject='Test']";

        [FindsByAll]

        private IWebDriver driver;

        public MailPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
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
