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
    }
}
