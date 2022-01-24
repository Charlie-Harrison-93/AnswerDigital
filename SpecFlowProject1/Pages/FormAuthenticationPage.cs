using Automation.Common;
using Automation.Common.Config;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using FluentAssertions;


namespace Automation.Pages
{
    public class FormAuthenticationPage : BasePage
    {
        private readonly AppConfig appConfig;
        public FormAuthenticationPage(ISeleniumContext context) : base(context)
        {
        }
        public By UsernameInput { get { return By.Id("username"); } }
        public By PasswordInput { get { return By.Id("password"); } }
        public By LoginButton { get { return By.XPath("//button[@type='submit']"); } }

        public void LogInWithValidCredentials()
        {
            SendKeysToUsernameInput();
            SendKeysToPasswordInput();
            ClickLoginButton();
        }

        public void LogInWitInhvalidUsername()
        {
            SendKeysToUsernameInputInvalid();
            SendKeysToPasswordInput();
            ClickLoginButton();
        }
        public void LogInWitInhvalidPassword()
        {
            SendKeysToUsernameInput();
            SendKeysToPasswordInputInvalid();
            ClickLoginButton();
        }

        public void SendKeysToUsernameInput()
        {
            this.SendKeysWithClear(UsernameInput, appConfig.Website.Username);
        }

        public void SendKeysToUsernameInputInvalid()
        {
            this.SendKeysWithClear(UsernameInput, appConfig.Website.InvalidUsername);
        }

        public void SendKeysToPasswordInput()
        {
            this.SendKeysWithClear(UsernameInput, appConfig.Website.Password);
        }

        public void SendKeysToPasswordInputInvalid()
        {
            this.SendKeysWithClear(UsernameInput, appConfig.Website.InvalidPassword);
        }

        public void ClickLoginButton()
        {
            this.ClickElement(LoginButton);
        }
    }
}
