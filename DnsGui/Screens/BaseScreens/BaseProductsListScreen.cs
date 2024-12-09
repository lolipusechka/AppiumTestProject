using AppiumTestProject.Core.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace DnsGui.Screens.BaseScreens
{
    public abstract class BaseProductsListScreen : BaseDnsScreen
    {
        protected Button _sortingBtn = new("Сортировка", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/filter_button\"]"));
        protected Button _filtersBtn = new("Фильтры", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/filter_button\"]"));

        protected string _productCardLocator = "//android.widget.TextView[@resource-id=\"ru.dns.shop.android:id/product_title_text\"]";
        protected string _productCardNameLocator = "//android.widget.TextView[@resource-id=\"ru.dns.shop.android:id/product_title_text\" and @text=\"{0}\"]";

        protected TextView _curentPriceText = new("Цена", By.XPath("//android.widget.TextView[@resource-id=\"ru.dns.shop.android:id/current_price_text\"]"));

        public void ClickSortingBtn()
        {
            _sortingBtn.ClickElement();
        }

        public void ClickFiltersBtn()
        {
            _filtersBtn.ClickElement();
        }

        public void ClickProductBtn(string productName)
        {
            var locator = string.Format(_productCardNameLocator, productName);
            new Button(productName, By.XPath(locator)).ClickElement();
        }

        public IEnumerable<(AppiumElement ProductBtn, AppiumElement CurrentPrice)> GetAllDisplayedProducts()
        {
            var products = new Button("Продукт", By.XPath(string.Format(_productCardLocator, string.Empty))).GetElements();
            var prices = _curentPriceText.GetElements();

            return products.Zip(prices, (product, price) => (product, price));
        }
    }
}
