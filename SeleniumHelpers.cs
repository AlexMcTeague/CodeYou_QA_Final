using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace CodeYou_QA_Final {
    internal class SeleniumHelpers {
        public IWebDriver _driver;
        public Actions _actions;

        public SeleniumHelpers(IWebDriver driver) {
            _driver = driver;
            _actions = new Actions(_driver);
        }

        public void Login(LoginPage page) {
            _driver.Navigate().GoToUrl(page.loginPageUrl);
            page.usernameTextbox.SendKeys("Admin");
            page.passwordTextbox.SendKeys("admin123");
            page.loginButton.ScrollAndClick();
        }
    }
}
