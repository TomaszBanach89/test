using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using UBS.Commons;

namespace UBS.PageObjectModels
{
    public static class CommonMethods
    {
        public static IWebDriver GetWebDriver()
        {
            if (GlobalValues.GetWebDriver() == null)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("headless");
                GlobalValues.SetWebDriver(new ChromeDriver(chromeOptions));
            }
            return GlobalValues.GetWebDriver();
        }

        public static void AcceptCookies()
        {
            Finders.GetInstance().GetElementBy(By.XPath("//button[.//span[contains(text(), 'Agree to all')]]")).Click();
        }

        public static void SetWebDriver(IWebDriver webDriver)
        {
            GlobalValues.SetWebDriver(webDriver);
        }
    }
}