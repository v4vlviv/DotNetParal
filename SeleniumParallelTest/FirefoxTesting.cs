using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumParallelTest
{
    [TestFixture]
    [Parallelizable]
    public class FirefoxTesting : TestRunner
    {
        public FirefoxTesting() : base(BrowerType.Firefox)
        {

        }

        [Test]
        public void FirefoxGoogleTest()
        {
            Driver.Navigate().GoToUrl("https://meta.ua");
            Driver.FindElement(By.Name("q")).Clear();
            Driver.FindElement(By.Name("q")).SendKeys("Selenium");
            Driver.FindElement(By.ClassName("y_button")).Click();
            Assert.That(Driver.PageSource.Contains("Selenium"), Is.EqualTo(true),
                                            "The text selenium doest not exist");
        }
    }
}
