using NUnit.Framework;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using UBS.Commons;
using UBS.PageObjectModels;
using UBS.PageObjectModels.USBHomePage;

namespace UBS.SpecFlow.Steps
{
    [Binding]
    public sealed class UBSMainPageStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        public UBSMainPageStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Open UBS home page")]
        public void GivenOpenUBSHomePage()
        {
            var ubsURL = GlobalValues.GetConfigMasterObject().ApplicationURL;
            Console.WriteLine(ubsURL);
            if (CommonMethods.GetWebDriver() != null && !CommonMethods.GetWebDriver().Url.Contains(ubsURL)) 
            {
                CommonMethods.GetWebDriver().Navigate().GoToUrl(ubsURL);
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
