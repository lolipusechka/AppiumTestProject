using AppiumTestProject.Core.Base.Elements;
using OpenQA.Selenium;

namespace AppiumTestProject.Core.Elements
{
    public class TextView(string name, By elementLocator) : BaseElement(name, elementLocator, ElementType.TextView) { }
}
