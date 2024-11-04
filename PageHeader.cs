using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYou_QA_Final {
    internal class PageHeader {
        private IWebDriver _driver;

        public PageHeader(IWebDriver d) {
            _driver = d;
        }

        public IWebElement helpButton => _driver.FindElement(By.XPath("//button[@class='oxd-icon-button' and @title='Help']"));
    }
}
