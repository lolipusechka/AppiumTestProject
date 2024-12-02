using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

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
                        var options = new AppiumOptions();
                        options.AutomationName = AutomationName.AndroidUIAutomator2;
                        options.AddAdditionalAppiumOption(MobileCapabilityType.PlatformName, "Android");

                        var uri = new Uri("http://localhost:4723/");

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
    }
}