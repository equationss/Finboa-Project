using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Finboa__Project.Test_Objects
{
    public class LoginObjects : Base
    {
        private string baseUrl = ConfigurationReader.BaseUrl;


        By EmailField = By.XPath("//input[@type='email']");
        By PasswordField = By.XPath("//input[@type='password']");
        By LoginBtn = By.XPath("//button[text()='Login']");
        By OTP = By.Id("otp");
        By Auth = By.XPath("(//button[@type='button'])[3]");
        public void login(string Email, string Password)
        {
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();

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

        public void EmptyFieldsValidate()
        {

            IWebElement errorMessage = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Enter a valid email.']")));
            string errorMessageText = errorMessage.Text;
            Console.WriteLine(errorMessageText);
            Assert.AreEqual("Enter a valid email.", errorMessageText);

        }

        public void OnlyEmailValidate()
        {

            IWebElement errorMessage = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[text()='Login']")));
          

        }

        public void Otp(string otp)
        {
            FindElement(OTP);
            SendKeys(OTP, otp);
            ClickElement(Auth);
        }

       public void ValidLoginValidate() 
        {

            IWebElement Message = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.ElementIsVisible(By.XPath("//h3[text()='Dashboard']")));
            string MessageText = Message.Text;
            Console.WriteLine(MessageText);
            Assert.AreEqual("Dashboard", MessageText);


        }
    }
}