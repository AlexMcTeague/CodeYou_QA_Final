using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace CodeYou_QA_Final {
    [TestClass]
    public class UnitTests {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private SeleniumHelpers _helper;


        [TestInitialize]
        public void Setup() {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);
            _helper = new SeleniumHelpers(_driver);
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
