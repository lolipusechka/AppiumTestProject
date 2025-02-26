using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using OpenQA.Selenium;

namespace DnsGui.Screens
{
    public class ChooseCityInitialScreen : BaseDnsScreen
    {
        protected override string Name => "Начальный экран выбора города";
        protected override BaseElement UniqueElement => new Button("Все верно", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/confirm_current_settlement_button\"]"));

        private TextView _currentSettlement = new("Текущий город", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/current_settlement_text\"]"));
        private Button _changeSity = new("Сменить город", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/change_current_settlement_button\"]"));

        public string GetCurrentSettlement()
        {
            return _currentSettlement.GetElementText().Replace("?", "");
        }

        public void ClickAcceptBtn()
        {
            UniqueElement.ClickElement();
        }

        public void ClickChangeSityBtn()
        {
            _changeSity.ClickElement();
        }
    }
}