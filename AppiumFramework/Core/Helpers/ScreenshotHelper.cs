using AppiumTestProject.Core.Driver;

namespace AppiumFramework.Core.Helpers
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(string fileName)
        {
            var screenshot = AppiumDriver.GetScreenshot();

            var p = Path.Combine(Environment.CurrentDirectory + $@"\logs\{fileName}{DateTime.Now.Ticks}.png");

            screenshot.SaveAsFile(p);
        }
    }
}
