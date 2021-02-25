using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace UBS.Commons
{
    public class Finders
    {
        private Finders() { }
        private static Finders instance;
        private static int timeout = 20;

        public static Finders GetInstance()
        {
            if (instance == null)
            {
                instance = new Finders();
            }
            return instance;
        }

        public IWebElement GetElementBy(By by)
        {
            int timeToWait = timeout;
            IWebElement webElement = null;
            while (timeToWait > 0 && webElement == null) {
                timeToWait--;
                try {
                    webElement = GlobalValues.GetWebDriver().FindElement(by);
                }
                catch (Exception ex) { webElement = null; Thread.Sleep(1000); }
            }
            if(webElement == null) throw new NotFoundException(string.Format("There is no such element within {0}", by));
            return webElement;
        }

        public List<IWebElement> GetElementsBy(By by)
        {
            int timeToWait = timeout;
            List<IWebElement> webElements = null;
            while (timeToWait > 0 && webElements == null)
            {
                timeToWait--;
                try
                {
                    webElements = new List<IWebElement>(GlobalValues.GetWebDriver().FindElements(by));
                }
                catch (Exception ex) { webElements = null; Thread.Sleep(1000); }
            }
            if (webElements == null) throw new NotFoundException(string.Format("There is no such elements within {0}", by));
            return webElements;
        }
    }
}
