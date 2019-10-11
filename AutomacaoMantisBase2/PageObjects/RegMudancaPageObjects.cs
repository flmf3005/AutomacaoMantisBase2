using AutomacaoMantisBase2.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.PageObjects
{
    public class RegMudancaPageObjects : WebDriver
    {
        public RegMudancaPageObjects(IWebDriver driver)
        {
        }

        public By MsgNenhumRegistro => By.CssSelector("p.lead");

    }
}
