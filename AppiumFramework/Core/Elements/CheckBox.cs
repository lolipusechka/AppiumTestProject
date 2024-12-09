using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Base.Elements;
using OpenQA.Selenium;

namespace AppiumTestProject.Core.Elements
{
    public class CheckBox(string name, By elementLocator) : BaseElement(name, elementLocator, ElementType.CheckBox)
    {
        public bool IsChecked()
        {
            LogHelper.Debug($"Получим состояние элемента: '{ElementName}'");
            return GetElement().GetAttribute("checked") == "true";
        }

        public void Check()
        {
            if (!IsChecked())
            {
                ClickElement();
            }
        }

        public void UnCheck()
        {
            if (IsChecked())
            {
                ClickElement();
            }
        }
    }
}
