using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CodeYou_QA_Final.Pages {
    internal class AdminAddUserPage {
        private IWebDriver _driver;

        public AdminAddUserPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/admin/saveSystemUser";

        public IWebElement userRoleDropdown => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'User Role')]"));
        public IWebElement userRoleDropdownOptionAdmin => userRoleDropdown.FindElement(By.XPath("descendant::span[contains(., 'Admin')]"));
        public IWebElement userRoleDropdownOptionESS => userRoleDropdown.FindElement(By.XPath("descendant::span[contains(., 'ESS')]"));
        public IWebElement statusDropdown => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'Status')]"));
        public IWebElement statusDropdownOptionEnabled => statusDropdown.FindElement(By.XPath("descendant::span[contains(., 'Enabled')]"));
        public IWebElement statusDropdownOptionDisabled => statusDropdown.FindElement(By.XPath("descendant::span[contains(., 'Disabled')]"));

        public IWebElement employeeNameContainer => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'Employee Name')]"));
        public IWebElement employeeNameTextbox => employeeNameContainer.FindElement(By.XPath("descendant::input"));

        public IWebElement usernameContainer => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'Username')]"));
        public IWebElement usernameTextbox => usernameContainer.FindElement(By.XPath("descendant::input"));

        public List<IWebElement> passwordTextboxes => _driver.FindElements(By.XPath("//input[@type='password']")).ToList();
        public IWebElement passwordTextbox => passwordTextboxes[0];
        public IWebElement confirmPasswordTextbox => passwordTextboxes[1];

        public IWebElement saveButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement addUserSuccess => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--toast-message oxd-toast-content-text' and contains(., 'Successfully Saved')]"));

        public void AddNewUser(string employeeName, string username, string password) {
            // Verify we're on the Add User page
            Assert.AreEqual(url, _driver.Url);

            // Filling out the Add User form
            // Expand each dropdown and select an option
            _driver.WaitAndClick(() => userRoleDropdown);
            _driver.WaitAndClick(() => userRoleDropdownOptionAdmin);
            _driver.WaitAndClick(() => statusDropdown);
            _driver.WaitAndClick(() => statusDropdownOptionEnabled);

            // Filling in the Employee Name field
            _driver.WaitUntilDisplayed(() => employeeNameContainer);
            employeeNameTextbox.SendKeys(employeeName);
            Thread.Sleep(3000); // Hardcoded sleep is necessary for employee name list to populate
            employeeNameTextbox.SendKeys(Keys.ArrowDown);
            employeeNameTextbox.SendKeys(Keys.Return);

            // Filling in the Username field
            usernameTextbox.SendKeys(username);

            // Filling in the password and password-confirmation fields
            _driver.WaitUntilDisplayed(() => passwordTextbox);
            _driver.WaitUntilDisplayed(() => confirmPasswordTextbox);
            passwordTextbox.SendKeys(password);
            confirmPasswordTextbox.SendKeys(password);

            // Save the new user entry
            saveButton.Click();
        }
    }
}
