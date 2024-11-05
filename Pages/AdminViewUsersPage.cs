using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYou_QA_Final.Pages {
    internal class AdminViewUsersPage {
        private IWebDriver _driver;

        public AdminViewUsersPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/admin/viewSystemUsers";
        public IWebElement addUserButton => _driver.FindElement(By.XPath("//button[contains(., 'Add')]"));
    }
}
