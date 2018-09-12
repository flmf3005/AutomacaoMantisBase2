using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.Drivers
{
    public class WebDriver
    {
        //variável global referente ao driver (navegador)
        public static IWebDriver driver { get; set; }

        //decoração simbolizando método que executa antes de iniciar o teste
        [SetUp]
        public void SetUp()
        {
            //ChromeDriver: nativo do selenium, usar path para o driver
            //Criei um método que retorna o path do driver: SeleniumUteis.SeleniumUteis.getPathSeleniumDriver
            driver = new ChromeDriver(Uteis.Uteis.getPathSeleniumDriver());



            //Ação que navega para o site
            driver.Navigate().GoToUrl("http://mantis.fernando.base2.com.br");

            //Ação que maximiza a tela
            driver.Manage().Window.Maximize();
        }

        //decoração simbolizando método que serpa executado depois que o teste finalizar
        [TearDown]
        public void TearDown()
        {
            //Método que fecha o driver
            driver.Quit();
        }
    }
}
