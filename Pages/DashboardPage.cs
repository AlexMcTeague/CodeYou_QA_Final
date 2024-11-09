using OpenQA.Selenium;

namespace CodeYou_QA_Final.Pages {
    internal class DashboardPage {
        private IWebDriver _driver;

        public DashboardPage(IWebDriver d) {
            _driver = d;
        }

        public string url = "https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index";
    }
}
