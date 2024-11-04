using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CodeYou_QA_Final {
    internal class SeleniumHelpers {
        public IWebDriver _driver;

        public SeleniumHelpers(IWebDriver driver) {
            _driver = driver;
        }
    }
}
