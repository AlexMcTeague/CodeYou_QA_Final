using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        public IWebElement addAttachmentsButton => _driver.FindElement(By.XPath("//button[@type='button' and contains(., 'Add')]"));
        public IWebElement uploadFileInput => _driver.FindElement(By.XPath("//input[@type='file']"));
        public IWebElement attachmentCommentTextArea => _driver.FindElement(By.XPath("//textarea"));
        public IWebElement attachmentSaveButton => _driver.FindElements(By.XPath("//button[@type='submit']"))[2];

        public IWebElement attachmentContainer => _driver.FindElement(By.XPath("//div[@class='oxd-table-body' and @role='rowgroup']"));
        public List<IWebElement> attachments => attachmentContainer.FindElements(By.XPath("descendant::div[@role='row']")).ToList();


        public string GetCurrentFullName() {
            string urlMinusEmployeeID = _driver.Url.Substring(0, _driver.Url.LastIndexOf('/') + 1);
            Assert.AreEqual(url, urlMinusEmployeeID);
            string fullName = firstNameCurrentValue + " " + middleNameCurrentValue + " " + lastNameCurrentValue;
            return fullName;
        }
    }
}
