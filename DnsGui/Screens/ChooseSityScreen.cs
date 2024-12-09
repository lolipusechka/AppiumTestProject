using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Driver;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using OpenQA.Selenium;

namespace DnsGui.Screens
{
    public class ChooseSityScreen : BaseDnsScreen
    {
        protected override string Name => "Экран выбора города";
        protected override BaseElement UniqueElement => new Button("Определить автоматически", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/location_button\"]"));

        private string _cityBtnLocator = "//*[@resource-id=\"ru.dns.shop.android:id/settlement_name_text\" and @text=\"{0}\"]";

        private TextEdit _citySearchBar = new("Найти город", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/search_edit\"]"));

        public void CityBtnClick(string cityName)
        {
            new Button($"Город '{cityName}'", By.XPath(string.Format(_cityBtnLocator, cityName))).ClickElement();
        }

        public void FindCityBySearch(string cityName)
        {
            _citySearchBar.SendKeys(cityName);
        }

        public void ChooseCity(string cityName)
        {
            LogHelper.Step($"Выберем город: {cityName}", () =>
            {
                var cityBtn = new Button($"Город '{cityName}'", By.XPath(string.Format(_cityBtnLocator, cityName)));

                if (cityBtn.IsElementExsist())
                {
                    cityBtn.ClickElement();
                }
                else
                {
                    FindCityBySearch(cityName);
                    var isExsist = AppiumDriver.Wait().Until(_ => cityBtn.IsElementExsist());
                    cityBtn.ClickElement();
                }
            });
        }
    }
}