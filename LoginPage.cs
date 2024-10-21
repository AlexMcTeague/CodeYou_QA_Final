using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CodeYou_QA_Final {
    internal class LoginPage {
        private IWebDriver _driver;

        public LoginPage(IWebDriver d) {
            _driver = d;
        }

        public string loginPageUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
    }
}
