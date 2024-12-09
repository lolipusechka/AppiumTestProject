using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using OpenQA.Selenium;

namespace DnsGui.Screens.BaseScreens
{
    public enum BaseFilters
    {
        Группировка,
        Наличие_в_магазинах,
        Рейтинг,
        Цена,
        Производитель
    }

    public abstract class BaseFiltersScreen : BaseDnsScreen
    {
        protected override string Name => "Фильтры";
        protected override BaseElement UniqueElement => new TextView("Фильтры", By.XPath("//*[@text=\"Фильтры\"]"));

        protected string _filterLocator = "//androidx.cardview.widget.CardView/*[@resource-id=\"ru.dns.shop.android:id/title_text\" and @text=\"{0}\"]";
        protected string _filterUiSelector = "new UiSelector().text(\"{0}\")";

        private Button _acceptBtn = new("", By.XPath("//*[@resource-id=\"ru.dns.shop.android:id/apply_button\"]"));

        public void ChooseFilter(BaseFilters filter)
        {
            JavaScriptHelper.ScrollToElementByUiSelector(string.Format(_filterUiSelector, GetFilterName(filter)));

            ClickFilterBtn(filter);
        }

        public void ClickFilterBtn(BaseFilters filter)
        {
            var name = GetFilterName(filter);

            new Button(name, By.XPath(string.Format(_filterLocator, name))).ClickElement();
        }

        public void ClickAcceptBtn()
        {
            _acceptBtn.ClickElement();
        }

        private string GetFilterName(BaseFilters filter)
        {
            return filter.ToString().Replace("_", " ");
        }
    }
}
