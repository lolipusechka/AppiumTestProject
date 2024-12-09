using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using DnsGui.Helpers;
using DnsGui.Screens.BaseScreens;
using DnsGui.Screens.Menus;
using OpenQA.Selenium;

namespace DnsGui.Screens
{
    public class ProductScreen : BaseDnsScreen
    {
        private BottomMenu _bottomMenu = new();

        protected override string Name => "Страница товара";
        protected override BaseElement UniqueElement => new Button("Код товара", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/product_code_button\"]"));

        public BottomMenu BottomMenu => _bottomMenu;

        private string _contentLayoutUiSelector = "new UiSelector().resourceId(\"ru.dns.shop.android:id/content_layout\")";
        private string _specificationsUiSelector = "new UiSelector().description(\"Характеристики\")";
        private string _modelCodeUiSelector = "new UiSelector().text(\"Код производителя\")";

        private TextView _productName = new("Название товара", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/product_title_text\"]"));
        private TextView _currentProductPrice = new("Цена товара", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/current_price_text\"]"));
        private TextView _modelCode = new("Код производителя",
            By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/title_text\" and @text=\"Код производителя\"]/ancestor-or-self::android.view.ViewGroup/child::*[@resource-id=\"ru.dns.shop.android:id/value_text\"]"));

        private Button _buyProductBtn = new("Купить",
            By.XPath("//android.view.ViewGroup[@resource-id=\"ru.dns.shop.android:id/content_layout\"]//ancestor-or-self::android.widget.Button[@resource-id=\"ru.dns.shop.android:id/buy_button\"]"));
        private Button _specifications = new("Характеристики", By.XPath("//android.widget.LinearLayout[@content-desc=\"Характеристики\"]"));

        public string GetProductName()
        {
            return _productName.GetElementText();
        }

        public decimal GetCurrentProductPrice()
        {
            return CommonHelper.ParsePriceToDecimal(_currentProductPrice.GetElementText());
        }

        public void ClickBuyBtn()
        {
            JavaScriptHelper.ScrollToElementByUiSelector(_contentLayoutUiSelector);

            _buyProductBtn.ClickElement();
        }

        public void ClickSpecificationsBtn()
        {
            JavaScriptHelper.ScrollToElementByUiSelector(_specificationsUiSelector);

            _specifications.ClickElement();
        }

        public string GetModelCode()
        {
            JavaScriptHelper.ScrollToElementByUiSelector(_modelCodeUiSelector);

            return _modelCode.GetElementText();
        }

        public void AssertProductInCart()
        {
            LogHelper.Step("Проверка, что товар находится в корзине", () =>
            {
                AssertHelper.AssertIsTrue(_buyProductBtn.GetElementText().Equals("В корзине", StringComparison.OrdinalIgnoreCase),
                    $"Кнопка \"{_buyProductBtn.Name}\" отображает текст: \"В корзине\"");
            });
        }
    }
}