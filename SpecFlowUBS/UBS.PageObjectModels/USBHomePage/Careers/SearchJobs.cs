using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UBS.Commons;

namespace UBS.PageObjectModels.USBHomePage.Careers
{
    public class SearchJobs
    {
        private const string locationsXpath = "//h2[@class='teaser__hl']//span[contains(text(), '{0}')]";
        private const string locationNamesLocator = "h2.teaser__hl span";
        private const string JobListItemsXpath = "//*[@aria-label='Job List']//li";
        private const string SearchButtonXpath = "//button[.//*[contains(text(), 'Search')]]";
        private static SearchJobs instance;

        public static SearchJobs GetInstance()
        {
            if (instance == null)
            {
                instance = new SearchJobs();
            }
            return instance;
        }

        public Boolean CheckIfLocationExists(string locationName) {
            return Finders.GetInstance().GetElementBy(By.XPath(string.Format(locationsXpath, locationName))) != null;
        }

        private List<IWebElement> GetLocationNames()
        {
            return Finders.GetInstance().GetElementsBy(By.CssSelector(locationNamesLocator));
        }

        public List<IWebElement> GetJobList()
        {
            return Finders.GetInstance().GetElementsBy(By.XPath(JobListItemsXpath));
        }

        public void ClickSearch()
        {
            JavaScriptOperators.GetInstance().JavaScriptClick(Finders.GetInstance().GetElementBy(By.XPath(SearchButtonXpath)));
        }

        public void ClickButtonForLocation(string buttonName, string location)
        {
            Thread.Sleep(1000);
            Finders.GetInstance().GetElementBy(By.XPath(string.Format("//*[contains(@class,'teaser__content')][.//span[contains(text(), '{0}')]]//a[contains(text(), '{1}')]", location, buttonName))).Click();
        }

        public void InputJobSearchBar(string jobName)
        {
            GetTextBoxAndInputThere(jobName, "keyWordSearch");
        }

        public void InputLocationSearchBar(string locationName)
        {
            GetTextBoxAndInputThere(locationName, "locationSearch");
        }

        private static void GetTextBoxAndInputThere(string value, string name)
        {
            Finders.GetInstance().GetElementBy(By.XPath(string.Format("//input[@name='{0}']", name))).SendKeys(value);
            Thread.Sleep(3000);
        }
    }
}
