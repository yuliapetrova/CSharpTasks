using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        public static string NoDraftXPAth = "//*[contains(text(), 'У вас нет незаконченных или неотправленных писем')]";


        [FindsByAll]

        private IWebDriver driver;

        public MailPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        public void CreateMail(string adress, string subject, string body)
        {
            new Actions(driver)
              .Click(AdressInput)
              .SendKeys(AdressInput, adress)
              .Click(SubjectInput)
              .SendKeys(SubjectInput, subject)
              .Build().Perform();

            driver.SwitchTo().Frame(Frame);
            BodyInput.SendKeys(body);
            driver.SwitchTo().DefaultContent();
        }
    }
}
