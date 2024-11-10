using OpenQA.Selenium;

namespace CodeYou_QA_Final {
    internal class LoginPage {
        private IWebDriver _driver;

        public LoginPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        public string adminUsername = "Admin"; // Storing the credentials this way IS very secure, thanks for asking
        public string adminPassword = "admin123";

        public IWebElement usernameTextbox => _driver.FindElement(By.Name("username"));
        public IWebElement passwordTextbox => _driver.FindElement(By.Name("password"));
        public IWebElement loginButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

        public void LoginAsAdmin() {
            Login(adminUsername, adminPassword);
        }
        public void Login(string username, string password) {
            _driver.Navigate().GoToUrl(url);
            _driver.WaitUntilDisplayed(() => loginButton);
            usernameTextbox.SendKeys(username);
            passwordTextbox.SendKeys(password);
            loginButton.ScrollAndClick(_driver);
            _driver.Manage().Window.Maximize();
        }
    }
}
