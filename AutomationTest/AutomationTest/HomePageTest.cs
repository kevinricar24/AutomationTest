using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    [TestFixture]
    public class HomePageTest : TestBase
    {
        string TitlePage = "Home Page - My ASP.NET Application";

        //Block HomeTextPage
        string HomeTitle = "ASP.NET";
        string HomeParagraph = "ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.";
        string Homelink = "http://www.asp.net/";
        
        string HomeSubtitleCol1 = "Getting started";
        string HomeParagraphCol1 = "ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that enables a clean separation of concerns and gives you full control over markup for enjoyable, agile development.";
        string HomeSublinkCol1 = "http://www.asp.net/mvc";

        string HomeSubtitleCol3 = "Web Hosting";
        string HomeParagraphCol3 = "You can easily find a web hosting company that offers the right mix of features and price for your applications.";
        string HomeSublinkCol3 = "http://www.asp.net/#migrateidentity";

        string HomelinkText = "Learn more »";

        protected override void OnSetUp()
        {
            driver.Navigate().GoToUrl(URLPage);
            Assert.AreEqual(TitlePage, driver.Title, msgerror(TitlePage, driver.Title));
        }

        [Test]
        public void TestCase001_ValidateSectionUpHome()
        {
            var Title = driver.FindElement(By.ClassName("jumbotron")).FindElement(By.TagName("h1"));
            Assert.AreEqual(HomeTitle, Title.Text, msgerror(HomeTitle, Title.Text));

            var paragraph = driver.FindElement(By.ClassName("lead"));
            Assert.AreEqual(HomeParagraph, paragraph.Text, msgerror(HomeParagraph, paragraph.Text));

            var link = driver.FindElement(By.CssSelector(".btn.btn-primary.btn-lg"));
            Assert.AreEqual(HomelinkText, link.Text, msgerror(HomelinkText, link.Text));

            link.Click();
            Assert.AreEqual(Homelink, driver.Url, msgerror(Homelink, driver.Url));
        }

        [Test]
        public void TestCase002_ValidateFirstColumnDownHome()
        {
            var Subtitle = driver.FindElement(By.XPath("html/body/div[2]/div[2]/div[1]/h2"), 30);
            Assert.AreEqual(HomeSubtitleCol1, Subtitle.Text, msgerror(HomeSubtitleCol1, Subtitle.Text));

            var paragraph = driver.FindElement(By.XPath("html/body/div[2]/div[2]/div[1]/p[1]"));
            Assert.AreEqual(HomeParagraphCol1, paragraph.Text, msgerror(HomeParagraphCol1, paragraph.Text));

            var link = driver.FindElement(By.XPath("html/body/div[2]/div[2]/div[1]/p[2]/a"));
            Assert.AreEqual(HomelinkText, link.Text, msgerror(HomelinkText, link.Text));

            link.Click();
            Assert.AreEqual(HomeSublinkCol1, driver.Url, msgerror(HomeSublinkCol1, driver.Url));
        }

        [Test]
        public void TestCase003_ValidateThirdColumnDownHome()
        {
            var Subtitle = driver.FindElement(By.XPath("html/body/div[2]/div[2]/div[3]/h2"), 30);
            Assert.AreEqual(HomeSubtitleCol3, Subtitle.Text, msgerror(HomeSubtitleCol3, Subtitle.Text));

            var paragraph = driver.FindElement(By.XPath("html/body/div[2]/div[2]/div[3]/p[1]"));
            Assert.AreEqual(HomeParagraphCol3, paragraph.Text, msgerror(HomeParagraphCol3, paragraph.Text));

            var link = driver.FindElement(By.XPath("html/body/div[2]/div[2]/div[3]/p[2]/a"));
            Assert.AreEqual(HomelinkText, link.Text, msgerror(HomelinkText, link.Text));

            link.Click();
            Assert.AreEqual(HomeSublinkCol3, driver.Url, msgerror(HomeSublinkCol3, driver.Url));
        }

    }
}
