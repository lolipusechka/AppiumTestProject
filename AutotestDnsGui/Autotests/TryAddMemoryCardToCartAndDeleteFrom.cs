using AppiumFramework.Core.Base.Test;
using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Driver;
using AppiumTestProject.Core.Helpers;
using DnsGui.Helpers;
using DnsGui.Screens;
using DnsGui.Screens.CatalogScreens.AccessoriesAndServices;
using DnsGui.Screens.CatalogScreens.AccessoriesAndServices.MemoryCardScreens;

namespace AutotestDnsGui.Autotests
{
    [TestFixture]
    public class TryAddMemoryCardToCartAndDeleteFrom : BaseTest
    {
        private ChooseCityInitialScreen _chooseCityInitialScreen = new();
        private AuthInitialScreen _authInitialScreen = new();

        private HomeScreen _homeScreen = new();
        private CatalogMainScreen _catalogMainScreen = new();
        private AccessoriesAndServicesScreen _accessoriesAndServicesScreen = new();
        private ForMobileDevicesScreen _forMobileDevicesScreen = new();
        private MemoryCardScreen _memoryCardScreen = new();
        private MemoryCardFilters _memoryCardFilters = new();
        private ProductScreen _productScreen = new();
        private CartScreen _cartScreen = new();

        protected override void SetCustomParameters()
        {
            AppiumDriver.TerminateApp(Properties.Testing.Default.Package);
        }

        [Test]
        public void RunTest([Values(128, 512)] int memoryCardCapacity)
        {
            try
            {
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

                LogHelper.Step(1, "Проверка, что отображается главный экран", () =>
                {
                    _homeScreen.AssertIsLoaded();
                });

                LogHelper.Step(2, "Открытие каталога", () =>
                {
                    _homeScreen.BottomMenu.ClickCatalogBtn();
                    _catalogMainScreen.AssertIsLoaded();
                });

                LogHelper.Step(3, "Перейти в меню \"Аксессуары и услуги\" -> \"Для мобильных устройств\" -> \"Карты памяти\"", () =>
                {
                    _catalogMainScreen.ChooseProductsGroup(ProductsGroupName.Аксессуары_и_услуги);

                    _accessoriesAndServicesScreen.AssertIsLoaded();
                    _accessoriesAndServicesScreen.ClickProductsGroupBtn(AccessoriesAndServicesName.Для_мобильных_устройств);

                    _forMobileDevicesScreen.AssertIsLoaded();
                    _forMobileDevicesScreen.ChooseProductsGroup(ForMobeleDeviceFilterName.Карты_памяти);

                    _memoryCardScreen.AssertIsLoaded();
                });

                LogHelper.Step(4, "Открыть фильтры", () =>
                {
                    _memoryCardScreen.ClickFiltersBtn();

                    _memoryCardFilters.AssertIsLoaded();
                });

                LogHelper.Step(5, $"Фильтровать каталог по объему в ГБ: {memoryCardCapacity}", () =>
                {
                    _memoryCardFilters.ChooseFilter(MemoryCardFilter.Объем_ГБ);
                    _memoryCardFilters.ClickCheckBox(memoryCardCapacity.ToString());
                    _memoryCardFilters.ClickAcceptBtn();

                    _memoryCardScreen.AssertIsLoaded();
                });

                var (productName, productPrice) = LogHelper.Step(6, "Зафиксировать название и цену первого товара в каталоге", () =>
                {
                    var (productBtn, currentPrice) = _memoryCardScreen.GetAllDisplayedProducts().FirstOrDefault();

                    if (productBtn is null || currentPrice is null)
                    {
                        var badMsg = "Не удалось получить товары из катлога!";
                        LogHelper.Error(badMsg);
                        throw new Exception(badMsg);
                    }

                    var name = productBtn.Text;
                    var price = CommonHelper.ParsePriceToDecimal(currentPrice.Text);

                    LogHelper.Info($"Зафиксирована информаци о товаре: Название - {name}; Цена - {price}");

                    return (name, price);
                });

                var productModelCode = LogHelper.Step(7, "Проверка названия и цены на странице товара", () =>
                {
                    _memoryCardScreen.ClickProductBtn(productName);

                    _productScreen.AssertIsLoaded();

                    _productScreen.ClickSpecificationsBtn();
                    var modelCode = _productScreen.GetModelCode();
                    var price = _productScreen.GetCurrentProductPrice();

                    AssertHelper.AssertIsTrue(productName.Contains(modelCode, StringComparison.OrdinalIgnoreCase), "Товар совпадает с ожидаемым товаром");
                    AssertHelper.AssertIsTrue(price == productPrice, "Цена товара совпадает с ожидаемым");

                    return modelCode;
                });

                LogHelper.Step(8, "Покупка товара", () =>
                {
                    _productScreen.ClickBuyBtn();
                    _productScreen.AssertProductInCart();
                    _productScreen.BottomMenu.AssertCountCartNotification(1);
                });

                LogHelper.Step(9, "Проверка товара в корзине", () =>
                {
                    _productScreen.BottomMenu.ClickCartBtn();
                    _cartScreen.AssertIsLoaded();
                    _cartScreen.AssertProductIsExsist(productModelCode);
                    _cartScreen.AssertSumPrice(productPrice);
                    _cartScreen.AssertTotalSumPrice(productPrice);
                });

                LogHelper.Step(10, "Удаление товара из корзины", () =>
                {
                    _cartScreen.ClickDeleteProductBtn();
                    _cartScreen.AssertAcceptDeleteBtnExsist();
                    _cartScreen.ClickAcceptDeleteProductBtn();
                    _cartScreen.AssertSnackBarExsist();
                    _cartScreen.AssertIsCartEmpty();
                    _cartScreen.AssertIsEmptyContentActionBtnExsist();
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
