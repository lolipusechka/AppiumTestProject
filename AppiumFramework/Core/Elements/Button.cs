using AppiumTestProject.Core.Base.Elements;
using OpenQA.Selenium;

namespace AppiumTestProject.Core.Elements
{
    public class Button(string name, By elementLocator) : BaseElement(name, elementLocator, ElementType.Button) { }
}
