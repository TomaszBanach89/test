using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;
using UBS.PageObjectModels;
using UBS.PageObjectModels.USBHomePage;
using UBS.PageObjectModels.USBHomePage.Careers;

namespace UBS.SpecFlow.Steps
{
    [Binding]
    public sealed class SearchJobsStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private string ubsUrl = "https://www.ubs.com";
        public SearchJobsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"Verify available locations as (.*) for searching jobs")]
        public void ThenVerifyAvailableLocationsAsCareersForSearchingJobs(string location)
        {
            Assert.IsTrue(SearchJobs.GetInstance().CheckIfLocationExists(location));
        }

        [Then(@"Jobs are listed")]
        public void JobsAreListed()
        {
            Assert.IsTrue(SearchJobs.GetInstance().GetJobList().Count > 0);
        }

        [Then(@"Click search for jobs")]
        public void ThenClickSearchForJobs()
        {
            SearchJobs.GetInstance().ClickSearch();
            Thread.Sleep(5000);
        }

        [Then(@"Click (.*) for location as (.*)")]
        public void ThenClickProffesionalsForLocationAsPoland(string buttonName, string location)
        {
            SearchJobs.GetInstance().ClickButtonForLocation(buttonName, location);
            Thread.Sleep(3000);
        }

        [Given(@"Input (.*) into job search bar")]
        public void GivenInputTestEngineerIntoJobSearchBar(string jobName)
        {
            SearchJobs.GetInstance().InputJobSearchBar(jobName);
        }

        [Then(@"Input (.*) into country search bar")]
        public void GivenInputPolandIntoCountrySearchBar(string location)
        {
            SearchJobs.GetInstance().InputLocationSearchBar(location);

        }

    }
}
