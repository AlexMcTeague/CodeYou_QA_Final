using CodeYou_QA_Final.Pages;
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
        private SeleniumHelpers _helper;

        private LoginPage _loginPage;
        private DashboardPage _dashboardPage;
        private AdminPage _adminPage;
        private HelpPage _helpPage;

        private SidebarMenu _sidebar;
        private PageHeader _header;


        [TestInitialize]
        public void Setup() {
            _driver = new ChromeDriver();
            _helper = new SeleniumHelpers(_driver);

            _loginPage = new LoginPage(_driver);
            _dashboardPage = new DashboardPage(_driver);
            _adminPage = new AdminPage(_driver);
            _helpPage = new HelpPage(_driver);

            _sidebar = new SidebarMenu(_driver);
            _header = new PageHeader(_driver);
        }

        [TestMethod]
        public void SearchAndEditUser() {
            _loginPage.Login();
            _sidebar.Expand();
            _sidebar.adminButton.Click();
        }

        [TestCleanup]
        public void Cleanup() {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
