using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;

namespace CodeYou_QA_Final.Pages {
    internal class AddLeaveEntitlementsPage {
        private IWebDriver _driver;

        public AddLeaveEntitlementsPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/leave/addLeaveEntitlement";

        public IWebElement leaveEntitlementsHeaderDropdown => _driver.FindElement(By.XPath("//span[@class='oxd-topbar-body-nav-tab-item' and contains(., 'Entitlements')]"));
        public IWebElement leaveEntitlementsHeaderDropdownAdd => _driver.FindElement(By.XPath("//a[@role='menuitem' and contains(., 'Add Entitlements')]"));

        public IWebElement addToOptionIndividual => _driver.FindElement(By.XPath("//label[@class='' and contains(., 'Individual Employee')]"));

        public IWebElement employeeNameContainer => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'Employee Name')]"));
        public IWebElement employeeNameTextbox => employeeNameContainer.FindElement(By.XPath("descendant::input"));

        public IWebElement leaveTypeDropdown => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'Leave Type')]"));
        public IWebElement leaveTypeOptionUSVacation => leaveTypeDropdown.FindElement(By.XPath("descendant::span[contains(., 'US - Vacation')]"));

        public IWebElement entitlementContainer => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'Entitlement')]"));
        public IWebElement entitlementTextbox => entitlementContainer.FindElement(By.XPath("descendant::input"));

        public IWebElement saveButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement confirmSaveButton => _driver.FindElement(By.XPath("//button[@type='button' and contains(., 'Confirm')]"));
        public IWebElement addEntitlementSuccessToast => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--toast-message oxd-toast-content-text' and contains(., 'Successfully Saved')]"));


        public void AddLeaveEntitlement() {
            // Go to the Add Entitlements menu
            _driver.WaitAndClick(() => leaveEntitlementsHeaderDropdown);
            _driver.WaitAndClick(() => leaveEntitlementsHeaderDropdownAdd);
            Assert.AreEqual(url, _driver.Url);

            // Select the "Individual Employee" option
            _driver.WaitAndClick(() => addToOptionIndividual);

            // Input the current user's name into the Employee Name textbox (Admin user is seemingly the only one with the ability to add leave)
            string employeeName = _driver.FindElement(By.XPath("//p[@class='oxd-userdropdown-name']")).Text;
            employeeNameTextbox.SendKeys(employeeName);
            Thread.Sleep(3000); // Hardcoded sleep is necessary for employee name list to populate
            employeeNameTextbox.SendKeys(Keys.ArrowDown);
            employeeNameTextbox.SendKeys(Keys.Return);

            // Select 8 hours of US - Vacation time
            leaveTypeDropdown.Click();
            _driver.WaitAndClick(() => leaveTypeOptionUSVacation);
            entitlementTextbox.SendKeys("8.00");

            // Save the leave
            saveButton.Click();
            _driver.WaitAndClick(() => confirmSaveButton);
            _driver.WaitUntilDisplayed(() => addEntitlementSuccessToast);
        }
    }
}
