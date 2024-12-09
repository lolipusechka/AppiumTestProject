using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using OpenQA.Selenium;

namespace DnsGui.Screens.CatalogScreens.AccessoriesAndServices.MemoryCardScreens
{
    public enum MemoryCardFilter
    {
        Тип_Карты,
        Объем_ГБ,
        Класс_скорости
    }

    public enum MemoryCardFilterCheckBox
    {
        ГБ_128 = 128,
        ГБ_256 = 256,
        ГБ_512 = 512,
    }

    public class MemoryCardFilters : BaseFiltersScreen
    {
        private string _checkBoxLocator = "//android.widget.CheckBox[@resource-id=\"ru.dns.shop.android:id/check\" and contains(@text, \"{0}\")]";

        public void ChooseFilter(MemoryCardFilter filter)
        {
            JavaScriptHelper.ScrollToElementByUiSelector(string.Format(_filterUiSelector, GetFilterName(filter)));

            ClickFilterBtn(filter);
        }

        public void ClickFilterBtn(MemoryCardFilter filter)
        {
            var name = GetFilterName(filter);

            new Button(name, By.XPath(string.Format(_filterLocator, name))).ClickElement();
        }

        public void ClickCheckBox(MemoryCardFilterCheckBox filter)
        {
            var name = GetCheckBoxName(filter);

            new CheckBox(name, By.XPath(string.Format(_checkBoxLocator, name))).Check();
        }

        public void ClickCheckBox(string memoryCardCapacity)
        {
            var name = GetCheckBoxName(memoryCardCapacity);

            new CheckBox(name, By.XPath(string.Format(_checkBoxLocator, name))).Check();
        }

        private string GetFilterName(MemoryCardFilter filter)
        {
            return filter switch
            {
                MemoryCardFilter.Объем_ГБ => filter.ToString().Replace("_ГБ", " (ГБ)"),
                _ => filter.ToString().Replace("_", " "),
            };
        }

        private string GetCheckBoxName(MemoryCardFilterCheckBox filter)
        {
            return filter switch
            {
                MemoryCardFilterCheckBox.ГБ_128 => $"{filter} ГБ",
                MemoryCardFilterCheckBox.ГБ_256 => $"{filter} ГБ",
                MemoryCardFilterCheckBox.ГБ_512 => $"{filter} ГБ",
                _ => filter.ToString().Replace("_", " ")
            };
        }

        private string GetCheckBoxName(string memoryCardCapacity)
        {
            return $"{memoryCardCapacity} ГБ";
        }
    }
}