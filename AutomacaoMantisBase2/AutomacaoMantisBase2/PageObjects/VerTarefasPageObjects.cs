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
    public class VerTarefasPageObjects : WebDriver
    {
        public VerTarefasPageObjects(IWebDriver driver)
        {
        }

        public IWebElement DivFiltros => driver.FindElement(By.XPath("//div[@id='filter']/div/h4"));
        public IWebElement ChBoxSelTudo => driver.FindElement(By.XPath("//form[@id='bug_action']/div/div[2]/div[2]/div[2]/div/label/span"));
        public IWebElement ComboBoxAcoes => driver.FindElement(By.Name("action"));
        public IWebElement ComboBoxPrioridade => driver.FindElement(By.Name("priority"));
        public IWebElement BtnOk => driver.FindElement(By.XPath("//input[@value='OK']"));
        public IWebElement BtnApagarTarefas => driver.FindElement(By.XPath("//input[@value='Apagar Tarefas']"));
        public IWebElement LblBugs => driver.FindElement(By.XPath("//form[@id='bug_action']/div/div/h4/span"));
        public IWebElement TxtBuscar => driver.FindElement(By.Id("filter-search-txt"));
        public IWebElement BtnAplicarFiltro => driver.FindElement(By.XPath("//input[@name='filter_submit']"));
        public IWebElement PrioridadeTarefaFiltro => driver.FindElement(By.XPath("//table[@id='buglist']/tbody/tr/td[3]/i"));
        public IWebElement PrioridadeAlta => driver.FindElement(By.CssSelector("i.fa.fa-chevron-up.fa-lg.red"));
        public IWebElement BtnAtualizarPrioridade => driver.FindElement(By.XPath("//input[@value='Atualizar Prioridade']"));
        public IWebElement TxtFldBugID => driver.FindElement(By.Name("bug_id"));
        public IWebElement MsgErro => driver.FindElement(By.CssSelector("div.alert.alert-danger"));

        public int totalBugs()
        {
            String qntBugs = LblBugs.Text;
            String[] divs = qntBugs.Split('/');
            String[] divs2 = divs[0].Split('-');
            int totalBugs = Convert.ToInt32(divs2[1]);

            return totalBugs;
        }

        public IWebElement LnkTarefaCriada(string nomTarefa)
        {
            return driver.FindElement(By.LinkText(nomTarefa));
        }
        public void deletarTudo()
        {
            Uteis.Uteis.WaitForElement(LblBugs);
            int qntBugs = totalBugs();
            while (qntBugs > 0)
            {
                Uteis.Uteis.Click(ChBoxSelTudo);
                Uteis.Uteis.Click(ComboBoxAcoes);
                var selectElement = new SelectElement(ComboBoxAcoes);
                selectElement.SelectByText("Apagar");
                Uteis.Uteis.Click(BtnOk);
                Uteis.Uteis.Click(BtnApagarTarefas);
                qntBugs = totalBugs();
            }
        }

        public void alterarPrioridade()
        {
            Uteis.Uteis.Click(ChBoxSelTudo);
            Uteis.Uteis.Click(ComboBoxAcoes);
            var selectElement = new SelectElement(ComboBoxAcoes);
            selectElement.SelectByText("Atualizar Prioridade");
            Uteis.Uteis.Click(BtnOk);
            Uteis.Uteis.Click(ComboBoxPrioridade);
            selectElement = new SelectElement(ComboBoxPrioridade);
            selectElement.SelectByText("alta");
            Uteis.Uteis.Click(BtnAtualizarPrioridade);
        }

    }
}
