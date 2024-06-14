using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;

public static class ScreenshotHelper
{
    public static void TakeScreenshot(IWebDriver driver, string testName)
    {
        try
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");

            // Debug statement to check the path
            Console.WriteLine($"Screenshots directory: {screenshotsDirectory}");

            // Create directory if it doesn't exist
            Directory.CreateDirectory(screenshotsDirectory);

            // Debug statement to check if the directory exists
            if (Directory.Exists(screenshotsDirectory))
            {
                Console.WriteLine("Screenshots directory created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create screenshots directory.");
            }

            string filePath = Path.Combine(screenshotsDirectory, $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

            // Debug statement to check the file path
            Console.WriteLine($"Screenshot file path: {filePath}");

            screenshot.SaveAsFile(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while taking screenshot: {ex.Message}");
        }
    }
}
