using OpenQA.Selenium;

namespace Automation.Common
{
    public interface ISeleniumContext
    {
        IWebDriver WebDriver { get; }
    }
}