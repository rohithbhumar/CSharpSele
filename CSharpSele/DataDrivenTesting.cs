using CSharpSele.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

namespace CSharpSele
{
    //[Parallelizable(ParallelScope.All)]
    public class DataDrivenTesting
    {
        private IWebDriver driver;
        private string browser = "edge"; // Default browser

        private static IEnumerable<User> ReadJsonFile()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonList = File.ReadAllText(jsonFilePath);
            var users = JsonSerializer.Deserialize<List<User>>(jsonList);
            foreach (var user in users)
            {
                //Console.WriteLine(user.UserName);
                //Console.WriteLine(user.PassWord);
                yield return user;
            }

        }

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateDriver(browser);
        }


        [Test]
        [TestCaseSource(nameof(ReadJsonFile))]
        [Category("DataDT")]
        public void TestDDTPOM(User user)
        {
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickLoginLink();
            loginPage.FillUserName(usernameData: user.UserName);
            loginPage.FillPassword(passwordData: user.PassWord);
            loginPage.ClickLoginBtn();

            // Assert
            bool logOffStatus = loginPage.IsLogOffDisplayed();
            //Assert.That(loggOffStatus, Is.True);
            if (user.IsValid)
            {
                Assert.That(logOffStatus, Is.True, "Log off button should be displayed for valid credentials.");
            }
            else // or I could add a if else condition to check if (!user.IsValid) then find the locator for 'invalid user/pass' and Assert
            {
                Assert.That(logOffStatus, Is.False, "Log off button should be not displayed for invalid creds");                
            }

        }

       

        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
