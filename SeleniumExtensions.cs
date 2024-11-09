using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeYou_QA_Final {
    public static class SeleniumExtensions {

        public static void ScrollAndClick(this IWebElement element, IWebDriver driver) {
            Actions actions = new Actions(driver);
            actions.ScrollToElement(element).Click(element).Perform();
        }
        public static void WaitUntilDisplayed(this IWebDriver driver, Func<IWebElement> element) {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => element().Displayed);
        }
        public static void WaitAndClick(this IWebDriver driver, Func<IWebElement> element) {
            WaitUntilDisplayed(driver, element);
            element().ScrollAndClick(driver);
        }
        public static List<IWebElement> WaitForElementsByXPath(this IWebDriver driver, string xpath) {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => driver.FindElement(By.XPath(xpath)));
            return driver.FindElements(By.XPath(xpath)).ToList();
        }
    }
}
