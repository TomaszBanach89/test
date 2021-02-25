using OpenQA.Selenium;
using System;

namespace UBS.Commons
{
    public class GlobalValues
    {
        private static IWebDriver webDriver = null;

        public static void SetWebDriver(IWebDriver wd) { webDriver = wd; }
        public static IWebDriver GetWebDriver() { return webDriver; }
    }
}
