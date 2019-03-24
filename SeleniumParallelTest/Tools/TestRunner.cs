using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumParallelTest
{
    //Enum for browserType
    public enum BrowerType
    {
        Chrome,
        Firefox,
        IE,
        Opera
    }

    //Fixture for class
    [TestFixture]
    public class TestRunner 
    {
        private BrowerType _browserType;
        protected IWebDriver Driver { get; set; }

        public TestRunner(BrowerType browser)
        {
            _browserType = browser;
        }

        [SetUp]
        public void SetUp()
        {
            ChooseDriverInstance(_browserType);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        private void ChooseDriverInstance(BrowerType browserType)
        {

            switch (browserType)
            {
                case BrowerType.Chrome:
                    {
                        SetBrowserAndServer(DesiredCapabilities.Chrome());
                        break;
                    }   
                case BrowerType.Firefox:
                    {
                        SetBrowserAndServer(DesiredCapabilities.Firefox());
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong option");
                        break;
                    }
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }

        private void SetBrowserAndServer(DesiredCapabilities capabilities)
        {
            capabilities.SetCapability("version", "");
            capabilities.SetCapability("platform", "LINUX");
            Driver = new RemoteWebDriver(new Uri("http://192.168.56.1/wd/hub"), capabilities);
        }
    }
}
