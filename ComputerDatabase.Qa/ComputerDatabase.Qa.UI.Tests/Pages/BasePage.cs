﻿using ComputerDatabase.Qa.UI.Tests.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerDatabase.Qa.UI.Tests.Pages
{
    public class BasePage : IBasePage
    {
        #region Locators
        protected IWebElement Header => WebDriver.FindElement(By.CssSelector("h1.fill > a"));
        #endregion

        public IWebDriver WebDriver { get; }

        public BasePage(IWebDriver webDriver)    
        {
            WebDriver = webDriver;
        }

        public ComputersPage ReturnToComputersPage()
        {
            Header.Click();
            return new ComputersPage(WebDriver);
        }

        public string GetCurrentUrl()
        {
            return WebDriver.Url;
        }
    }
}
