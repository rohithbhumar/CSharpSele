using CSharpSele.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;


namespace CSharpSele.Tests
{
    public class LoginTest
    {
        private IWebDriver driver;

        [Test]
        [Category("smoke")]
        public void TestLoginPOM()
        {
            //Assemble
            var driver = new EdgeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(driver);

            //Action
            loginPage.ClickLoginLink();
            loginPage.FillUserName(usernameData: "admin1");
            //loginPage.FillUserName(usernameData: userName);
            loginPage.FillPassword(passwordData: "password");
            //loginPage.FillPassword(passwordData: passWord);
            loginPage.ClickLoginBtn();

            // Assert
            var loggOffStatus = loginPage.IsLogOffDisplayed;
            Assert.That(loggOffStatus, Is.True);

            //Assert.That(result, Is.Not.Null);
            //Assert.That(result, Is.Null);
            //Assert.That(result, Is.EqualTo(something));
            //Assert.That(result, Is.False);
            //Assert.That(result, Is.True);
        }
    }
}
