using AppiumTestProject.Core.Driver;
using OpenQA.Selenium.Appium.Android;

namespace AppiumFramework.Core.Base.Test
{
    public abstract class BaseTest
    {
        protected AndroidDriver driver;

        [SetUp]
        protected virtual void Setup()
        {
            driver = AppiumDriver.Instance;
            SetCustomParameters();
        }

        protected virtual void SetCustomParameters() { }

        [TearDown]
        protected virtual void TearDown()
        {
            AppiumDriver.ClearInstance();
        }
    }
}