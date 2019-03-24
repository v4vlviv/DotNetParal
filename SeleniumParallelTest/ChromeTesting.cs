using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumParallelTest
{

    [TestFixture]
    [Parallelizable]
    class ChromeTesting : TestRunner
    {
        public ChromeTesting() : base(BrowerType.Chrome)
        {
        }

        [Test]
        public void ChromeGoogleTest()
        {

            Driver.Navigate().GoToUrl("https://meta.ua");
            Driver.FindElement(By.Name("q")).SendKeys("ExecuteAutomation");
            Driver.FindElement(By.Name("q")).Submit();
            Assert.That(Driver.PageSource.Contains("ExecuteAutomation"), Is.EqualTo(true),
                                            "The text ExecuteAutomation doest not exist");
        }
    }
}