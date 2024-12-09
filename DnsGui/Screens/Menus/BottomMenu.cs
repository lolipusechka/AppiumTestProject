using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using OpenQA.Selenium;

namespace DnsGui.Screens.Menus
{
    public class BottomMenu : BaseDnsScreen
    {
        protected override string Name => "Нижнее меню";
        protected override BaseElement UniqueElement => new Button("Главная", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/nav_home\"]"));

        private string _cartNotificationsLocator = "//*[@resource-id=\"ru.dns.shop.android:id/nav_cart\" and contains(@content-desc, \"{0}\")]";

        private Button _outlets = new("Магазины", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/nav_outlets\"]"));
        private Button _catalog = new("Каталог", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/nav_catalog\"]"));
        private Button _cart = new("Корзина", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/nav_cart\"]"));
        private Button _profile = new("Профиль", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/nav_profile\"]"));

        public void ClickHomeBtn()
        {
            UniqueElement.ClickElement();
        }

        public void ClickOutletsBtn()
        {
            _outlets.ClickElement();
        }

        public void ClickCatalogBtn()
        {
            _catalog.ClickElement();
        }

        public void ClickCartBtn()
        {
            _cart.ClickElement();
        }

        public void ClickProfileBtn()
        {
            _profile.ClickElement();
        }

        public void AssertCountCartNotification(int count)
        {
            var btn = new Button($"Корзина, {count} новых уведомления", By.XPath(string.Format(_cartNotificationsLocator, count)));

            AssertHelper.AssertIsTrue(btn.IsElementExsist(), $"На кнопке \"Корзина\" отображается увдомления в количестве: {count}");
        }
    }
}