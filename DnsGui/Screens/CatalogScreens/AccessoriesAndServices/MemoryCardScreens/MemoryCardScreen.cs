using AppiumTestProject.Core.Base.Elements;
using AppiumTestProject.Core.Elements;
using DnsGui.Screens.BaseScreens;
using OpenQA.Selenium;

namespace DnsGui.Screens.CatalogScreens.AccessoriesAndServices.MemoryCardScreens
{
    public class MemoryCardScreen : BaseProductsListScreen
    {
        protected override string Name => "Карты памяти";
        protected override BaseElement UniqueElement => new TextView("Карты памяти", By.XPath("//android.widget.TextView[@text=\"Карты памяти\"]"));
    }
}
