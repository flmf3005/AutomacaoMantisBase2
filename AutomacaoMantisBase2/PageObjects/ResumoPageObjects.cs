using AutomacaoMantisBase2.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.PageObjects
{
    public class ResumoPageObjects : WebDriver
    {
        public ResumoPageObjects(IWebDriver driver)
        {
        }

        public IWebElement DivResumo => driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/ul/li/a"));

    }
}
