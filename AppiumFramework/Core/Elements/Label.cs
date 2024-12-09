using AppiumTestProject.Core.Base.Elements;
using OpenQA.Selenium;

namespace AppiumTestProject.Core.Elements
{
    public class Label(string name, By elementLocator) : BaseElement(name, elementLocator, ElementType.Label) { }
}
