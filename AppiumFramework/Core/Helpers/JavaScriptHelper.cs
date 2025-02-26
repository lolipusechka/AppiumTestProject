using AppiumTestProject.Core.Driver;
using OpenQA.Selenium;

namespace AppiumFramework.Core.Helpers
{
    public static class JavaScriptHelper
    {
        public static void ClearApp(string appId)
        {
            (AppiumDriver.Instance as IJavaScriptExecutor).ExecuteScript("mobile: clearApp",
                new Dictionary<string, string> { { "appId", appId } });
        }

        public static void ScrollToElementByUiSelector(string uiSelector)
        {
            (AppiumDriver.Instance as IJavaScriptExecutor).ExecuteScript("mobile: scroll",
                new Dictionary<string, string>
                {
                    { "strategy", "-android uiautomator" },
                    { "selector", uiSelector }
                });
        }
    }
}
