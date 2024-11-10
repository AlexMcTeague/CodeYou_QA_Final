using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYou_QA_Final.Pages {
    internal class MyInfoPage {
        private IWebDriver _driver;

        public MyInfoPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewPersonalDetails/empNumber/";

        public IWebElement firstNameTextbox => _driver.FindElement(By.XPath("//input[@name='firstName']"));
        public string firstNameCurrentValue => firstNameTextbox.GetAttribute("value");
        public IWebElement middleNameTextbox => _driver.FindElement(By.XPath("//input[@name='middleName']"));
        public string middleNameCurrentValue => middleNameTextbox.GetAttribute("value");
        public IWebElement lastNameTextbox => _driver.FindElement(By.XPath("//input[@name='lastName']"));
        public string lastNameCurrentValue => lastNameTextbox.GetAttribute("value");

        public IWebElement detailsSaveButton => _driver.FindElements(By.XPath("//button[@type='submit']"))[0];

        public IWebElement editDetailsSuccessToast => _driver.FindElement(By.XPath("//p[@class='oxd-text oxd-text--p oxd-text--toast-message oxd-toast-content-text' and contains(., 'Successfully Updated')]"));
    }
}
