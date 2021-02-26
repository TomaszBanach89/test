using OpenQA.Selenium;
using System;

namespace UBS.Commons
{
    public class GlobalValues
    {
        private static IWebDriver webDriver = null;
        private static ConfigMasterObject configMasterObject = null;

        public static void SetWebDriver(IWebDriver wd) { webDriver = wd; }
        public static IWebDriver GetWebDriver() { return webDriver; }
        public static void SetConfigMasterObject(ConfigMasterObject config) { configMasterObject = config; }

        public static ConfigMasterObject GetConfigMasterObject() { return configMasterObject; }
    }
}
