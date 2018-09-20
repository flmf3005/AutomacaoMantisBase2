using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;

namespace AutomacaoMantisBase2.Drivers
{
    public class WebDriver
    {
        [SetUp]
        public void Setup()
        {
            DriverFactory.CreateInstance();
            DriverFactory.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"].ToString());
        }


        [TearDown]
        public void TearDown()
        {
            DriverFactory.QuitInstace();
        }
    }
}