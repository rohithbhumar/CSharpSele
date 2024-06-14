using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

public static class DriverFactory
{    
    public static IWebDriver CreateDriver(string browser)
    {
        IWebDriver driver;
        switch (browser.ToLower())
        {
            case "chrome":
                driver = new ChromeDriver();
                break;
            case "firefox":
                driver = new FirefoxDriver();
                break;
            case "edge":
                driver = new EdgeDriver();
                break;
            default:
                throw new ArgumentException($"Browser '{browser}' is not supported.");
        }
        return driver;
    }
}
