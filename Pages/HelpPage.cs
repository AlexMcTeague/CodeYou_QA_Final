using OpenQA.Selenium;

namespace CodeYou_QA_Final.Pages {
    internal class HelpPage {
        private IWebDriver _driver;

        public HelpPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://starterhelp.orangehrm.com/hc/en-us";

        public IWebElement signInButton => _driver.FindElement(By.XPath("//a[@class='sign-in']"));
        public IWebElement searchBar => _driver.FindElement(By.XPath("//input[@type='search']"));

        public IWebElement adminUserGuideButton => _driver.FindElement(By.XPath("//li[@class='blocks-item' and contains(., 'Admin User Guide')]"));
        public IWebElement employeeUserGuideButton => _driver.FindElement(By.XPath("//li[@class='blocks-item' and contains(., 'Employee User Guide')]"));
        public IWebElement mobileAppButton => _driver.FindElement(By.XPath("//li[@class='blocks-item' and contains(., 'Mobile App')]"));
        public IWebElement AWSGuideButton => _driver.FindElement(By.XPath("//li[@class='blocks-item' and contains(., 'AWS Guide')]"));
        public IWebElement FAQsButton => _driver.FindElement(By.XPath("//li[@class='blocks-item' and contains(., 'FAQs')]"));
    }
}
