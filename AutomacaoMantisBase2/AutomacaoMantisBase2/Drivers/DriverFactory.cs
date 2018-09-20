using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;

namespace AutomacaoMantisBase2.Drivers
{
    class DriverFactory
    {
        public static IWebDriver driver { get; set; } = null;

        public static void CreateInstance()
        {

            //criado um appconfig com a configuração desejada
            string navegador = ConfigurationManager.AppSettings["NavegadorDefault"].ToString();
            string nodeURL = ConfigurationManager.AppSettings["IpHub"].ToString();
            string local = ConfigurationManager.AppSettings["Local"].ToString();

            if (driver == null)
            {
                switch (local)
                {
                    case ("true"): //rodar local
                        driver = new ChromeDriver(Uteis.Uteis.getPathSeleniumDriver());
                        break;

                    case ("false"): //rodar grid
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
                        break;
                }
            }
        }

        public static void QuitInstace()
        {
            driver.Quit();
            driver = null;
        }
    }
}
