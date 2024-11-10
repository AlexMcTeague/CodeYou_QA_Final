using OpenQA.Selenium;

namespace CodeYou_QA_Final {
    internal class PageHeader {
        private IWebDriver _driver;

        public PageHeader(IWebDriver d) {
            _driver = d;
        }

        public IWebElement userDropdown => _driver.FindElement(By.XPath("//span[@class='oxd-userdropdown-tab']"));
        public IWebElement changePasswordButton => _driver.FindElement(By.XPath("//a[@role='menuitem' and contains(text(), 'Change Password')]"));
        public IWebElement logoutButton => _driver.FindElement(By.XPath("//a[@role='menuitem' and text()='Logout']"));
        public IWebElement helpButton => _driver.FindElement(By.XPath("//button[@class='oxd-icon-button' and @title='Help']"));


        public void Logout() {
            _driver.WaitAndClick(() => userDropdown);
            _driver.WaitAndClick(() => logoutButton);
        }
    }
}
