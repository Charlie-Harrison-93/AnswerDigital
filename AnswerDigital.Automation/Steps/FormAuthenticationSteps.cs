using Automation.Common;
using NUnit.Framework;
using Automation.Pages;
using TechTalk.SpecFlow;
using Automation.Common.Config;

namespace Automation.Steps
{
    [Binding]
    public class FormAuthenticationSteps
    {
        private readonly FormAuthenticationPage formAuthenticatioPage;

        public FormAuthenticationSteps(FormAuthenticationPage formAuthenticatioPage)
        {
            this.formAuthenticatioPage = formAuthenticatioPage;
        }

        [When(@"I log into Herokuapp with the correct credentials")]
        public void ILogIntoHerokuappWithTheCorrectCredentials()
        {
            formAuthenticatioPage.LogInWithValidCredentials();
        }

        [When(@"I log into Herokuapp with the incorrect username")]
        public void ILogIntoHerokuappWithTheIncorrectUsername()
        {
            formAuthenticatioPage.LogInWitInhvalidUsername();
        }

        [When(@"I log into Herokuapp with the incorrect password")]
        public void ILogIntoHerokuappWithTheIncorrectPassword()
        {
            formAuthenticatioPage.LogInWitInhvalidPassword();
        }
    }
}
