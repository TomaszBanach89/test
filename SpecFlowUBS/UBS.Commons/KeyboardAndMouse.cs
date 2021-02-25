using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace UBS.Commons
{
    public class KeyboardAndMouse
    {
        private KeyboardAndMouse() { }
        private static KeyboardAndMouse instance;
        private static Actions actions;
        public static KeyboardAndMouse GetInstance()
        {
            if (instance == null)
            {
                instance = new KeyboardAndMouse();
                actions = new Actions(GlobalValues.GetWebDriver());
            }
            return instance;
        }

        public void ClickOnWebElement(IWebElement webElement) {
            actions.MoveToElement(webElement);
            actions.Click(webElement);
        }

        public void DoubleClick(IWebElement webElement) {
            actions.MoveToElement(webElement);
            actions.DoubleClick(webElement);
        }
    }
}
