using Automation.Common;
using Automation.Common.Config;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using FluentAssertions;


namespace Automation.Pages
{
    public class KeyPressesPage : BasePage
    {
        private readonly AppConfig appConfig;
        public KeyPressesPage(ISeleniumContext context) : base(context)
        {
        }
        public By KeyPressesInput { get { return By.Id("target"); } }
        public By KeyPressesResult { get { return By.Id("result"); } }

        public void SendKeysToKeyPressesInput(string text)
        {
            this.SendKeys(KeyPressesInput, text);
        }

        public string GetTextFromKeyPressesResult()
        {
           return this.GetElementText(KeyPressesResult);
        }
    }
}
