using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using OpenQA.Selenium;

namespace DnsGui.Screens
{
    public class NoInternetErrorScreen : BaseDnsScreen
    {
        protected override string Name => "Страница ошибки \"Нет интернета\"";
        protected override BaseElement UniqueElement => new TextView("", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/error_details_text\" and contains(@text, \"Проверьте интернет\")]"));
    }
}
