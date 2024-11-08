using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYou_QA_Final.Pages {
    internal class DirectoryPage {
        private IWebDriver _driver;

        public DirectoryPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/directory/viewDirectory";
        public IWebElement directoryContainer => _driver.FindElement(By.XPath("//div[@class='orangehrm-corporate-directory']"));
        public List<IWebElement> employeeHeaders => _driver.FindElements(By.XPath("//p[@class='oxd-text oxd-text--p orangehrm-directory-card-header --break-words']")).ToList();

        public string GetRandomEmployee() {
            List<string> employees = new List<string>();
            _driver.WaitUntilDisplayed(() => directoryContainer);

            foreach (IWebElement element in employeeHeaders) {
                string employee = element.Text;
                employees.Add(employee);
            }

            Random rnd = new Random();
            int r = rnd.Next(employees.Count);
            return employees[r];
        }
    }
}
