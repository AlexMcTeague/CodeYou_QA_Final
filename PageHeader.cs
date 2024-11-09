using OpenQA.Selenium;

namespace CodeYou_QA_Final {
    internal class PageHeader {
        private IWebDriver _driver;

        public PageHeader(IWebDriver d) {
            _driver = d;
        }

        public IWebElement helpButton => _driver.FindElement(By.XPath("//button[@class='oxd-icon-button' and @title='Help']"));
    }
}
