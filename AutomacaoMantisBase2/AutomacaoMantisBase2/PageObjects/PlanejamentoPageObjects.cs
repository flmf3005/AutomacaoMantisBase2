using AutomacaoMantisBase2.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.PageObjects
{
    public class PlanejamentoPageObjects : WebDriver
    {
        public PlanejamentoPageObjects(IWebDriver driver)
        {
        }

        public IWebElement MsgNenhumPlanejamento => driver.FindElement(By.CssSelector("p.lead"));

    }
}
