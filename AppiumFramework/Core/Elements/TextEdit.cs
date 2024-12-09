using AppiumFramework.Core.Helpers;
using AppiumTestProject.Core.Base.Elements;
using OpenQA.Selenium;

namespace AppiumTestProject.Core.Elements
{
    public class TextEdit(string name, By elementLocator) : BaseElement(name, elementLocator, ElementType.TextEdit)
    {
        public void SendKeys(string text)
        {
            LogHelper.Step($"Запишем текст: '{text}' элементу: '{ElementName}'", () => GetElement().SendKeys(text));
        }
    }
}
