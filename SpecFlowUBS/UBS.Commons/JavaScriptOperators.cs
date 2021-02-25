using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UBS.Commons
{
    public class JavaScriptOperators
    {
        private static JavaScriptOperators instance;

        public static JavaScriptOperators GetInstance()
        {
            if (instance == null)
            {
                instance = new JavaScriptOperators();
            }
            return instance;
        }
        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalValues.GetWebDriver();
            executor.ExecuteScript("arguments[0].click();", element);
        }
    }
}
