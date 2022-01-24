using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Linq;
using FluentAssertions;

namespace Automation.Common
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        public WebDriverWait wait;
        public TimeSpan defaultTimeOut = TimeSpan.FromSeconds(5);
        public const string expandedClass = "Mui-expanded";

        public BasePage()
        {
        }

        public void NavigateToSite(string url)
        {
            driver.Url = url;
        }

        public void SendKeys(By selector, string text)
        {
            driver.FindElement(selector).SendKeys(text);
        }

        public void ClearElement(By selector)
        {
            driver.FindElement(selector, 5).Clear();
        }

        public void SendKeysWithClear(By selector, string text)
        {
            ClearElement(selector);
            SendKeys(selector, text);
        }

        public void SetImplicitWait()
        {
            wait = new WebDriverWait(driver, defaultTimeOut);
        }

        public BasePage(ISeleniumContext context)
        {
            driver = context.WebDriver;
        }

        public IWebElement GetElement(By by)
        {
            return driver.FindElement(by, 5);
        }

        public void ClickElement(By by)
        {
            driver.FindElementWhenClickable(by, 5).Click();
        }
        public string GetElementText(By by)
        {
            return driver.FindElement(by, 5).Text;
        }

        public IWebElement GetElementByText(string text)
        {
            return driver.FindElement(By.XPath($"//*[text()= '{text}']"), 5);
        }

        public IWebElement GetElementByPartialText(string text)
        {
            return driver.FindElement(By.XPath($"//*[contains( text(), '{text}')]"), 5);
        }

        public bool ElementByTextIsDisplayed(string text)
        {
            return GetElementByText(text).Displayed;
        }

        public bool ElementByPartialTextIsDisplayed(string text)
        {
            return GetElementByPartialText(text).Displayed;
        }

        public bool ElemenBytIsDisplayed(By by)
        {
            return driver.FindElement(by, 5).Displayed;
        }

        public int GetElementHeight(By by)
        {
            IWebElement element = driver.FindElement(by, 5);
            int elementHeight = element.Size.Height;
            return elementHeight;
        }

        public void ScrollByHeight(int height)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript($"scroll(0, {height})");
        }
    }
}
