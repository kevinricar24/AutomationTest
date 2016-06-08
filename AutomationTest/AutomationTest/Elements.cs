using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

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

        public static void ButtonClick(this IWebDriver driver)
        {
            var ButtonRegister = driver.FindElement(By.CssSelector(".btn.btn-default"));
            ButtonRegister.Click();
        }

        public static void SendTextToField(this IWebDriver driver, string IdField, string text)
        {
            var EmailField = driver.FindElement(By.Id(IdField));
            EmailField.Clear();
            EmailField.SendKeys(text);
        }

    }
}
