using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Driver;
using AppiumTestProject.Core.Elements;
using DnsGui.Helpers;
using DnsGui.Screens.BaseScreens;
using DnsGui.Screens.Menus;
using OpenQA.Selenium;

namespace DnsGui.Screens
{
    public class CartScreen : BaseDnsScreen
    {
        private BottomMenu _bottomMenu = new();

        protected override string Name => "Экран корзины";
        protected override BaseElement UniqueElement => new TextView("Корзина", By.XPath("//*[@text=\"Корзина\"]"));

        public BottomMenu BottomMenu => _bottomMenu;

        private string _productNameLocator = "//*[@resource-id=\"ru.dns.shop.android:id/product_title_text\" and contains(@text, \"{0}\")]";

        private Button _productBtn = new("Продукт", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/product_title_text\"]"));
        private Button _emptyContentActionBtn = new("Перейти в каталог", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/empty_content_action_button\"]"));
        private Button _deleteProduct = new("Удалить продукт", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/decrement_button\"]"));
        private Button _acceptDeleteProduct = new("Подтверждение удаления", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/positive_button\"]"));

        private TextView _productSumPrice = new("Цена за продукт(ы)", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/cart_item_sum_view_current_sum_text\"]"));
        private TextView _totalSumPrice = new("Итоговая цена", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/total_sum_text\"]"));
        private TextView _snackBar = new("Товар удален", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/snackbar_text\"]"));

        public void AssertIsCartEmpty()
        {
            AssertHelper.AssertIsTrue(!(_productBtn.IsElementExsist()), "Корзина пуста");
        }

        public void AssertIsEmptyContentActionBtnExsist()
        {
            AssertHelper.AssertIsTrue(_emptyContentActionBtn.IsElementExsist(), "Кнопка 'Перейти в каталог' отображается");
        }

        public void AssertProductIsExsist(string productName)
        {
            var product = new TextView("productName", By.XPath(string.Format(_productNameLocator, productName)));

            LogHelper.Step($"Проверка, что товар '{productName}' присутствует в корзин", () =>
            {
                AssertHelper.AssertIsTrue(product.IsElementExsist(), $"Товар '{productName}' присутствует в корзине");
            });
        }

        public void AssertSumPrice(decimal sumPrice)
        {
            LogHelper.Step("Проверка, что фактическая цена за продукт(ы) совпадает с ожидаемой", () =>
            {
                AssertHelper.AssertIsTrue(CommonHelper.ParsePriceToDecimal(_productSumPrice.GetElementText()) == sumPrice,
                    $"Фактическая цена за продукт(ы) совпадает с ожидаемой");
            });
        }

        public void AssertTotalSumPrice(decimal sumPrice)
        {
            LogHelper.Step("Проверка, что итоговая цена за продукт(ы) совпадает с ожидаемой", () =>
            {
                AssertHelper.AssertIsTrue(CommonHelper.ParsePriceToDecimal(_totalSumPrice.GetElementText()) == sumPrice,
                    $"Итоговая цена за продукт(ы) совпадает с ожидаемой");
            });
        }

        public void AssertAcceptDeleteBtnExsist()
        {
            LogHelper.Step("Проверка, что отображается форма подтверждения удаления товара из корзины", () =>
            {
                AssertHelper.AssertIsTrue(_acceptDeleteProduct.IsElementExsist(), "Отображается форма подтверждения удаления товара из корзины");
            });
        }

        public void AssertSnackBarExsist()
        {
            LogHelper.Step("Проверка, что отображается снек-бар (уведомление снизу) о том, что товар удалён", () =>
            {
                AssertHelper.AssertIsTrue(AppiumDriver.Wait().Until(_ => _snackBar.IsElementExsist()) && _snackBar.GetElementText().Equals("Товар удален", StringComparison.OrdinalIgnoreCase),
                    "Отображается снек-бар (уведомление снизу) о том, что товар удалён");
            });
        }

        public void ClickDeleteProductBtn()
        {
            _deleteProduct.ClickElement();
        }

        public void ClickAcceptDeleteProductBtn()
        {
            _acceptDeleteProduct.ClickElement();
        }
    }
}
