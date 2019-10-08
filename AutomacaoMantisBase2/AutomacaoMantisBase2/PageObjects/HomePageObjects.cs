using AutomacaoMantisBase2.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public IWebElement MenuMyView => driver.FindElement(By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/my_view_page.php']/i"));
        public IWebElement MenuVerTarefas => driver.FindElement(By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/view_all_bug_page.php']/i"));
        public IWebElement MenuCriarTarefas => driver.FindElement(By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/bug_report_page.php']/i"));
        public IWebElement MenuRegistroMudancas => driver.FindElement(By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/changelog_page.php']/i"));
        public IWebElement MenuPlanejamento => driver.FindElement(By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/roadmap_page.php']/i"));
        public IWebElement MenuResumo => driver.FindElement(By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/summary_page.php']/i"));
        public IWebElement MenuGerenciar => driver.FindElement(By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/manage_overview_page.php']/i"));
        public IWebElement TitInformacao => driver.FindElement(By.CssSelector("h4.widget-title.lighter"));
        public IWebElement FldProcurarProjeto => driver.FindElement(By.XPath("//div[@id='projects-list']//input[@placeholder='Procurar']"));
        public IWebElement LnkProjeto => driver.FindElement(By.LinkText(ConfigurationManager.AppSettings["projeto".ToString()]));
        public IWebElement LnkCriarTarefa => driver.FindElement(By.LinkText("Criar Tarefa"));
        public IWebElement BtnUserInfo => driver.FindElement(By.CssSelector("span.user-info"));
        public IWebElement LnkMinhaConta => driver.FindElement(By.LinkText("Minha Conta"));
        public IWebElement LnkPreferencias => driver.FindElement(By.LinkText("Preferências"));
        public IWebElement LnkGerenciarColunas => driver.FindElement(By.LinkText("Gerenciar Colunas"));
        public IWebElement LnkPerfis => driver.FindElement(By.LinkText("Perfís"));
        public IWebElement LnkTokensAPI => driver.FindElement(By.LinkText("Tokens API"));

        public void clicarBtnListaProjetos()
        {
            Uteis.Uteis.WaitForElement(LstProjetos);
            Uteis.Uteis.Click(LstProjetos);
            Assert.AreEqual("Procurar", FldProcurarProjeto.GetAttribute("placeholder"));
        }

        public void selecionarProjetoPadrao()
        {
            Uteis.Uteis.WaitForElement(LnkProjeto);
            Uteis.Uteis.Click(LnkProjeto);
        }
    }
}
