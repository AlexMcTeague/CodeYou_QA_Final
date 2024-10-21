using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CodeYou_QA_Final {
    [TestClass]
    public class UnitTests {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [TestInitialize]
        public void Setup() {
            _driver = new FirefoxDriver();
            _loginPage = new LoginPage(_driver);
        }

        [TestMethod]
        public void TestMethod1() {
            _driver.Navigate().GoToUrl(_loginPage.loginPageUrl);
        }

        [TestCleanup]
        public void Cleanup() {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
