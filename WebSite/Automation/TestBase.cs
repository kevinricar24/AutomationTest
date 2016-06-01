using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace Automation
{
    [TestFixture]
    public class TestBase
    {
        private IWebDriver Driver;
        string URLPage = "http://localhost:61152/";

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("1");
            Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
        }

        [Test]
        public void NumberCase_AboutPageText()
        {
            Driver.Navigate().GoToUrl(URLPage);
            Console.WriteLine("Test");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("2");
            Driver.Close();
            Driver.Quit();
        }

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            Console.WriteLine("3");
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            Console.WriteLine("4");
        }

    }
}
