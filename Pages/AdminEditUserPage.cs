﻿using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace CodeYou_QA_Final.Pages {
    internal class AdminEditUserPage {
        private IWebDriver _driver;

        public AdminEditUserPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/admin/saveSystemUser/";

        public IWebElement userRoleDropdown => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'User Role')]"));
        public string userRoleDropdownCurrentValue => userRoleDropdown.FindElement(By.XPath("descendant::div[@class='oxd-select-text-input']")).Text;
        public IWebElement userRoleDropdownOptionAdmin => userRoleDropdown.FindElement(By.XPath("descendant::span[contains(., 'Admin')]"));
        public IWebElement userRoleDropdownOptionESS => userRoleDropdown.FindElement(By.XPath("descendant::span[contains(., 'ESS')]"));

        public IWebElement statusDropdown => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'Status')]"));
        public string statusDropdownCurrentValue => statusDropdown.FindElement(By.XPath("descendant::div[@class='oxd-select-text-input']")).Text;
        public IWebElement statusDropdownOptionEnabled => statusDropdown.FindElement(By.XPath("descendant::span[contains(., 'Enabled')]"));
        public IWebElement statusDropdownOptionDisabled => statusDropdown.FindElement(By.XPath("descendant::span[contains(., 'Disabled')]"));

        public IWebElement employeeNameContainer => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'Employee Name')]"));
        public IWebElement employeeNameTextbox => employeeNameContainer.FindElement(By.XPath("descendant::input"));
        public string employeeNameCurrentValue => employeeNameTextbox.GetAttribute("value");

        public IWebElement usernameContainer => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'Username')]"));
        public IWebElement usernameTextbox => usernameContainer.FindElement(By.XPath("descendant::input"));
        public string usernameCurrentValue => usernameTextbox.GetAttribute("value");

        public IWebElement passwordCheckbox => _driver.FindElement(By.XPath("//i[@class='oxd-icon bi-check oxd-checkbox-input-icon']"));
        public string passwordXPath = "//input[@type='password']";
        public List<IWebElement> passwordTextboxes => _driver.FindElements(By.XPath(passwordXPath)).ToList();
        public IWebElement passwordTextbox => passwordTextboxes[0];
        public IWebElement confirmPasswordTextbox => passwordTextboxes[1];

        public IWebElement cancelButton => _driver.FindElement(By.XPath("//button[@type='button' and contains(., 'Cancel')]"));
        public IWebElement saveButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement editUserSuccessToast => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--toast-message oxd-toast-content-text' and contains(., 'Successfully Updated')]"));
        public IWebElement recordNotFoundErrorToast => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--toast-message oxd-toast-content-text' and contains(., 'Record Not Found')]"));
    }
}
