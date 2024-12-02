using AppiumTestProject.Core.Driver;

namespace AppiumTestProject.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            AppiumDriver.Instance.Quit();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}