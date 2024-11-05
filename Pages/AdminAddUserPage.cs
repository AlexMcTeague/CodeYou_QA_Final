using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYou_QA_Final.Pages {
    internal class AdminAddUserPage {
        private IWebDriver _driver;

        public AdminAddUserPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/admin/saveSystemUser";
    }
}
