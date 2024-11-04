using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CodeYou_QA_Final {
    internal class SeleniumHelpers {
        public IWebDriver _driver;
        private WebDriverWait _driverWait;

        public SeleniumHelpers(IWebDriver driver) {
            _driver = driver;
            _driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        }

        public void Login(LoginPage page) {
            _driver.Navigate().GoToUrl(page.loginPageUrl);
            WaitForElement(page.loginButton);
            page.usernameTextbox.SendKeys("Admin");
            page.passwordTextbox.SendKeys("admin123");
            page.loginButton.ScrollAndClick(_driver);
        }
        
        public void WaitForElement(IWebElement element) {
            _driverWait.Until(d => element.Displayed);
        }
    }
}
