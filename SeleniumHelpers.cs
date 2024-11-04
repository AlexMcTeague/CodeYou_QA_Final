using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CodeYou_QA_Final {
    internal class SeleniumHelpers {
        public IWebDriver _driver;

        public SeleniumHelpers(IWebDriver driver) {
            _driver = driver;
        }

        public void Login(LoginPage page) {
            _driver.Navigate().GoToUrl(page.loginPageUrl);
            page.loginButton.WaitUntilDisplayed(_driver);
            page.usernameTextbox.SendKeys("Admin");
            page.passwordTextbox.SendKeys("admin123");
            page.loginButton.ScrollAndClick(_driver);
        }
    }
}
