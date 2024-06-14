using OpenQA.Selenium;

namespace CSharpSele.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly string loginLinkL = "loginLink";
        private readonly string userNameL = "UserName";
        private readonly string passWordL = "Password";
        private readonly string loginButtonL = "btn-default";

        //private readonly string usernamedata = "admin";
        //private readonly string passworddata = "password";  

        public LoginPage(IWebDriver adriver)
        {
            driver = adriver;
        }

        // Method to return the login link element
        public IWebElement GetGetLoginLink()
        {
            return driver.FindElement(By.Id(loginLinkL));
        }

        public void ClickLoginLink()
        {
            driver.FindElement(By.Id(loginLinkL)).Click();

        }

        public IWebElement GetUserNameE()
        {
            IWebElement userNameE = driver.FindElement(By.Id(userNameL));
            return userNameE;

        }

        public IWebElement GetPassWordE()
        {
            IWebElement passwordE = driver.FindElement(By.Id(passWordL));
            return passwordE;
        }

        public void FillUserName(string usernameData)
        {
            GetUserNameE().SendKeys(usernameData);
        }

        public void FillPassword(string passwordData)
        {
            GetPassWordE().SendKeys(passwordData);
        }


        public IWebElement GetLoginButtonE => driver.FindElement(By.ClassName(loginButtonL)); // default property is private

        public void ClickLoginBtn()
        {
            GetLoginButtonE.Click();
        }

        public bool IsLogOffDisplayed()
        {
            try
            {
              return driver.FindElement(By.LinkText("Log off")).Displayed; // is log-off button displayed
            }
            catch (NoSuchElementException) { return false; }

        }

    }

}
