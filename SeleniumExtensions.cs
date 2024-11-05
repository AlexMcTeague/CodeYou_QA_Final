using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace CodeYou_QA_Final {
    public static class SeleniumExtensions {

        public static void ScrollAndClick(this IWebElement element, IWebDriver driver) {
            Actions actions = new Actions(driver);
            actions.ScrollToElement(element).Click(element).Perform();
        }

        public static void WaitUntilDisplayed(this IWebDriver driver, Func<IWebElement> element) {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(d => element().Displayed);
        }
    }
}
