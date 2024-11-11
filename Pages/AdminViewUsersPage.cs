using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeYou_QA_Final.Pages {
    internal class AdminViewUsersPage {
        private IWebDriver _driver;

        public AdminViewUsersPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/admin/viewSystemUsers";

        public IWebElement usernameTextboxContainer => _driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and contains(., 'Username')]"));
        public IWebElement usernameTextbox => usernameTextboxContainer.FindElement(By.XPath("descendant::input"));

        public IWebElement addUserButton => _driver.FindElement(By.XPath("//button[contains(., 'Add')]"));

        public List<IWebElement> userElements => _driver.FindElements(By.XPath("//div[@class='oxd-table-card']")).ToList();

        public IWebElement firstUserElementEditIcon => _driver.FindElement(By.XPath("//i[@class='oxd-icon bi-pencil-fill']"));

        public IWebElement firstUserElementDeleteIcon => _driver.FindElement(By.XPath("//i[@class='oxd-icon bi-trash']"));
        public IWebElement confirmDeleteButton => _driver.FindElement(By.XPath("//i[@class='oxd-icon bi-trash oxd-button-icon']"));
        public IWebElement deleteUserSuccessToast => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--toast-message oxd-toast-content-text' and contains(., 'Successfully Deleted')]"));
        public IWebElement deleteUserFailureToast => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--toast-message oxd-toast-content-text' and contains(., 'Cannot be deleted')]"));


        public IWebElement GetRandomUser() {
            _driver.WaitUntilDisplayed(() => firstUserElementEditIcon);

            Random rnd = new Random();
            _driver.ScrollToBottom();
            int r = rnd.Next(userElements.Count);
            return userElements[r];
        }

        public void editUser(IWebElement userElement) {
            Actions actions = new Actions(_driver);
            actions.ScrollToElement(userElement).Perform();
            _driver.WaitAndClick(() => userElement.FindElement(By.XPath("descendant::i[@class='oxd-icon bi-pencil-fill']")));
        }
    }
}
