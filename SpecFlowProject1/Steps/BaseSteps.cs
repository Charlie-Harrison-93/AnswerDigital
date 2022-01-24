using Automation.Common;
using TechTalk.SpecFlow;
using Automation.Common.Config;
using FluentAssertions;

namespace Automation.Steps
{
    [Binding]
    public class BaseSteps
    {
        private readonly AppConfig appConfig;
        private readonly BasePage basePage;

        public BaseSteps(AppConfig appConfig, BasePage basePage)
        {
            this.appConfig = appConfig;
            this.basePage = basePage;
        }

        [Given(@"I have navigated to the Herokuapp landing page")]
        public void NavigateToHerokuappLandingPage()
        {
            basePage.NavigateToSite(appConfig.Website.Url);
        }

        [Then(@"I can see the text '(.*)'")]
        public void ThenICanSeeTheText(string text)
        {
            basePage.ElementByPartialTextIsDisplayed(text).Should().BeTrue();
        }
    }
}
