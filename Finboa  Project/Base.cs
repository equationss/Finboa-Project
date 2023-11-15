﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Drawing.Imaging;
using System.Drawing;
using OpenQA.Selenium.Firefox;

namespace Finboa__Project
{
    public class Base
    {

        #region Driver&URL
        public static IWebDriver driver;
        public static IWebDriver Driver(string browser)
        {
            if (browser == "Chrome")
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--disable-notifications");
                driver = new ChromeDriver(options);

            }
            if (browser == "FireFox")
            {
                driver = new FirefoxDriver();
            }
            return driver;
        }
        #endregion


        #region SendKeys
        public void SendKeys(By locator, string text)
        {
            if (driver.FindElement(locator).GetAttribute("value") != " ")
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
            else
            {
                driver.FindElement(locator).SendKeys(text);
            }
        }
        #endregion

        #region Click
        public void ClickElement(By locator)
        {
            driver.FindElement(locator).Click();
        }
        #endregion


        #region DriverClose
        public static void Close()
        {
            driver.Dispose();
        }
        #endregion


        #region ClickElement
        public void ClickWebElement(IWebElement element, IWebDriver driver)
        {
            try
            {
                element.Click();
            }
            catch (WebDriverException e)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", element);
            }
        }
        #endregion


        #region FindElement
        public void FindElement(By locator, double timeoutInSeconds = 60)
        {
            if (timeoutInSeconds == 0)
            {
                driver.FindElement(locator);
                ClickElement(locator);
            }
            else
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                ClickElement(locator);
            }
        }
        #endregion

        public void SortDown(By Locator, string Value)
        {
            IWebElement sortDropdown = driver.FindElement(Locator);
            SelectElement select = new SelectElement(sortDropdown);
            select.SelectByText(Value);
            sortDropdown.Click();
        }

        #region DropDown
        public void Dropdown(By loc, string type, string value)
        {
            IWebElement element = driver.FindElement(loc);
            SelectElement dropdown = new SelectElement(element);
            if (type == "value")
            {
                dropdown.SelectByValue(value);

                element.Click();
            }
            else if (type == "text")
            {
                dropdown.SelectByText(value);
                element.Click();
            }
            else if (type == "index")
            {
                dropdown.SelectByIndex(Convert.ToInt32(value));
                element.Click();
            }
        }
        #endregion

        #region Displayed
        public bool IsElementDisplayed(By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion

        #region

        public string GetElementText(By by)
        {
            string text;
            try
            {
                text = driver.FindElement(by).Text;
            }
            catch
            {
                try
                {
                    text = driver.FindElement(by).GetAttribute("value");
                }
                catch
                {
                    text = driver.FindElement(by).GetAttribute("innerHTML");
                }
            }
            return text;
        }

        #endregion

        public void Scroll(By Locator)
        {
            var e = driver.FindElement(Locator);
            // JavaScript Executor to scroll to element
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", e);
        }

        public void ScreenShot()
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(@".\\Screenshot.png", ScreenshotImageFormat.Png);
        }
    }
}
