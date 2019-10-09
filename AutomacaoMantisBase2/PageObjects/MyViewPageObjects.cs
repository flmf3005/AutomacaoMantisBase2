using AutomacaoMantisBase2.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.PageObjects
{
    public class MyViewPageObjects : WebDriver
    {
        public MyViewPageObjects(IWebDriver driver)
        {
        }

        public IWebElement LnkAtrbuidosAMim => driver.FindElement(By.LinkText("Atribuídos a Mim (não resolvidos)"));
        
    }
}
