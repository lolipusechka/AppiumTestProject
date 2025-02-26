using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using OpenQA.Selenium;

namespace DnsGui.Screens.CatalogScreens.AccessoriesAndServices
{
    public enum AccessoriesAndServicesName
    {
        Для_мобильных_устройств,
        Для_компьютеров_и_ноутбуков,
        Для_бытовой_техники
    }

    public class AccessoriesAndServicesScreen : BaseDnsScreen
    {
        protected override string Name => "Аксессуары и Услуги";
        protected override BaseElement UniqueElement => new TextView("Аксессуары и услуги", By.XPath("//*[@text=\"Аксессуары и услуги\"]"));

        private string _productGroupLocator = "//*[@resource-id=\"ru.dns.shop.android:id/title_text\" and @text=\"{0}\"]";

        public void ClickProductsGroupBtn(AccessoriesAndServicesName accessoriesAndServices)
        {
            var name = GetProductsGroupName(accessoriesAndServices);

            new Button(name, By.XPath(string.Format(_productGroupLocator, name))).ClickElement();
        }

        private string GetProductsGroupName(AccessoriesAndServicesName accessoriesAndServices)
        {
            return accessoriesAndServices.ToString().Replace("_", " ");
        }
    }
}
