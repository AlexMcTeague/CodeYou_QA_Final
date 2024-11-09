using CodeYou_QA_Final.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V127.Autofill;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CodeYou_QA_Final {
    [TestClass]
    public class UnitTests {
        private IWebDriver _driver;
        private SeleniumHelpers _helper;

        private LoginPage _loginPage;
        private DashboardPage _dashboardPage;
        private DirectoryPage _directoryPage;
        private AdminViewUsersPage _adminPage;
        private AdminAddUserPage _addUserPage;
        private AdminEditUserPage _editUserPage;
        private HelpPage _helpPage;

        private SidebarMenu _sidebar;
        private PageHeader _header;


        [TestInitialize]
        public void Setup() {
            _driver = new ChromeDriver();
            _helper = new SeleniumHelpers(_driver);

            _loginPage = new LoginPage(_driver);
            _dashboardPage = new DashboardPage(_driver);
            _directoryPage = new DirectoryPage(_driver);
            _adminPage = new AdminViewUsersPage(_driver);
            _addUserPage = new AdminAddUserPage(_driver);
            _editUserPage = new AdminEditUserPage(_driver);
            _helpPage = new HelpPage(_driver);

            _sidebar = new SidebarMenu(_driver);
            _header = new PageHeader(_driver);
        }

        [TestMethod]
        public void SearchAndEditUser() {
            // Log In
            _loginPage.Login();

            // Click the Admin button on the sidebar menu
            _sidebar.Expand();
            _driver.WaitAndClick(() => _sidebar.adminButton);

            // Verify we're now on the Admin page
            Assert.AreEqual(_adminPage.url, _driver.Url);

            // Find a random record
            IWebElement userElement = _adminPage.GetRandomUser();
            
            // Open the edit menu for that user
            _adminPage.editUser(userElement);
        }

        [TestMethod]
        public void AddNewUser() {
            // Log In
            _loginPage.Login();

            // Click the Directory button on the sidebar menu
            _sidebar.Expand();
            _driver.WaitAndClick(() => _sidebar.directoryButton);

            // Find a random employee name
            string employeeName = _directoryPage.GetRandomEmployeeName();

            // Click the Admin button on the sidebar menu
            _sidebar.Expand();
            _driver.WaitAndClick(() => _sidebar.adminButton);

            // On the View Users page, click the Add button
            _driver.WaitAndClick(() => _adminPage.addUserButton);

            // Verify we're now on the Add User page
            Assert.AreEqual(_addUserPage.url, _driver.Url);

            // Filling out the Add User form
            // Expand each dropdown and select an option
            _driver.WaitAndClick(() => _addUserPage.userRoleDropdown);
            _driver.WaitAndClick(() => _addUserPage.userRoleDropdownOptionAdmin);
            _driver.WaitAndClick(() => _addUserPage.statusDropdown);
            _driver.WaitAndClick(() => _addUserPage.statusDropdownOptionEnabled);

            // Filling in the Employee Name field
            _driver.WaitUntilDisplayed(() => _addUserPage.employeeNameContainer);
            _addUserPage.employeeNameTextbox.SendKeys(employeeName);
            Thread.Sleep(3000); // Hardcoded sleep is necessary for username list to populate
            _editUserPage.employeeNameTextbox.SendKeys(Keys.ArrowDown);
            _editUserPage.employeeNameTextbox.SendKeys(Keys.Return);

            // Filling in the Username field
            string username = "Youzer " + _helper.GenerateRandomPassword(5);
            _addUserPage.usernameTextbox.SendKeys(username);

            // Filling in the password and password-confirmation fields
            string password = _helper.GenerateRandomPassword(12);
            _driver.WaitUntilDisplayed(() => _addUserPage.passwordTextbox);
            _driver.WaitUntilDisplayed(() => _addUserPage.confirmPasswordTextbox);
            _addUserPage.passwordTextbox.SendKeys(password);
            _addUserPage.confirmPasswordTextbox.SendKeys(password);

            // Save the new user entry
            _addUserPage.saveButton.Click();

            // Check to make sure the user was successfully added
            _driver.WaitUntilDisplayed(() => _addUserPage.addUserSuccess);
            _driver.WaitUntilDisplayed(() => _adminPage.addUserButton);
            Assert.AreEqual(_adminPage.url, _driver.Url);
        }

        [TestCleanup]
        public void Cleanup() {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
