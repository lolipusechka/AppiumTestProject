using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Driver;
using AppiumTestProject.Core.Elements;
using OpenQA.Selenium;

namespace AutotestDnsGui.Autotests
{
    [TestFixture]
    public class ScreenOrientationTest
    {
        private string _package = "com.google.android.calculator";
        private Button _sqrtBtn = new("Квадратный Корень", By.XPath("//android.widget.ImageButton[@resource-id=\"com.google.android.calculator:id/op_sqrt\"]"));
        private Button _sinBtn = new("Синус", By.XPath("//android.widget.ImageButton[@resource-id=\"com.google.android.calculator:id/fun_sin\"]"));

        [Test]
        public void RunTest([Values(ScreenOrientation.Portrait, ScreenOrientation.Landscape)] ScreenOrientation screenOrientation)
        {
            try
            {
                var orientationStr = $"{(screenOrientation == ScreenOrientation.Portrait ? "Портретная" : "Ландшафтная")}";

                AppiumDriver.ActivateApp(_package);

                LogHelper.Step($"Переключим ориентацию экрана на '{orientationStr}'", () =>
                {
                    AppiumDriver.SetScreenOrientation(screenOrientation);
                });

                LogHelper.Step($"Проверим, что ориентация экрана '{orientationStr}'", () =>
                {
                    AssertHelper.AssertIsTrue(AppiumDriver.GetScreenOrientation() == screenOrientation, $"Ориентация экрана соответствует ожидаемой - '{orientationStr}'");
                });

                LogHelper.Step("Проверка видимости элементов", () =>
                {
                    if (screenOrientation == ScreenOrientation.Portrait)
                    {
                        AssertHelper.AssertIsTrue(_sqrtBtn.IsElementExsist(), $"Элемент '{_sqrtBtn.Name}' присутствует на странице на странице");
                        AssertHelper.AssertIsFalse(_sinBtn.IsElementExsist(), $"Элемент '{_sinBtn.Name}' отсутствует на странице");
                    }
                    else
                    {
                        AssertHelper.AssertIsTrue(_sqrtBtn.IsElementExsist(), $"Элемент '{_sqrtBtn.Name}' присутствует на странице на странице");
                        AssertHelper.AssertIsTrue(_sinBtn.IsElementExsist(), $"Элемент '{_sinBtn.Name}' присутствует на странице на странице");
                    }
                });
            }
            catch (Exception ex)
            {
                LogHelper.Error($"[{ex.GetType().Name}] {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }
    }
}
