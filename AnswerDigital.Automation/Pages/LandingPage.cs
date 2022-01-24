using Automation.Common;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Automation.Pages
{
    public class LandingPage : BasePage
    {
        private readonly ScenarioContext scenarioContext;
        public LandingPage(ISeleniumContext context) : base(context)
        {
        }
        public By FormAuthenticationLink { get { return By.LinkText("Form Authentication"); } }
        public By InfiniteScrollLink { get { return By.LinkText("Infinite Scroll"); } }
        public By KeyPressesLink { get { return By.LinkText("Key Presses"); } }


        public void ClickFormAuthenticationLink()
        {
            this.ClickElement(FormAuthenticationLink);
        }

        public void ClickInfiniteScrollLink()
        {
            this.ClickElement(InfiniteScrollLink);
        }

        public void ClickKeyPressesLink()
        {
            this.ClickElement(KeyPressesLink);
        }
    }       
}
