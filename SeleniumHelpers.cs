﻿using OpenQA.Selenium.Interactions;
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

        public string ToPigLatin(string sentence) {

            string vowels = "AEIOUaeiou";
            List<string> pigWords = new List<string>();

            foreach (string word in sentence.Split(' ')) {
                string firstLetter = word.Substring(0, 1);
                string secondLetter = word.Substring(1, 1);
                string thirdLetter = word.Substring(2, 1);
                string restOfWord = word.Substring(3, word.Length - 3);

                if (vowels.IndexOf(firstLetter) == -1) {
                    vowels += "y";
                    if (vowels.IndexOf(secondLetter) == -1) {
                        if (vowels.IndexOf(secondLetter) == -1) {
                            pigWords.Add(restOfWord + firstLetter + secondLetter + thirdLetter + "ay");
                        } else {
                            pigWords.Add(thirdLetter + restOfWord + firstLetter + secondLetter + "ay");
                        }
                    } else {
                        pigWords.Add(secondLetter + thirdLetter + restOfWord + firstLetter + "ay");
                    }
                } else {
                    pigWords.Add(word + "yay");
                }
            }
            return string.Join(" ", pigWords);
        }
    }
}
