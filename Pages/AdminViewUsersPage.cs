using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace CodeYou_QA_Final.Pages {
    internal class AdminViewUsersPage {
        private IWebDriver _driver;

        public AdminViewUsersPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/admin/viewSystemUsers";
        public IWebElement addUserButton => _driver.FindElement(By.XPath("//button[contains(., 'Add')]"));
        public IWebElement firstUserElementEditIcon => _driver.FindElement(By.XPath("//i[@class='oxd-icon bi-pencil-fill']"));
        public List<IWebElement> userElements => _driver.FindElements(By.XPath("//div[@role='row']")).ToList();

        public IWebElement GetRandomUser() {
            _driver.WaitUntilDisplayed(() => firstUserElementEditIcon);

            Random rnd = new Random();
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
