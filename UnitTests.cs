using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CodeYou_QA_Final {
    [TestClass]
    public class UnitTests {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private SeleniumHelpers _helper;

        [TestInitialize]
        public void Setup() {
            _driver = new FirefoxDriver();
            _loginPage = new LoginPage(_driver);
        }

        [TestMethod]
        public void SearchAndEditUser() {
            _helper.Login(_loginPage);
        }

        [TestCleanup]
        public void Cleanup() {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
