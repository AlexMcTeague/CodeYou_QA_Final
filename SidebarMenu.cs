using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYou_QA_Final {
    internal class SidebarMenu {
        private IWebDriver _driver;

        public SidebarMenu(IWebDriver d) {
            _driver = d;
        }

        public IWebElement toggleButton => _driver.FindElement(By.XPath("//button[@class='oxd-icon-button oxd-main-menu-button']"));
        public IWebElement adminButton => _driver.FindElement(By.XPath("//span[@class='oxd-text oxd-text--span oxd-main-menu-item--name' and text()='Admin'"));
        public IWebElement myInfoButton => _driver.FindElement(By.XPath("//span[@class='oxd-text oxd-text--span oxd-main-menu-item--name' and text()='My Info'"));
        public IWebElement leaveButton => _driver.FindElement(By.XPath("//span[@class='oxd-text oxd-text--span oxd-main-menu-item--name' and text()='Leave'"));
        public IWebElement dashboardButton => _driver.FindElement(By.XPath("//span[@class='oxd-text oxd-text--span oxd-main-menu-item--name' and text()='Dashboard'"));

        public bool IsExpanded() {
            bool state;
            IWebElement leftArrow = toggleButton.FindElement(By.XPath("//i[@class='oxd-icon bi-chevron-left']"));
            IWebElement rightArrow = toggleButton.FindElement(By.XPath("//i[@class='oxd-icon bi-chevron-right']"));

            if (leftArrow.Displayed) {
                state = true;
            } else if (rightArrow.Displayed) {
                state = false;
            } else {
                // This will lead to an error when the sidebar button can't be found later
                state = false;
            }

            return state;
        }

        public void Expand() {
            if (!IsExpanded()) {
                toggleButton.Click();
            }
        }
    }
}
