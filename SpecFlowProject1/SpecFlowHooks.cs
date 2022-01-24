using Automation.Common;
using Automation.Common.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace Automation.Hooks
{
    [Binding]
    public sealed class SpecFlowHooks
    {
        private readonly IWebDriver driver;
        private readonly AppConfig _config;

        public SpecFlowHooks (ISeleniumContext context, AppConfig config )
        {
            _config = config;
            driver = context.WebDriver;;
        }

        [BeforeScenario("GoToHomePage")]
        public void GoToHomePage()
        {
            driver.Url = _config.Website.Url;
            driver.Manage().Window.Maximize();
        }

        [AfterScenario(Order = 1)]
        public void CleanUp()
        {
            driver.Quit();
        }

        
    }
}