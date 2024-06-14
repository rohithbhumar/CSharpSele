using CSharpSele.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CSharpSele
{
    [TestFixture("admin", "password")]
    [TestFixture("admin2", "password1")]
    [TestFixture("admin33", "password2")]
    public class Testing
    {
        private IWebDriver driver;
        private readonly string userName;
        private readonly string passWord;

        public Testing(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }
        

        [SetUp]
        public void Setup()
        {
            
            driver = new ChromeDriver();
        }

        [Test]
        public void GoogleTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            IWebElement searchBar = driver.FindElement(By.Name("q"));
            searchBar.Click();
            searchBar.SendKeys("C# with Selenium");
            searchBar.SendKeys(Keys.Enter);

        }

        [Test]
        public void EAWebTest()
        {

            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
            IWebElement loginLinkE = driver.FindElement(By.Id("loginLink"));
            loginLinkE.Click();

            IWebElement userNameE = driver.FindElement(By.Id("UserName"));
            IWebElement passwordE = driver.FindElement(By.Id("Password"));
            IWebElement loginButtonE = driver.FindElement(By.CssSelector("input.btn-default"));

            string user_name = "admin";
            string password = "password";

            userNameE.SendKeys(user_name);
            passwordE.SendKeys(password);
            loginButtonE.Click();
            //loginButtonE.Submit();


            IWebElement helloLoggedInUser = driver.FindElement(By.LinkText($"Hello {user_name}!"));
            Console.WriteLine(helloLoggedInUser.Text);

            // Assert.AreEqual($"Hello {user_name}!", helloLoggedInUser.Text);

        }

        [Test]        
        public void SeleSupportAdvanced()
        {
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();
            // Drop Down Country
            IWebElement drop_down_country = driver.FindElement(By.Id("country"));
            SelectElement selectCountryDDElement = new SelectElement(drop_down_country);
            selectCountryDDElement.SelectByText("France");
            // Assert.AreEqual("France", selectCountryDDElement.SelectedOption.Text);

            //bool is_true = ("France" == selectCountryDDElement.SelectedOption.Text);
            //if (is_true)
            //{
            //    Assert.Pass("Selected Value is correct");
            //}
            //else
            //{
            //    Assert.Fail("Selected Value is not the same");
            //}

            // MultiSelect
            IWebElement colours_multi = driver.FindElement(By.Id("colors"));
            SelectElement multiSelectColorsElement = new SelectElement(colours_multi);
            multiSelectColorsElement.SelectByValue("red");
            multiSelectColorsElement.SelectByValue("yellow");

            IList<IWebElement> selected_options = multiSelectColorsElement.AllSelectedOptions;
            foreach (var element in selected_options)
            {
                Console.WriteLine(element.Text);
            }


        }

        [Test]
        [Category("testfixturedata")]
        public void TestLoginPOM()
        {
            //var driver = new EdgeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickLoginLink();
            loginPage.FillUserName(usernameData: "admin");
            loginPage.FillUserName(usernameData: userName);
            loginPage.FillPassword(passwordData: "password");
            loginPage.FillPassword(passwordData: passWord);
            loginPage.ClickLoginBtn();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }


    }

}