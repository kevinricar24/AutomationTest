using System;

namespace AutomationTest
{
    public class GlobalsWords
    {

        public static string URLPage = "http://localhost:51492/";
        public static string EmailTest = string.Empty;
        public static string PasswordTest = "Kevin#" + DateTime.UtcNow.Year.ToString();

        #region HomePage

        public static string TitlePageHome = "Home Page - My ASP.NET Application";

        public static string HomeTitle = "ASP.NET";
        public static string HomeParagraph = "ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.";
        public static string Homelink = "http://www.asp.net/";

        public static string HomeSubtitleCol1 = "Getting started";
        public static string HomeParagraphCol1 = "ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that enables a clean separation of concerns and gives you full control over markup for enjoyable, agile development.";
        public static string HomeSublinkCol1 = "http://www.asp.net/mvc";

        public static string HomeSubtitleCol3 = "Web Hosting";
        public static string HomeParagraphCol3 = "You can easily find a web hosting company that offers the right mix of features and price for your applications.";
        public static string HomeSublinkCol3 = "http://www.asp.net/#migrateidentity";

        public static string HomelinkText = "Learn more »";

        #endregion HomePage

        #region RegisterPage

        public static string TitlePageRegister = "Register - My ASP.NET Application";


        #endregion RegisterPage

        #region LoginPage

        public static string TitlePageLogin = "Log in - My ASP.NET Application";

        #endregion LoginPage

        #region Shared Pages

        public static string VarText = "kevin1";
        public static string VarPassBad = "kevin2";
        public static string VarPassBadFormat = "kevin#";

        public static string emailRequired = "The Email field is required.";
        public static string passwordRequired = "The Password field is required.";

        public static string emailNotValid = "The Email field is not a valid e-mail address.";
        public static string passwordNotMatch = "The password and confirmation password do not match.";

        public static string passwordNotContainsUpperLetterOrCharacter = "Passwords must have at least one non letter or digit character. Passwords must have at least one uppercase ('A'-'Z').";
        public static string passwordNotContainsNumbers = "Passwords must have at least one digit ('0'-'9'). Passwords must have at least one uppercase ('A'-'Z').";

        public static string loginInvalid = "Invalid login attempt.";

        #endregion Shared Pages

    }
}
