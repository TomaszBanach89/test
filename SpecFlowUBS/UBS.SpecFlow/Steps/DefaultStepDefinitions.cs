using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using ServiceStack.Text;
using System;
using TechTalk.SpecFlow;
using UBS.Commons;
using UBS.PageObjectModels;
using UBS.PageObjectModels.USBHomePage;

namespace UBS.SpecFlow.Steps
{
    [Binding]
    public sealed class DefaultStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private string ubsUrl = GlobalValues.GetConfigMasterObject().ApplicationURL;
        public DefaultStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeFeature()]
        public static void LoadConfig() {
            new JsonConfigLoader().Load();
        }

        [AfterScenario()]
        public void CleanupScenario() {
            if (ScenarioContext.Current.ScenarioExecutionStatus.Equals(ScenarioExecutionStatus.TestError)) {
                try
                {
                    CommonMethods.GetWebDriver().Navigate().GoToUrl(ubsUrl);
                    CommonMethods.AcceptCookies();
                }
                catch (Exception ex) { }
            }
        }

        [AfterFeature()]
        public static void CleanupFeature()
        {
            CommonMethods.GetWebDriver().Quit();
            CommonMethods.SetWebDriver(null);
        }
    }
}
