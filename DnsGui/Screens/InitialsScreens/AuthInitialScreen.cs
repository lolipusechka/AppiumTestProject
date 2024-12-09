using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using OpenQA.Selenium;

namespace DnsGui.Screens
{
    public class AuthInitialScreen : BaseDnsScreen
    {
        protected override string Name => "Начальный экран авторизации";
        protected override BaseElement UniqueElement => new Button("Войти позже", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/skip_auth_button\"]"));

        public void SkipAuthBtnClick()
        {
            UniqueElement.ClickElement();
        }
    }
}
