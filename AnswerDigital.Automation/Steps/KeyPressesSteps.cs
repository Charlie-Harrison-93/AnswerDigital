using Automation.Common;
using NUnit.Framework;
using Automation.Pages;
using TechTalk.SpecFlow;
using Automation.Common.Config;
using FluentAssertions;

namespace Automation.Steps
{
    [Binding]
    public class KeyPressesSteps
    {
        private readonly KeyPressesPage keyPressesPage;

        public KeyPressesSteps(KeyPressesPage keyPressesPage)
        {
            this.keyPressesPage = keyPressesPage;
        }

        [When(@"I send the text '(.*)' into the Key Presses input")]
        public void ISendTheTextIntoTheKeyPressesInput(string text)
        {
            keyPressesPage.SendKeysToKeyPressesInput(text);
        }

        [Then(@"I can see the text '(.*)' in the Key Presses result")]
        public void ICanSeeTheTextInTheKeyPressesResult(string expectedText)
        {
            string actualText = keyPressesPage.GetTextFromKeyPressesResult();
            expectedText.Should().Equals(actualText);
        }
    }
}
