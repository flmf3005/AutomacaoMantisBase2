using AutomacaoMantisBase2.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.PageObjects
{
    public class VerTarefasPageObjects : WebDriver
    {
        public VerTarefasPageObjects(IWebDriver driver)
        {
        }

        public IWebElement DivFiltros => driver.FindElement(By.XPath("//div[@id='filter']/div/h4"));

    }
}
