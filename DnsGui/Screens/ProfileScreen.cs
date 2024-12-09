using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using DnsGui.Screens.Menus;
using OpenQA.Selenium;

namespace DnsGui.Screens
{
    public class ProfileScreen : BaseDnsScreen
    {
        private BottomMenu _bottomMenu = new();

        protected override string Name => "Экран профиля пользователя";
        protected override BaseElement UniqueElement => new TextView("Профиль", By.XPath("//android.widget.TextView[@text=\"Профиль\"]"));

        public BottomMenu BottomMenu => _bottomMenu;

        private Button _loginBtn = new("Войти", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/login_button\"]"));
        private TextView _settlement = new("Местоположение", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/settlement_text\"]"));
        private Button _favoritesBtn = new("Избранное", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/button_text\" and @text=\"Избранное\"]"));

        public void AssertIsLoginBtnExsist()
        {
            LogHelper.Step("Проверка, что элемент отображаеться на странице",
                () => AssertHelper.AssertIsTrue(_loginBtn.IsElementExsist(), $"На экране присутствует кнопка '{_loginBtn.Name}'"));
        }

        public string GetSettlement()
        {
            return _settlement.GetElementText();
        }

        public void ClickFavoritesBtn()
        {
            _favoritesBtn.ClickElement();
        }
    }
}
