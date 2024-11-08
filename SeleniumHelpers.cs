using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace CodeYou_QA_Final {
    internal class SeleniumHelpers {
        public IWebDriver _driver;

        public SeleniumHelpers(IWebDriver driver) {
            _driver = driver;
        }

        public string GetRandomPassword(int length) {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*()_+0123456789";
            string nums = "0123456789";
            var random = new Random();

            string password = new string(Enumerable.Repeat(chars, length - 1)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            char nextChar;
            if (password.Any(char.IsDigit)) {
                nextChar = chars[random.Next(chars.Length)];
            } else {
                nextChar = nums[random.Next(nums.Length)];
            }

            password += nextChar;

            return password;
        }
    }
}
