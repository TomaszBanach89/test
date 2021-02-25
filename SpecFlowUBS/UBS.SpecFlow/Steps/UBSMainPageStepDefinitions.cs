using NUnit.Framework;
using TechTalk.SpecFlow;
using UBS.PageObjectModels;
using UBS.PageObjectModels.USBHomePage;

namespace UBS.SpecFlow.Steps
{
    [Binding]
    public sealed class UBSMainPageStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private string ubsUrl = "https://www.ubs.com";
        public UBSMainPageStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Open UBS home page")]
        public void GivenOpenUBSHomePage()
        {
            if(CommonMethods.GetWebDriver() != null && !CommonMethods.GetWebDriver().Url.Contains(ubsUrl))
            {
                CommonMethods.GetWebDriver().Navigate().GoToUrl(ubsUrl);
                CommonMethods.AcceptCookies();
            }
        }

        [Then(@"Verify if there is a menu (.*) with submenu as (.*)")]
        public void VerifyMenuAndSubMenuExists(string menuName, string subMenuName)
        {
            if (!UBSHomePage.GetInstance().VerifyHeaderNameExists(subMenuName))
            {
                Assert.IsTrue(UBSHomePage.GetInstance().VerifyIfMenuAndSubMenuExists(menuName, subMenuName));
            }
        }

        [Then(@"Open menu as (.*) and submenu as (.*)")]
        public void OpenMenuAndSubMenu(string menuName, string subMenuName)
        {
            if (!UBSHomePage.GetInstance().VerifyHeaderNameExists(subMenuName)) {
                UBSHomePage.GetInstance().OpenMenuAndSubMenu(menuName, subMenuName);
            }
        }


        [Then(@"Verify if opened page contains any header as (.*)")]
        public void CheckIfPageContainAnyHeaderAs(string subMenuName)
        {
            Assert.IsTrue(UBSHomePage.GetInstance().VerifyHeaderNameExists(subMenuName));
        }

        [Then(@"Click go back to main page")]
        public void ClickGoBack() {
            UBSHomePage.GetInstance().ClickGoBack();
        }
    }
}
