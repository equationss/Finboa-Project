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

            IWebElement errorMessage = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'alert alert-danger')]")));
            string errorMessageText = errorMessage.Text;
            Console.WriteLine(errorMessageText);
            Assert.AreEqual("The user name or password is incorrect.", errorMessageText);

        }
    }
}