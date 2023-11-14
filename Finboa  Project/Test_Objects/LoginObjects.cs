using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finboa__Project.Test_Objects
{
    public class LoginObjects : Base
    {
        By EmailField = By.XPath("//input[@type='email']");
        By PasswordField = By.XPath("//input[@type='password']");
        By LoginBtn = By.XPath("//button[text()='Login']");
        public void login(string Email, string Password)
        {
            FindElement(EmailField);
            SendKeys(EmailField, Email);
            FindElement(PasswordField);
            SendKeys(PasswordField, Password);
            ClickElement(LoginBtn);
        }

        public void InvalidloginValidate()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            Console.WriteLine("Alert text: " + alertText);

            //IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'alert alert-danger')]")));
            //string errorMessageText = errorMessage.Text;
            //Console.WriteLine("Error message: " + errorMessageText);

        }
    }
}