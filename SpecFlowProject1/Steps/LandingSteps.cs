using Automation.Common;
using NUnit.Framework;
using Automation.Pages;
using TechTalk.SpecFlow;
using Automation.Common.Config;

namespace Automation.Steps
{
    [Binding]
    public class LandingSteps
    {
        private readonly AppConfig appConfig;
        private readonly LandingPage landingPage;

        public LandingSteps(AppConfig appConfig, LandingPage landingPage)
        {
            this.appConfig = appConfig;
            this.landingPage = landingPage;
        }

        [Given(@"I have clicked the Form Authentication link")]
        public void IOpenTheFormAuthenticationLink()
        {
            landingPage.ClickFormAuthenticationLink();
        }

        [Given(@"I have clicked the Infinite Scroll link")]
        public void IOpenTheFormInfiniteScrollLink()
        {
            landingPage.ClickInfiniteScrollLink();
        }

        [Given(@"I have clicked the Key Presses link")]
        public void IOpenTheKeyPressesLink()
        {
            landingPage.ClickKeyPressesLink();
        }
    }
}
