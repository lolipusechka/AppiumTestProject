using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using DnsGui.Screens.Menus;
using OpenQA.Selenium;

namespace DnsGui.Screens
{
    public class HomeScreen : BaseDnsScreen
    {
        private BottomMenu _bottomMenu = new();

        protected override string Name => "Домашний экран приложения";
        protected override BaseElement UniqueElement => new TextView("Скидки и акции", By.XPath("//*[@text=\"Скидки и акции\"]"));

        public BottomMenu BottomMenu => _bottomMenu;

        private Button _changeCurrentSettlementBtn = new("Изменить текущее местоположение", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/change_current_settlement_button\"]"));

        public string GetCurrentSettlement()
        {
            return _changeCurrentSettlementBtn.GetElementText();
        }

        public BottomMenu GetBottomMenu()
        {
            return BottomMenu;
        }
    }
}