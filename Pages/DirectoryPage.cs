using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeYou_QA_Final.Pages {
    internal class DirectoryPage {
        private IWebDriver _driver;

        public DirectoryPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/directory/viewDirectory";
        public IWebElement directoryContainer => _driver.FindElement(By.XPath("//div[@class='orangehrm-corporate-directory']"));
        public string recordsFoundText => directoryContainer.FindElement(By.XPath("descendant::span[contains(., 'Records Found')]")).Text;
        public IWebElement recordDisplay => directoryContainer.FindElement(By.XPath("descendant::div[@class='orangehrm-container']"));
        public List<IWebElement> employeeHeaders => recordDisplay.FindElements(By.XPath("descendant::p[@class='oxd-text oxd-text--p orangehrm-directory-card-header --break-words']")).ToList();

        public string GetRandomEmployeeName() {
            _driver.WaitUntilDisplayed(() => directoryContainer);
            _driver.WaitUntilDisplayed(() => recordDisplay);

            string recordsTotal = recordsFoundText.Split('(', ')', ' ')[1];
            //Assert.AreEqual(recordsTotal, employeeHeaders.Count.ToString());

            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.PageDown).Perform();
            recordDisplay.Click();
            string prevRecordsLoaded = "0";
            string recordsLoaded = employeeHeaders.Count.ToString();
            int noChangeCount = 0;
            // If the number of records according to the header is different than the number of records found with FindElements, scroll to the last element to load more
            // This is almost definitely bad practice, but it is fun to watch!
            while (recordsTotal != recordsLoaded) {
                actions.SendKeys(Keys.PageDown).Perform();
                Thread.Sleep(200);
                prevRecordsLoaded = recordsLoaded;
                recordsLoaded = employeeHeaders.Count.ToString();
                if (recordsLoaded == prevRecordsLoaded) {
                    noChangeCount++;
                    if (noChangeCount > 10) {
                        break;
                    }
                } else {
                    noChangeCount = 0;
                }
            }

            Assert.AreEqual(recordsTotal, employeeHeaders.Count.ToString());

            Random rnd = new Random();
            int r = rnd.Next(employeeHeaders.Count);

            IWebElement employeeRecord = employeeHeaders[r];

            return employeeRecord.Text;
        }

        public string GetRandomEmployeeNameViaNewTab() {
            string prevTab = _driver.CurrentWindowHandle;
            string prevUrl = _driver.Url;
            _driver.SwitchTo().NewWindow(WindowType.Tab);
            Assert.AreEqual("", _driver.Title);
            _driver.Url = url;
            string employeeName = GetRandomEmployeeName();
            _driver.Close();
            _driver.SwitchTo().Window(prevTab);
            Assert.AreEqual(prevUrl, _driver.Url);

            return employeeName;
        }
    }
}
