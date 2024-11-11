using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYou_QA_Final.Pages {
    internal class MyLeavePage {
        public IWebDriver _driver;

        public MyLeavePage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/leave/viewMyLeaveList";

        public IWebElement myLeaveHeaderButton => _driver.FindElement(By.XPath("//a[@class='oxd-topbar-body-nav-tab-item' and contains(., 'My Leave')]"));
        public IWebElement myLeaveListTitle => _driver.FindElement(By.XPath("//h5[@class='oxd-text oxd-text--h5 oxd-table-filter-title' and contains(., 'My Leave List')]"));

        public IWebElement leaveContainer => _driver.FindElement(By.XPath("//div[@class='oxd-table-body' and @role='rowgroup']"));
        public List<IWebElement> leaveRecords => leaveContainer.FindElements(By.XPath("descendant::div[@role='row']")).ToList();

        public IWebElement cancelLeaveSuccessToast => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--toast-message oxd-toast-content-text' and contains(., 'Successfully Updated')]"));
    }
}
