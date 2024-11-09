using CodeYou_QA_Final.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

            // Try again (up to 10 times) if we picked the Admin user which can't be edited
            _driver.WaitUntilDisplayed(() => _editUserPage.usernameTextbox);
            string prevUsername = _editUserPage.usernameTextbox.GetAttribute("value");
            int i = 0;
            while (prevUsername == "Admin" && i < 10) {
                _sidebar.Expand();
                _driver.WaitAndClick(() => _sidebar.adminButton);
                userElement = _adminPage.GetRandomUser();
                _adminPage.editUser(userElement);
                _driver.WaitUntilDisplayed(() => _editUserPage.usernameTextbox);
                prevUsername = _editUserPage.usernameTextbox.GetAttribute("value");
            }
            Assert.IsTrue(i < 10); // If we somehow picked the Admin user 10 times in a row, that's probably bad

            // Swap the User Role dropdown value
            _driver.WaitAndClick(() => _editUserPage.userRoleDropdown);
            string newUserRoleValue = "";
            if (_editUserPage.userRoleDropdownCurrentValue == "Admin") {
                newUserRoleValue = "ESS";
                _editUserPage.userRoleDropdownOptionESS.Click();
            } else if (_editUserPage.userRoleDropdownCurrentValue == "ESS") {
                newUserRoleValue = "Admin";
                _editUserPage.userRoleDropdownOptionAdmin.Click();
            }

            // Swap the Status dropdown value
            _driver.WaitAndClick(() => _editUserPage.statusDropdown);
            string newStatusValue = "";
            if (_editUserPage.userRoleDropdownCurrentValue == "Enabled") {
                newStatusValue = "Disabled";
                _editUserPage.userRoleDropdownOptionESS.Click();
            } else if (_editUserPage.userRoleDropdownCurrentValue == "Disabled") {
                newStatusValue = "Enabled";
                _editUserPage.userRoleDropdownOptionAdmin.Click();
            }

            // Change the employee name to a new randomly selected one
            string newEmployeeName = _directoryPage.GetRandomEmployeeNameViaNewTab();
            _editUserPage.employeeNameTextbox.SendKeys(Keys.Control + "A");
            _editUserPage.employeeNameTextbox.SendKeys(Keys.Delete);
            _editUserPage.employeeNameTextbox.SendKeys(newEmployeeName);
            Thread.Sleep(3000); // Hardcoded sleep is necessary for username list to populate
            _editUserPage.employeeNameTextbox.SendKeys(Keys.ArrowDown);
            _editUserPage.employeeNameTextbox.SendKeys(Keys.Return);

            // Change the username by using a super-secret cypher
            string newUsername = _helper.ToPigLatin(prevUsername);
            _editUserPage.usernameTextbox.SendKeys(Keys.Control + "A");
            _editUserPage.usernameTextbox.SendKeys(Keys.Delete);
            _editUserPage.usernameTextbox.SendKeys(newUsername);

            // Change the password to a new randomly generated one
            _editUserPage.passwordCheckbox.Click(); // Chrome won't allow clicking this element, it thinks the div parent is obscuring it
            string newPassword = _helper.GenerateRandomPassword(12);
            _driver.WaitForElementsByXPath(_editUserPage.passwordXPath);
            _editUserPage.passwordTextbox.SendKeys(newPassword);
            _editUserPage.confirmPasswordTextbox.SendKeys(newPassword);

            // Save the changes
            _editUserPage.saveButton.Click();

            // Check to make sure the user was successfully added
            _driver.WaitUntilDisplayed(() => _editUserPage.editUserSuccess);
            _driver.WaitUntilDisplayed(() => _adminPage.addUserButton);
            Assert.AreEqual(_adminPage.url, _driver.Url);
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
