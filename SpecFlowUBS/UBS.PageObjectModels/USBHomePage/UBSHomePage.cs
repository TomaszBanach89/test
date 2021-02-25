using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using UBS.Commons;

namespace UBS.PageObjectModels.USBHomePage
{
    public class UBSHomePage
    {
        private UBSHomePage() { }

        private const string MainMenuButtonXpath = "//*[@id='mainnavigation']//li[@data-simplemenu='true']//button[contains(text(), '{0}')]";
        private const string SubMenuButtonXpath = "//*[@id='mainnavigation']//li[@data-simplemenu='true'][.//button[contains(text(), '{0}')]]//a[contains(text(), '{1}')]";
        private static UBSHomePage instance;

        public static UBSHomePage GetInstance()
        {
            if (instance == null)
            {
                instance = new UBSHomePage();
            }
            return instance;
        }

        public Boolean VerifyIfMenuAndSubMenuExists(string menuName, string subMenuName)
        {
            IWebElement menuControl = GetMenuControl(menuName);
            IWebElement subMenuControl = GetSubMenuControl(menuName, subMenuName);
            return menuControl != null && subMenuControl != null;
        }

        public void OpenMenuAndSubMenu(string menuName, string subMenuName) {
            JavaScriptOperators.GetInstance().JavaScriptClick(GetMenuControl(menuName));
            JavaScriptOperators.GetInstance().JavaScriptClick(GetSubMenuControl(menuName, subMenuName));
        }

        public Boolean VerifyHeaderNameExists(string headerName) {
            IWebElement mainHeader = Finders.GetInstance().GetElementBy(By.CssSelector(".header__wrapper span.header__hlTitle"));
            IWebElement subHeader = Finders.GetInstance().GetElementBy(By.CssSelector("div h1"));
            List<IWebElement> webElements = new List<IWebElement>();
            webElements.Add(mainHeader);
            webElements.Add(subHeader);
            return webElements.Any(e => e.Text.Contains(headerName));
            
        }

        public void ClickGoBack()
        {
            IWebElement logoButton = Finders.GetInstance().GetElementBy(By.CssSelector(".logo__wrapper"));
            logoButton.Click();
        }

        private static IWebElement GetSubMenuControl(string menuName, string subMenuName)
        {
            return Finders.GetInstance().GetElementBy(By.XPath(string.Format(SubMenuButtonXpath, menuName, subMenuName)));
        }

        private static IWebElement GetMenuControl(string menuName)
        {
            return Finders.GetInstance().GetElementBy(By.XPath(string.Format(MainMenuButtonXpath, menuName)));
        }
    }
}
