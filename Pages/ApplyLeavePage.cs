using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Threading;
using System.Linq;

namespace CodeYou_QA_Final.Pages {
    internal class ApplyLeavePage {
        public IWebDriver _driver;

        public ApplyLeavePage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/leave/applyLeave";

        public IWebElement applyForLeaveHeaderButton => _driver.FindElement(By.XPath("//a[@class='oxd-topbar-body-nav-tab-item' and contains(., 'Apply')]"));

        public IWebElement leaveTypeDropdown => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'Leave Type')]"));
        public IWebElement leaveTypeOptionUSVacation => leaveTypeDropdown.FindElement(By.XPath("descendant::span[contains(., 'US - Vacation')]"));

        public IWebElement leaveBalanceTextDisplay => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p orangehrm-leave-balance-text']"));
        public decimal leaveBalance => decimal.Parse(leaveBalanceTextDisplay.Text.Split(' ').First());
       
        public IWebElement fromDateContainer => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'From Date')]"));
        public IWebElement fromDateCalendarButton => fromDateContainer.FindElement(By.XPath("descendant::i"));
        public IWebElement toDateContainer => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'To Date')]"));
        public IWebElement toDateCalendarButton => toDateContainer.FindElement(By.XPath("descendant::i"));

        public IWebElement nextMonthCalendarButton => _driver.FindElement(By.XPath("//i[@class='oxd-icon bi-chevron-right']"));
        public IWebElement todaysDateCalendar => _driver.FindElement(By.XPath("//div[@class='oxd-date-input-link --today']"));
        public IWebElement todaysDateCalendarSelected => _driver.FindElement(By.XPath("//div[contains(@class, '--selected --today')]"));

        public IWebElement nextAvailableCalendarDate => todaysDateCalendarSelected.FindElement(By.XPath("../following-sibling::div[@class='oxd-calendar-date-wrapper']//child::div[@class='oxd-calendar-date']"));
        public IWebElement commentsTextArea => _driver.FindElement(By.XPath("//textarea[@class='oxd-textarea oxd-textarea--active oxd-textarea--resize-vertical']"));
        public IWebElement applyButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement applyLeaveSuccessToast => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--toast-message oxd-toast-content-text' and contains(., 'Successfully Saved')]"));


        public string ApplyLeaveOnNextAvailableDay(string leaveComments) {
            // TODO: account for existing leave when applying for new leave

            // Navigate to the Apply Leave page
            applyForLeaveHeaderButton.Click();
            _driver.WaitUntilDisplayed(() => leaveBalanceTextDisplay);

            // Select the leave type from the dropdown
            Thread.Sleep(1000); // Hardcoded sleep is necessary for spinner to disappear
            _driver.WaitAndClick(() => leaveTypeDropdown);
            _driver.WaitAndClick(() => leaveTypeOptionUSVacation);

            // Open the calendar
            Thread.Sleep(500); // Hardcoded sleep is necessary for leave balance to update
            fromDateCalendarButton.Click();
            _driver.WaitUntilDisplayed(() => todaysDateCalendar);

            // Select the next available leave date. The "To" date is auto-filled as the same day
            string day = nextAvailableCalendarDate.Text;
            nextAvailableCalendarDate.Click();

            // Save the leave
            commentsTextArea.SendKeys(leaveComments);
            applyButton.Click();
            _driver.WaitUntilDisplayed(() => applyLeaveSuccessToast);

            return day;
        }
    }
}
