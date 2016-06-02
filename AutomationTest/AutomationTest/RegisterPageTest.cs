using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTest
{
    [TestFixture]
    public class RegisterPageTest : TestBase
    {

        string TitlePage = "Register - My ASP.NET Application";

        //Block RegisterTextPage
        string emailRequired = "The Email field is required.";
        string passwordRequired = "The Password field is required.";

        string emailNotValid = "The Email field is not a valid e-mail address.";
        string passwordNotMatch = "The password and confirmation password do not match.";

        string passwordNotContainsUpperLetterOrCharacter = "Passwords must have at least one non letter or digit character. Passwords must have at least one uppercase ('A'-'Z').";
        string passwordNotContainsNumbers = "Passwords must have at least one digit ('0'-'9'). Passwords must have at least one uppercase ('A'-'Z').";

        protected override void OnSetUp()
        {
            driver.Navigate().GoToUrl(URLPage);
            var registerLink = driver.FindElement(By.Id("registerLink"));
            registerLink.Click();
            Assert.AreEqual(TitlePage, driver.Title, msgerror(TitlePage, driver.Title));
        }

        [Test]
        public void TestCase001_ValidateRegisterForm()
        {

            ButtonClick();

             var emailErrorField = driver.FindElement(By.XPath("html/body/div[2]/form/div[1]/ul/li[1]"));
            Assert.AreEqual(emailRequired, emailErrorField.Text, msgerror(emailRequired, emailErrorField.Text));

            var passwordErrorField = driver.FindElement(By.XPath("html/body/div[2]/form/div[1]/ul/li[2]"));
            Assert.AreEqual(passwordRequired, passwordErrorField.Text, msgerror(passwordRequired, passwordErrorField.Text));

            SendTextToField("Email", "kevin1");
            SendTextToField("Password", "kevin2");
            SendTextToField("ConfirmPassword", "kevin3");

            ButtonClick();

            var emailErrorField1 = driver.FindElement(By.XPath("html/body/div[2]/form/div[1]/ul/li[1]"));
            Assert.AreEqual(emailNotValid, emailErrorField1.Text, msgerror(emailNotValid, emailErrorField1.Text));

            var passwordErrorField1 = driver.FindElement(By.XPath("html/body/div[2]/form/div[1]/ul/li[2]"));
            Assert.AreEqual(passwordNotMatch, passwordErrorField1.Text, msgerror(passwordNotMatch, passwordErrorField1.Text));

            SendTextToField("Email", "kevin3@test.com");
            SendTextToField("ConfirmPassword", "kevin2");

            ButtonClick();

            var passwordErrorField2 = driver.FindElement(By.XPath("html/body/div[2]/form/div[1]/ul/li"));
            Assert.AreEqual(passwordNotContainsUpperLetterOrCharacter, passwordErrorField2.Text, msgerror(passwordNotContainsUpperLetterOrCharacter, passwordErrorField2.Text));

            SendTextToField("Password", "kevin#");
            SendTextToField("ConfirmPassword", "kevin#");

            ButtonClick();

            var passwordErrorField3 = driver.FindElement(By.XPath("html/body/div[2]/form/div[1]/ul/li"));
            Assert.AreEqual(passwordNotContainsNumbers, passwordErrorField3.Text, msgerror(passwordNotContainsNumbers, passwordErrorField3.Text));

            SendTextToField("Password", "Kevin#2015");
            SendTextToField("ConfirmPassword", "Kevin#2015");

            ButtonClick();

            var UserLoged = driver.FindElement(By.XPath(".//*[@id='logoutForm']/ul/li[1]/a"), 50);
            Assert.AreEqual("Hello kevin3@test.com!", UserLoged.Text, msgerror("Hello kevin3@test.com!", UserLoged.Text));

        }


        public void ButtonClick()
        {
            var ButtonRegister = driver.FindElement(By.CssSelector(".btn.btn-default"));
            ButtonRegister.Click();
        }

        public void SendTextToField(string IdField, string text)
        {
            var EmailField = driver.FindElement(By.Id(IdField));
            EmailField.Clear();
            EmailField.SendKeys(text);
        }



    }
}
