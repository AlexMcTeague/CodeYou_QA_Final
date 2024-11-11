using OpenQA.Selenium;

namespace CodeYou_QA_Final.Pages {
    internal class LeaveListPage {
        private IWebDriver _driver;

        public LeaveListPage(IWebDriver d) {
            _driver = d;
        }
        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/leave/viewLeaveList";

        public IWebElement employeeNameContainer => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'Employee Name')]"));
        public IWebElement employeeNameTextbox => employeeNameContainer.FindElement(By.XPath("descendant::input"));

        public IWebElement myRequestedLeaveComment => _driver.FindElement(By.XPath("//div[@class='oxd-table-cell oxd-padding-cell' and contains(./*, 'Workin' hard, or hardly workin'? Ekekekekek')]"));
        public IWebElement noRecordsFoundToast => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--toast-message oxd-toast-content-text' and contains(., 'No Records Found')]"));
    }
}