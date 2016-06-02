using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace AutomationTest
{
    
    public abstract class TestBase
    {

        protected IWebDriver driver;
        public string URLPage = @"http://localhost:51492/";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            OnOneTimeSetUp();
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine(@"Running {0}", GetTestName());
            OnSetUp();
        }

        [TearDown]
        public void TearDown()
        {
            OnTearDown();
            string ResultTest = string.Empty;
            ResultTest = TestContext.CurrentContext.Result.Outcome.Status.ToString();
            if (driver == null) return;

            try
            {
                //CheckJavascriptErrors();
            }
            finally
            {
                if (ResultTest.Equals("Failed"))
                {
                    CaptureImage(ResultTest, string.Empty);
                }
            }
            Console.WriteLine(@"" + ResultTest + " {0}", GetTestName());
        }

      
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            OnOneTimeTearDown();
            if(driver != null)
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Close();
                driver.Quit();
                driver.Dispose();
            }
        }

        protected virtual void OnOneTimeSetUp()
        {
        }

        protected virtual void OnSetUp()
        {
        }

        protected virtual void OnTearDown()
        {
        }

        protected virtual void OnOneTimeTearDown()
        {
        }

        private static string GetTestName()
        {
            return TestContext.CurrentContext.Test.FullName;
        }

        public string msgerror(string var1, string var2)
        {
            return "Error: the values " + var1 + " = " + var2 + " Should be equals";
        }

        private void CheckJavascriptErrors()
        {
            var js = (IJavaScriptExecutor)driver;
            var javascriptErrors = js.ExecuteScript("return window.jsErrors;") as ICollection;

            Assert.IsNotNull(javascriptErrors, "Can't seem to load JavaScript on the page to find JavaScript errors. Check that JavaScript is enabled.");

            var errorTexts = javascriptErrors.Cast<string>().ToList();
            if (errorTexts.Count > 0)
            {
                Console.WriteLine(@"Javascript errors found in {0}:", GetTestName());
                foreach (var errorText in errorTexts)
                {
                    Console.WriteLine(errorText);
                }
                var javaScriptErrorsAsString = string.Join(",", errorTexts);
                Assert.Inconclusive("Found JavaScript errors: " + javaScriptErrorsAsString);
            }
        }

        private void CaptureImage(string folder, string captureName)
        {
            try
            {
                var captureDriver = driver as ITakesScreenshot;
                if (captureDriver != null)
                {
                    var screenshot = captureDriver.GetScreenshot();
                    var path = Path.Combine(TestContext.CurrentContext.WorkDirectory, folder);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string captureSuffix = string.Empty;
                    if (!string.IsNullOrEmpty(captureName))
                    {
                        captureSuffix = "_" + captureName;
                    }

                    var filename = string.Format("{0}{1}.png", TestContext.CurrentContext.Test.FullName, captureSuffix);
                    screenshot.SaveAsFile(Path.Combine(path, filename), ImageFormat.Png);
                }
            }
            catch
            {
            }
        }

    }
}
