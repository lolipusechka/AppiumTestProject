using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Driver;
using AppiumTestProject.Core.Helpers;
using DnsGui.Screens;

namespace AutotestDnsGui.Autotests
{
    [TestFixture]
    public class AirPlaneTest
    {
        private ChooseCityInitialScreen _chooseCityInitialScreen = new();
        private AuthInitialScreen _authInitialScreen = new();

        private NoInternetErrorScreen _noInternetErrorScreen = new();

        [Test]
        public void RunTest()
        {
            try
            {
                LogHelper.Step("Переключение \"Режим полета\"", () =>
                {
                    AppiumDriver.ToggleAirplaneMode();
                });

                LogHelper.Step("[PREPARE] Запуск приложения и прокликование начальных экранов", () =>
                {
                    AppiumDriver.ActivateApp(Properties.Testing.Default.Package);

                    if (_chooseCityInitialScreen.IsScreenExsist())
                    {
                        _chooseCityInitialScreen.ClickAcceptBtn();

                        _authInitialScreen.AssertIsLoaded();
                        _authInitialScreen.SkipAuthBtnClick();

                        AlertHelper.AssertIsLoaded();
                        AlertHelper.ClickPermissionAllow();
                    }
                    else
                    {
                        LogHelper.Info("Начальная страница не отображается на экране. Дополнительные действия не требуются.");
                    }
                });

                LogHelper.Step("Проверка, что отображается экран c ошибкой", () =>
                {
                    _noInternetErrorScreen.AssertIsLoaded();
                });
            }
            catch (Exception ex)
            {
                LogHelper.Error($"[{ex.GetType().Name}] {ex.Message}\n{ex.StackTrace}");
                throw;
            }
            finally
            {
                LogHelper.Step("Переключение \"Режим полета\"", () =>
                {
                    AppiumDriver.ToggleAirplaneMode();
                });
            }
        }
    }
}
