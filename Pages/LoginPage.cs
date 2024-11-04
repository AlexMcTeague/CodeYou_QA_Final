using OpenQA.Selenium;

namespace CodeYou_QA_Final {
    internal class LoginPage {
        private IWebDriver _driver;

        public LoginPage(IWebDriver d) {
            _driver = d;
        }

        public string loginPageUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        public IWebElement usernameTextbox => _driver.FindElement(By.Name("username"));
        public IWebElement passwordTextbox => _driver.FindElement(By.Name("password"));
        public IWebElement loginButton => _driver.FindElement(By.XPath("//button[@type='submit']"));
    }
}
