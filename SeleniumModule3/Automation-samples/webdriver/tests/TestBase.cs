using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Automation_samples.webdriver.tests
{
    [SetUpFixture]
    public class TestBase
    {
        public static IWebDriver driver;

        public static void wait(Func<IWebDriver, bool> waitAction)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(waitAction);
        }

        public static bool isElementPresent(By by)
        {
            try
            {
                var els = driver.FindElements(by);
                return els.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
