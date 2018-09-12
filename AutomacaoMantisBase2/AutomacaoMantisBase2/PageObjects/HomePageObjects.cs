using AutomacaoMantisBase2.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.PageObjects
{
    public class HomePageObjects : WebDriver
    {
        public HomePageObjects(IWebDriver driver)
        {
        }

        public IWebElement FldEntrar => driver.FindElement(By.XPath("//div[@id='login-box']/div/div/h4"));

        public IWebElement LstProjetos => driver.FindElement(By.XPath("//li[@id='dropdown_projects_menu']/a/i"));

        public IWebElement MenuGerenciar => driver.FindElement(By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/manage_overview_page.php']/i"));

        public IWebElement TitInformacao => driver.FindElement(By.CssSelector("h4.widget-title.lighter"));

        public IWebElement FldProcurarProjeto => driver.FindElement(By.XPath("//div[@id='projects-list']//input[@placeholder='Procurar']"));

        public void clicarBtnListaProjetos()
        {
            Uteis.Uteis.esperaElemento(LstProjetos, "Lista Projetos");

            Uteis.Uteis.clicarBtn(LstProjetos);

            Assert.AreEqual("Procurar", FldProcurarProjeto.GetAttribute("placeholder"));
        }
    }
}
