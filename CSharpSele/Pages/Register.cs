using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSele.Pages
{
    public class Register
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        // Locators
        private readonly string _usernameID = "UserName";
        private readonly string _passwordID = "Password";
        private readonly string _confirmPasswordID = "ConfirmPassword";
        private readonly string _emailID = "Email";
        private readonly string _registerXpath = "//input[@value='Register']";

        public Register(IWebDriver driver)
        { 
            this._driver = driver;
            _loginPage = new LoginPage(_driver);
        }

        IWebElement GetUserNameField => _driver.FindElement(By.Id(_usernameID));
        IWebElement GetPasswordField => _driver.FindElement(By.Id(_passwordID));
        IWebElement GetConfirmPasswordField => _driver.FindElement(By.Id(_confirmPasswordID));
        IWebElement GetEmailIDField => _driver.FindElement(By.Id(_emailID));
        IWebElement GetRegisterButton => _driver.FindElement(By.XPath(_registerXpath));

        //Actions
        public void RegisterUser(string userName, string password, string confirmPassword, string email) 
        {
            GetUserNameField.SendKeys(userName);
            GetPasswordField.SendKeys(password);
            GetConfirmPasswordField.SendKeys(confirmPassword);
            GetEmailIDField.SendKeys(email);
            GetRegisterButton.Click();
        }

        public bool IsLogOffDisplayed()
        {
            try
            {
                return _loginPage.IsLogOffDisplayed();
            }
            catch { return false; }
            
        }
    }
}
