using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CodeYou_QA_Final {
    public static class SeleniumExtensions {


        public static void ScrollAndClick(this IWebElement element) {
            IWebDriver driver = new FirefoxDriver();
            Actions actions = new Actions(driver);
            actions.ScrollToElement(element).Click(element).Perform();
        }
    }
}
