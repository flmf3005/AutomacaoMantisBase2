using AutomacaoMantisBase2.Uteis;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;

namespace AutomacaoMantisBase2.Drivers
{
    public class WebDriver
    {
        public static IWebDriver driver { get; set; } = null;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Relatorio.CreateReport();
        }

        [SetUp]
        public void SetUp()
        {
            Relatorio.AddTest();
            AbrirInstancia();
        }

        [TearDown]
        public void TearDown()
        {
            Relatorio.AddTestResult();
            driver.Quit();
            driver = null;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Relatorio.GenerateReport();
        }

        public void AbrirInstancia()
        {
            string navegador = ConfigurationManager.AppSettings["NavegadorDefault"].ToString();
            string nodeURL = ConfigurationManager.AppSettings["IpHub"].ToString();
            string local = ConfigurationManager.AppSettings["Local"].ToString();

            if (driver == null)
            {
                if (local.Equals("true"))
                {
                    ChromeOptions chrome = new ChromeOptions();
                    chrome.AddArgument("enable-automation");
                    chrome.AddArgument("--no-sandbox");
                    chrome.AddArgument("--disable-infobars");
                    chrome.AddArgument("--disable-dev-shm-usage");
                    chrome.AddArgument("--disable-browser-side-navigation");
                    chrome.AddArgument("--disable-gpu");
                    chrome.AddArgument("--window-size=1366,768");
                    chrome.PageLoadStrategy = PageLoadStrategy.Normal;
                    driver = new ChromeDriver(chrome);
                }
                else { 
                    switch (navegador)
                    {
                        case ("firefox"):
                            FirefoxOptions firefox = new FirefoxOptions();
                            driver = new RemoteWebDriver(new Uri(nodeURL), firefox.ToCapabilities());
                            driver.Manage().Window.Maximize();
                            break;

                        case ("chrome"):
                            ChromeOptions chrome = new ChromeOptions();
                            driver = new RemoteWebDriver(new Uri(nodeURL), chrome.ToCapabilities());
                            driver.Manage().Window.Maximize();
                            break;

                        case ("opera"):
                            OperaOptions opera = new OperaOptions();
                            opera.BinaryLocation = "@" + ConfigurationManager.AppSettings["PatchOperaExe"].ToString(); ;
                            driver = new RemoteWebDriver(new Uri(nodeURL), opera.ToCapabilities());
                            driver.Manage().Window.Maximize();
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                        
                }
                driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"].ToString());
            }
        }
    }
}