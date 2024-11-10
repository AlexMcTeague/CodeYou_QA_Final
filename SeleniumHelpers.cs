using OpenQA.Selenium;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeYou_QA_Final {
    internal class SeleniumHelpers {
        public IWebDriver _driver;

        public SeleniumHelpers(IWebDriver driver) {
            _driver = driver;
        }

        public string GenerateRandomPassword(int length) {
            // TODO: Guarantee a lowercase letter, uppercase letter, and symbol (in addition to a digit)
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*()_+0123456789";
            string nums = "0123456789";
            Random random = new Random();

            string password = "";
            for (int i = 0; i < (length - 1); i++) {
                password += chars[random.Next(chars.Length)];
            }

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
            if (sentence.Length > 25) {
                sentence = sentence.Substring(0, 25);
            }
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

        public string ShortenName(string fullName) {
            string[] words = fullName.Split(' ');
            string shortName = words.First() + " " + words.Last();
            return shortName;
        }
    }
}
