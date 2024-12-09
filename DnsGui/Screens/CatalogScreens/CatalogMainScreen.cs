using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using OpenQA.Selenium;

namespace DnsGui.Screens
{
    public enum ProductsGroupName
    {
        Бытовая_техника,
        Инструменты_и_стройка,
        Аксессуары_и_услуги
    }

    public class CatalogMainScreen : BaseDnsScreen
    {
        protected override string Name => "Каталог";
        protected override BaseElement UniqueElement => new TextEdit("Искать в DNS", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/search_edit\"]"));

        private string _productGroupLocator = "//*[@resource-id=\"ru.dns.shop.android:id/title_text\" and @text=\"{0}\"]";
        private string _productGroupUiSelector = "new UiSelector().text(\"{0}\")";

        public void ChooseProductsGroup(ProductsGroupName productsGroupName)
        {
            JavaScriptHelper.ScrollToElementByUiSelector(string.Format(_productGroupUiSelector, GetProductName(productsGroupName)));

            ClickProductGroupBtn(productsGroupName);
        }

        public void ClickProductGroupBtn(ProductsGroupName productsGroupName)
        {
            var productName = GetProductName(productsGroupName);

            new Button(productName, By.XPath(string.Format(_productGroupLocator, productName))).ClickElement();
        }

        private string GetProductName(ProductsGroupName productsGroupName)
        {
            return productsGroupName.ToString().Replace("_", " ");
        }
    }
}
