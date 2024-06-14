using OpenQA.Selenium;

public static class ScreenshotHelper
{
    public static void TakeScreenshot(IWebDriver driver, string testName)
    {
        try
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
            Directory.CreateDirectory(screenshotsDirectory);
            string filePath = Path.Combine(screenshotsDirectory, $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while taking screenshot: {ex.Message}");
        }
    }
}
