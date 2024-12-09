using AppiumFramework.Core.Helpers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using static AppiumFramework.Properties.Driver;

namespace AppiumTestProject.Core.Driver
{
    public static class AppiumDriver
    {
        private static AndroidDriver? _instance = null;

        public static AndroidDriver? Instance
        {
            get
            {
                try
                {
                    if (_instance is null)
                    {
                        var options = new AppiumOptions
                        {
                            AutomationName = AutomationName.AndroidUIAutomator2,
                            PlatformName = "Android"
                        };

                        options.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AutoGrantPermissions, Default.AutoGrantPermissions);

                        var uri = new Uri(Default.URL);

                        _instance = new AndroidDriver(uri, options);
                    }
                }
                catch
                {
                    throw;
                }

                return _instance;
            }
        }

        public static void ClearInstance()
        {
            Instance?.Quit();
            _instance = null;
        }

        public static WebDriverWait Wait()
        {
            return new WebDriverWait(Instance, TimeSpan.FromMilliseconds(Default.TimeOut));
        }

        public static void ActivateApp(string appId)
        {
            LogHelper.Step($"Запуск приложения: {appId}", () => Instance?.ActivateApp(appId));
        }

        public static void ClearApp(string appId)
        {
            LogHelper.Step($"Очистка локальный данных приложения: {appId}", () =>
            {
                JavaScriptHelper.ClearApp(appId);
            });
        }

        public static void TerminateApp(string appId)
        {
            LogHelper.Step($"Закрытие приложения: {appId}", () =>
            {
                Instance?.TerminateApp(appId);
            });
        }
    }
}