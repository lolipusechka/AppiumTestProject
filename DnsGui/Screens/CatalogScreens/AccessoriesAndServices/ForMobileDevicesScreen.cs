using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using OpenQA.Selenium;

namespace DnsGui.Screens.CatalogScreens.AccessoriesAndServices
{
    public enum ForMobeleDeviceFilterName
    {
        Наушники_и_гарнитуры,
        OTG_Аксессуары,
        Карты_памяти
    }

    public class ForMobileDevicesScreen : BaseDnsScreen
    {
        protected override string Name => "Для мобильных устройств";
        protected override BaseElement UniqueElement => new TextView("", By.XPath("//*[@text=\"Для мобильных устройств\"]"));

        private string _productGroupLocator = "//*[@resource-id=\"ru.dns.shop.android:id/title_text\" and @text=\"{0}\"]";
        private string _productGroupUiSelector = "new UiSelector().text(\"{0}\")";

        public void ChooseProductsGroup(ForMobeleDeviceFilterName forMobeleDeviceFilterName)
        {
            JavaScriptHelper.ScrollToElementByUiSelector(string.Format(_productGroupUiSelector, GetProductName(forMobeleDeviceFilterName)));

            ClickProductGroupBtn(forMobeleDeviceFilterName);
        }

        public void ClickProductGroupBtn(ForMobeleDeviceFilterName forMobeleDeviceFilterName)
        {
            var name = GetProductName(forMobeleDeviceFilterName);

            new Button(name, By.XPath(string.Format(_productGroupLocator, name))).ClickElement();
        }

        private string GetProductName(ForMobeleDeviceFilterName forMobeleDeviceFilterName)
        {
            return forMobeleDeviceFilterName.ToString().Replace("_", " ");
        }
    }
}
