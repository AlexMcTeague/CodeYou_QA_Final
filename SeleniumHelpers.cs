using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CodeYou_QA_Final {
    internal class SeleniumHelpers {
        public IWebDriver _driver;
        private WebDriverWait _driverWait;
        public Actions _actions;

        public SeleniumHelpers(IWebDriver driver) {
            _driver = driver;
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            _actions = new Actions(_driver);
        }

        public void Login(LoginPage page) {
            _driver.Navigate().GoToUrl(page.loginPageUrl);
            // For some reason this method fails unless it's run in break mode. Maybe there needs to be a second general wait before this specific one?
            WaitForElement(page.loginButton);
            page.usernameTextbox.SendKeys("Admin");
            page.passwordTextbox.SendKeys("admin123");
            page.loginButton.ScrollAndClick(_driver, _actions);
        }
        
        public void WaitForElement(IWebElement element) {
            _driverWait.Until(d => element.Displayed);
        }
    }
}
