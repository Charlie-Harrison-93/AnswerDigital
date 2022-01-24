using Automation.Common;
using NUnit.Framework;
using Automation.Pages;
using TechTalk.SpecFlow;
using Automation.Common.Config;

namespace Automation.Steps
{
    [Binding]
    public class InfiniteScrollSteps
    {
        private readonly InfiniteScrollPage infiniteScrollPage;

        public InfiniteScrollSteps(InfiniteScrollPage infiniteScrollPage)
        {
            this.infiniteScrollPage = infiniteScrollPage;
        }

        [When(@"I scroll down '(.*)' times")]
        public void WhenIScrollDownTimes(int number)
        {
            infiniteScrollPage.ScrollXAmount(number);
        }

        [Then(@"I can see the page has loaded '(.*)' times")]
        public void ThenICanSeeThePageHasLoadedTimes(int number)
        {
            infiniteScrollPage.IsParagraphXDisplayed(number);
        }
    }
}
