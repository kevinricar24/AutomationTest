using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTest
{
    [TestFixture]
    public class CLogInPageTest : TestBase
    {

        protected override void OnSetUp()
        {
            driver.Navigate().GoToUrl(GlobalsWords.URLPage);
            var registerLink = driver.FindElement(By.Id("loginLink"));
            registerLink.Click();
            Assert.AreEqual(GlobalsWords.TitlePageLogin, driver.Title, msgerror(GlobalsWords.TitlePageLogin, driver.Title));
        }

        [Test]
        public void TestCase001_ValidateLoginForm()
        {
            Elements.ButtonClick(driver);
            var emailErrorField = driver.FindElement(By.XPath(".//*[@id='loginForm']/form/div[1]/div/span/span"));
            Assert.AreEqual(GlobalsWords.emailRequired, emailErrorField.Text, msgerror(GlobalsWords.emailRequired, emailErrorField.Text));
            var passwordErrorField = driver.FindElement(By.XPath(".//*[@id='loginForm']/form/div[2]/div/span/span"));
            Assert.AreEqual(GlobalsWords.passwordRequired, passwordErrorField.Text, msgerror(GlobalsWords.passwordRequired, passwordErrorField.Text));

            Elements.SendTextToField(driver, "Email", GlobalsWords.VarText);
            Elements.SendTextToField(driver, "Password", GlobalsWords.VarText);
            Elements.ButtonClick(driver);
            var emailErrorField1 = driver.FindElement(By.XPath(".//*[@id='loginForm']/form/div[1]/div/span/span"));
            Assert.AreEqual(GlobalsWords.emailNotValid, emailErrorField1.Text, msgerror(GlobalsWords.emailNotValid, emailErrorField1.Text));

            string EmailTest = GlobalsWords.EmailTest;
            Elements.SendTextToField(driver, "Email", EmailTest);
            Elements.SendTextToField(driver, "Password", GlobalsWords.VarText);
            Elements.ButtonClick(driver);
            var InvalidLogin = driver.FindElement(By.XPath(".//*[@id='loginForm']/form/div[1]/ul/li"));
            Assert.AreEqual(GlobalsWords.loginInvalid, InvalidLogin.Text, msgerror(GlobalsWords.loginInvalid, InvalidLogin.Text));

            Elements.SendTextToField(driver, "Email", EmailTest);
            Elements.SendTextToField(driver, "Password", GlobalsWords.PasswordTest);
            Elements.ButtonClick(driver);
            var UserLoged = driver.FindElement(By.XPath(".//*[@id='logoutForm']/ul/li[1]/a"), 50);
            Assert.AreEqual("Hello " + EmailTest + "!", UserLoged.Text, msgerror("Hello " + EmailTest + "!", UserLoged.Text));
        }


    }
}
