using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using DnsGui.Screens.Menus;
using OpenQA.Selenium;

namespace DnsGui.Screens
{
    public class FavoritesScreen : BaseDnsScreen
    {
        private BottomMenu _bottomMenu = new();

        protected override string Name => "Избранное";
        protected override BaseElement UniqueElement => new TextView("", By.XPath("//*[@text=\"Избранное\"]"));

        public BottomMenu BottomMenu => _bottomMenu;

        private string _productTitleLocator = "//*[@resource-id=\"ru.dns.shop.android:id/product_title_text\"{0}]";

        private Button _loginBtn = new("Войти", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/login_button\"]"));
        private Button _emptyContentActionBtn = new("Перейти в каталог", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/empty_content_action_button\"]"));

        public void AssertIsFavoritesEmpty()
        {
            LogHelper.Step("Проверка, список избранного пуст",
                () => AssertHelper.AssertIsTrue(!(new TextView("Название товара",
                    By.XPath(string.Format(_productTitleLocator, string.Empty))).IsElementExsist()), "Список избранного пуст"));
        }

        public void AssertIsLoginBtnExsist()
        {
            LogHelper.Step("Проверка, что элемент отображаеться на странице",
                () => AssertHelper.AssertIsTrue(_loginBtn.IsElementExsist(), $"На экране присутствует кнопка '{_loginBtn.Name}'"));
        }

        public void AssertIsEmptyContentActionBtnExsist()
        {
            LogHelper.Step("Проверка, что элемент отображаеться на странице",
                () => AssertHelper.AssertIsTrue(_emptyContentActionBtn.IsElementExsist(), $"На экране присутствует кнопка '{_emptyContentActionBtn.Name}'"));
        }
    }
}