using Automation.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Automation.BrowserDrivers
{
    public class ChromeContext : ISeleniumContext
    {
        public IWebDriver WebDriver { get; private set; }
        private readonly ScenarioContext scenarioContext;

        public ChromeContext(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
            
            ChromeOptions options = new ChromeOptions
            {
                Proxy = null                
            };

            String[] tagsArray = scenarioContext.ScenarioInfo.Tags;
            scenarioContext["RequiresSmallerScreen"] = false;

            options.AddArguments("--start-maximized");

            options.AddArgument("no-sandbox");

            WebDriver = new ChromeDriver(driverService, options);

            //WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}