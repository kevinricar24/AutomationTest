using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTest
{
    [TestFixture]
    public class AHomePageTest : TestBase
    {

        protected override void OnSetUp()
        {
            driver.Navigate().GoToUrl(GlobalsWords.URLPage);
            Assert.AreEqual(GlobalsWords.TitlePageHome, driver.Title, msgerror(GlobalsWords.TitlePageHome, driver.Title));
        }

        [Test]
        public void TestCase001_ValidateSectionUpHome()
        {
            var Title = driver.FindElement(By.ClassName("jumbotron")).FindElement(By.TagName("h1"));
            Assert.AreEqual(GlobalsWords.HomeTitle, Title.Text, msgerror(GlobalsWords.HomeTitle, Title.Text));

            var paragraph = driver.FindElement(By.ClassName("lead"));
            Assert.AreEqual(GlobalsWords.HomeParagraph, paragraph.Text, msgerror(GlobalsWords.HomeParagraph, paragraph.Text));

            var link = driver.FindElement(By.CssSelector(".btn.btn-primary.btn-lg"));
            Assert.AreEqual(GlobalsWords.HomelinkText, link.Text, msgerror(GlobalsWords.HomelinkText, link.Text));

            link.Click();
            Assert.AreEqual(GlobalsWords.Homelink, driver.Url, msgerror(GlobalsWords.Homelink, driver.Url));
        }

        public void ValidationColumnsGroup(string xpathSubtitle, string TextExpectedSubtitle,
                                          string xpathParagraph, string TextExpectedParagraph,
                                          string xpathLink, string TextExpectedLink,
                                          string TextHomeSublinkCol)
        {
            var Subtitle = driver.FindElement(By.XPath(xpathSubtitle), 30);
            Assert.AreEqual(TextExpectedSubtitle, Subtitle.Text, msgerror(TextExpectedSubtitle, Subtitle.Text));

            var Paragraph = driver.FindElement(By.XPath(xpathParagraph));
            Assert.AreEqual(TextExpectedParagraph, Paragraph.Text, msgerror(TextExpectedParagraph, Paragraph.Text));

            var Link = driver.FindElement(By.XPath(xpathLink));
            Assert.AreEqual(TextExpectedLink, Link.Text, msgerror(TextExpectedLink, Link.Text));

            Link.Click();
            Assert.AreEqual(TextHomeSublinkCol, driver.Url, msgerror(TextHomeSublinkCol, driver.Url));
        }

        [Test]
        public void TestCase002_ValidateFirstColumnDownHome()
        {
            string xpathSubtitle = "html/body/div[2]/div[2]/div[1]/h2";
            string xpathParagraph = "html/body/div[2]/div[2]/div[1]/p[1]";
            string xpathLink = "html/body/div[2]/div[2]/div[1]/p[2]/a";
            ValidationColumnsGroup(xpathSubtitle, GlobalsWords.HomeSubtitleCol1, xpathParagraph, GlobalsWords.HomeParagraphCol1,
                            xpathLink, GlobalsWords.HomelinkText, GlobalsWords.HomeSublinkCol1);
        }

        [Test]
        public void TestCase003_ValidateThirdColumnDownHome()
        {
            string xpathSubtitle = "html/body/div[2]/div[2]/div[3]/h2";
            string xpathParagraph = "html/body/div[2]/div[2]/div[3]/p[1]";
            string xpathLink = "html/body/div[2]/div[2]/div[3]/p[2]/a";
            ValidationColumnsGroup(xpathSubtitle, GlobalsWords.HomeSubtitleCol3, xpathParagraph, GlobalsWords.HomeParagraphCol3,
                            xpathLink, GlobalsWords.HomelinkText, GlobalsWords.HomeSublinkCol3);
        }

    }
}
