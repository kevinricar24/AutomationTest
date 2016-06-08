using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace AutomationTest
{
    [TestFixture]
    public class BRegisterPageTest : TestBase
    {

        protected override void OnSetUp()
        {
            driver.Navigate().GoToUrl(GlobalsWords.URLPage);
            var registerLink = driver.FindElement(By.Id("registerLink"));
            registerLink.Click();
            Assert.AreEqual(GlobalsWords.TitlePageRegister, driver.Title, msgerror(GlobalsWords.TitlePageRegister, driver.Title));
        }

        public string GenerateUniqueEmail()
        {
            return GlobalsWords.VarText + Guid.NewGuid().ToString().Remove(6) + "@test.com";
        }

        [Test]
        public void TestCase001_ValidateRegisterForm()
        {
            Elements.ButtonClick(driver);
            var emailErrorField = driver.FindElement(By.XPath("html/body/div[2]/form/div[1]/ul/li[1]"));
            Assert.AreEqual(GlobalsWords.emailRequired, emailErrorField.Text, msgerror(GlobalsWords.emailRequired, emailErrorField.Text));
            var passwordErrorField = driver.FindElement(By.XPath("html/body/div[2]/form/div[1]/ul/li[2]"));
            Assert.AreEqual(GlobalsWords.passwordRequired, passwordErrorField.Text, msgerror(GlobalsWords.passwordRequired, passwordErrorField.Text));

            Elements.SendTextToField(driver, "Email", GlobalsWords.VarText);
            Elements.SendTextToField(driver, "Password", GlobalsWords.VarText);
            Elements.SendTextToField(driver, "ConfirmPassword", GlobalsWords.VarPassBad);
            Elements.ButtonClick(driver);
            var emailErrorField1 = driver.FindElement(By.XPath("html/body/div[2]/form/div[1]/ul/li[1]"));
            Assert.AreEqual(GlobalsWords.emailNotValid, emailErrorField1.Text, msgerror(GlobalsWords.emailNotValid, emailErrorField1.Text));
            var passwordErrorField1 = driver.FindElement(By.XPath("html/body/div[2]/form/div[1]/ul/li[2]"));
            Assert.AreEqual(GlobalsWords.passwordNotMatch, passwordErrorField1.Text, msgerror(GlobalsWords.passwordNotMatch, passwordErrorField1.Text));

            GlobalsWords.EmailTest = GenerateUniqueEmail();
            Elements.SendTextToField(driver, "Email", GlobalsWords.EmailTest);
            Elements.SendTextToField(driver, "ConfirmPassword", GlobalsWords.VarText);
            Elements.ButtonClick(driver);
            var passwordErrorField2 = driver.FindElement(By.XPath("html/body/div[2]/form/div[1]/ul/li"));
            Assert.AreEqual(GlobalsWords.passwordNotContainsUpperLetterOrCharacter, passwordErrorField2.Text, msgerror(GlobalsWords.passwordNotContainsUpperLetterOrCharacter, passwordErrorField2.Text));

            Elements.SendTextToField(driver, "Password", GlobalsWords.VarPassBadFormat);
            Elements.SendTextToField(driver, "ConfirmPassword", GlobalsWords.VarPassBadFormat);
            Elements.ButtonClick(driver);
            var passwordErrorField3 = driver.FindElement(By.XPath("html/body/div[2]/form/div[1]/ul/li"));
            Assert.AreEqual(GlobalsWords.passwordNotContainsNumbers, passwordErrorField3.Text, msgerror(GlobalsWords.passwordNotContainsNumbers, passwordErrorField3.Text));

            Elements.SendTextToField(driver, "Password", GlobalsWords.PasswordTest);
            Elements.SendTextToField(driver, "ConfirmPassword", GlobalsWords.PasswordTest);
            Elements.ButtonClick(driver);
            var UserLoged = driver.FindElement(By.XPath(".//*[@id='logoutForm']/ul/li[1]/a"), 50);
            Assert.AreEqual("Hello " + GlobalsWords.EmailTest + "!", UserLoged.Text, msgerror("Hello " + GlobalsWords.EmailTest + "!", UserLoged.Text));
        }
    }
}
