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

        public By FldEntrar => By.XPath("//div[@id='login-box']/div/div/h4");
        public By LstProjetos => By.XPath("//li[@id='dropdown_projects_menu']/a/i");
        public By MenuMyView => By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/my_view_page.php']/i");
        public By MenuVerTarefas => By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/view_all_bug_page.php']/i");
        public By MenuCriarTarefas => By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/bug_report_page.php']/i");
        public By MenuRegistroMudancas => By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/changelog_page.php']/i");
        public By MenuPlanejamento => By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/roadmap_page.php']/i");
        public By MenuResumo => By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/summary_page.php']/i");
        public By MenuGerenciar => By.XPath("//div[@id='sidebar']/ul[@class='nav nav-list']//a[@href='/manage_overview_page.php']/i");
        public By TitInformacao => By.CssSelector("h4.widget-title.lighter");
        public By FldProcurarProjeto => By.XPath("//div[@id='projects-list']//input[@placeholder='Procurar']");
        public By LnkProjeto => By.LinkText(ConfigurationManager.AppSettings["projeto".ToString()]);
        public By LnkCriarTarefa => By.LinkText("Criar Tarefa");
        public By BtnUserInfo => By.CssSelector("span.user-info");
        public By LnkMinhaConta => By.LinkText("Minha Conta");
        public By LnkPreferencias => By.LinkText("Preferências");
        public By LnkGerenciarColunas => By.LinkText("Gerenciar Colunas");
        public By LnkPerfis => By.LinkText("Perfís");
        public By LnkTokensAPI => By.LinkText("Tokens API");

        public void clicarBtnListaProjetos()
        {
            IWebElement listaProjetos = Uteis.Uteis.WaitForElement(LstProjetos);
            Uteis.Uteis.Click(LstProjetos, "Lista Projetos");
            Assert.AreEqual("Procurar", listaProjetos.GetAttribute("placeholder"));
        }

        public void selecionarProjetoPadrao()
        {
            Uteis.Uteis.WaitForElement(LnkProjeto);
            Uteis.Uteis.Click(LnkProjeto, ConfigurationManager.AppSettings["projeto".ToString()]);
        }
    }
}
