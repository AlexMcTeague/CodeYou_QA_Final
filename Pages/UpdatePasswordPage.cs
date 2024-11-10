using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CodeYou_QA_Final.Pages {
    internal class UpdatePasswordPage {
        private IWebDriver _driver;

        public UpdatePasswordPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/pim/updatePassword";

        public IWebElement usernameText => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p orangehrm-user-name']"));
    }
}
