using CSharpSele.Pages;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.Text.Json;

namespace CSharpSele.Tests
{
    public class RegisterTest
    {
        private IWebDriver driver;
        private string browser = "edge"; // Default browser

        private static IEnumerable<RegisterModel> ReadRegisisterUserJsonFile()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "register_user.json");
            var jsonList = File.ReadAllText(jsonFilePath);
            var users = JsonSerializer.Deserialize<List<RegisterModel>>(jsonList);
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
            driver.Navigate().GoToUrl("http://eaapp.somee.com/Account/Register");
            driver.Manage().Window.Maximize();
        }

        [Test]
        [TestCaseSource(nameof(ReadRegisisterUserJsonFile))]
        [Category("Reg")]
        public void TestRegisterUser(RegisterModel user)
        {
            Register regsuser = new Register(driver);
            regsuser.RegisterUser(
                userName: user.UserName,
                password: user.PassWord,
                confirmPassword: user.ConfirmPassWord,
                email: user.Email);

            bool isloggeddisplyed = regsuser.IsLogOffDisplayed();
            Assert.That(isloggeddisplyed, Is.True);

        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string testName = TestContext.CurrentContext.Test.Name;
                ScreenshotHelper.TakeScreenshot(driver, testName);
            }

            driver.Quit();
            driver.Dispose();
        }


    }
}
