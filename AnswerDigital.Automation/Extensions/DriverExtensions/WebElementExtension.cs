using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Automation.Common
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timespan)
        {
            if (timespan > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            return driver.FindElement(by);
        }

        public static bool InvisibilityOfElementLocated(this IWebDriver driver, By by, int timespan)
        {
            bool isTrue;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));
            try { isTrue = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by)); }
            catch { isTrue = false; }
            return isTrue;
        }

        public static string FindElementText(this IWebDriver driver, By by, int timespan, string text)
        {
            string actualText;
            bool isTrue;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));
            try {isTrue = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(driver.FindElement(by), text)); }
            catch { isTrue = false; }
            if (isTrue == false) actualText = driver.FindElement(by).Text;
            else actualText = text;
            return actualText;
        }

        public static ReadOnlyCollection <IWebElement> FindAllElements(this IWebDriver driver, By by, int timespan)
        {
            if (timespan > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));
                return (ReadOnlyCollection<IWebElement>)wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            }
            return driver.FindElements(by);
        }

        public static IWebElement FindElementWhenClickable(this IWebDriver driver, By by, int timespan)
        {
            if (timespan > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            return driver.FindElement(by);
        }

        public static void WaitForElementToDissapear(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public static IWebElement FindElementByTestId(this IWebDriver driver, string selector, int timespan = 5)
        {
            return driver.FindElement(By.CssSelector($"[data-test-id='{selector}']"), timespan);
        }

        public static IWebElement FindElementByAriaLabel(this IWebDriver driver, string selector, int timespan = 5)
        {
            return driver.FindElement(By.CssSelector($"[aria-label='{selector}']"), timespan);
        }

        public static bool WaitForExpectedURL(this IWebDriver driver, string url, int timeout = 5)
        {
            bool result;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(url));
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
