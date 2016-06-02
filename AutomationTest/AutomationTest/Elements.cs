using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    public static class Elements
    {

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            IWebElement element = null;
            if (timeoutInSeconds > 0)
            {
                try
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    element = wait.Until(ExpectedConditions.ElementExists(by));
                }
                catch
                {
                    element = null;
                }

            }
            Assert.IsNotNull(element, "Can't find the element: " + @by);
            return element;
        }

    }
}
