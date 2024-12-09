using AppiumFramework.Core.Base.Test;
using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Driver;
using AppiumTestProject.Core.Helpers;
using DnsGui.Screens;

namespace AutotestDnsGui.Autotests
{
    [TestFixture]
    public class FirstAppLaunchTest : BaseTest
    {
        private ChooseCityInitialScreen _chooseCityInitialScreen = new();
        private ChooseSityScreen _chooseSityScreen = new();
        private AuthInitialScreen _authInitialScreen = new();
        private HomeScreen _homeScreen = new();
        private CartScreen _cartScreen = new();
        private ProfileScreen _profileScreen = new();
        private FavoritesScreen _favoritesScreen = new();

        [TearDown]
        protected override void TearDown()
        {
            AppiumDriver.ClearApp(Properties.Testing.Default.Package);
            AppiumDriver.ClearInstance();
        }

        [Test]
        public void TestMethod([Values("Санкт-Петербург", "Красноярск", "Минусинск")] string city)
        {
            try
            {
                AppiumDriver.ActivateApp(Properties.Testing.Default.Package);

                LogHelper.Step(1, "Проверка, что на начальном экране отображается выбор города", () =>
                {
                    CheckCityOnInitialScreen("Москва");
                });

                LogHelper.Step(2, "Выбор города на начальном экране", () =>
                {
                    _chooseCityInitialScreen.ClickChangeSityBtn();

                    AlertHelper.AssertIsLoaded();
                    AlertHelper.ClickPermissionAllowForegroundOnlyButton();

                    _chooseSityScreen.AssertIsLoaded();
                    _chooseSityScreen.ChooseCity(city);

                    CheckCityOnInitialScreen(city);
                    _chooseCityInitialScreen.ClickAcceptBtn();
                });

                LogHelper.Step(3, "Проверка, что приложение запросит разрешение на отправку уведомлений", () =>
                {
                    _authInitialScreen.SkipAuthBtnClick();

                    AlertHelper.AssertIsLoaded();
                    AlertHelper.ClickPermissionAllow();
                });

                LogHelper.Step(4, $"Проверка, что на главной странице отображается выбранный город: '{city}'", () =>
                {
                    _homeScreen.AssertIsLoaded();

                    AssertHelper.AssertIsTrue(_homeScreen.GetCurrentSettlement().Equals(city, StringComparison.OrdinalIgnoreCase),
                        $"На главной странице отображается выбранный город: '{city}'");
                });

                LogHelper.Step(5, "Проверка, что в корзине нет товаров", () =>
                {
                    _homeScreen.BottomMenu.ClickCartBtn();
                    _cartScreen.AssertIsLoaded();
                    _cartScreen.AssertIsCartEmpty();
                    _cartScreen.AssertIsEmptyContentActionBtnExsist();
                });

                LogHelper.Step(6, $"Проверка, что на странице профиля отображается выбранный город: '{city}'", () =>
                {
                    _cartScreen.BottomMenu.ClickProfileBtn();
                    _profileScreen.AssertIsLoaded();
                    _profileScreen.AssertIsLoginBtnExsist();

                    AssertHelper.AssertIsTrue(_profileScreen.GetSettlement().Equals(city, StringComparison.OrdinalIgnoreCase),
                        $"На экране отображается город, подтверждённый в шаге 2 ({city})");
                });

                LogHelper.Step(7, "Проверка, что в списке избранного нет товаров", () =>
                {
                    _profileScreen.ClickFavoritesBtn();
                    _favoritesScreen.AssertIsLoaded();
                    _favoritesScreen.AssertIsFavoritesEmpty();
                    _favoritesScreen.AssertIsLoginBtnExsist();
                    _favoritesScreen.AssertIsEmptyContentActionBtnExsist();
                });

                void CheckCityOnInitialScreen(string cityName)
                {
                    _chooseCityInitialScreen.AssertIsLoaded();

                    AssertHelper.AssertIsTrue(_chooseCityInitialScreen.GetCurrentSettlement().Equals(cityName, StringComparison.OrdinalIgnoreCase),
                        $"Отображаеться ожидаемый город: '{cityName}'");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"[{ex.GetType().Name}] {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }
    }
}