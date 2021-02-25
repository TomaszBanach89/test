using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using UBS.PageObjectModels;
using UBS.PageObjectModels.USBHomePage;

namespace UBS.SpecFlow.Steps
{
    [Binding]
    public sealed class DefaultStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private string ubsUrl = "https://www.ubs.com";
        public DefaultStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
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
