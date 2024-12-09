using AppiumFramework.Core.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using AppiumDriver = AppiumTestProject.Core.Driver.AppiumDriver;

namespace AppiumTestProject.Core.Base.Elements
{
    public enum ElementType
    {
        Button,
        CheckBox,
        Label,
        TextView,
        TextEdit
    }

    public abstract class BaseElement(string name, By elementLocator, ElementType elementType)
    {
        public string Name { get; } = name;
        public ElementType ElementType { get; } = elementType;
        public By ElementLocator { get; } = elementLocator;
        public string ElementName => $"{Name}({ElementType})";
        public string FullElementInfo => $"{Name}({ElementType})[{ElementLocator}]";

        public AppiumElement GetElement()
        {
            try
            {
                LogHelper.Debug($"Получение элемента: '{FullElementInfo}'");

                AppiumDriver.Wait().Until(_ => GetElements());

                return AppiumDriver.Instance.FindElement(ElementLocator);
            }
            catch (Exception ex)
            {
                LogHelper.Error($"{ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        public IEnumerable<AppiumElement> GetElements()
        {
            return AppiumDriver.Instance.FindElements(ElementLocator);
        }

        public bool IsElementExsist()
        {
            return AppiumDriver.Instance.FindElements(ElementLocator).Count() > 0;
        }

        public void ClickElement()
        {
            LogHelper.Step($"Клик по элементу: '{ElementName}'", () => GetElement().Click());
        }

        public string GetElementText()
        {
            return LogHelper.Step($"Получение текста у элемента: '{ElementName}'", () =>
            {
                var txt = GetElement().Text;
                LogHelper.Debug($"Полученный текст: {txt}");
                return txt;
            });
        }
    }
}
