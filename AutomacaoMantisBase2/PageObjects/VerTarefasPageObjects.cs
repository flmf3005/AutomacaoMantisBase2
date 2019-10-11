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

        public By DivFiltros => By.XPath("//div[@id='filter']/div/h4");
        public By ChBoxSelTudo => By.XPath("//form[@id='bug_action']/div/div[2]/div[2]/div[2]/div/label/span");
        public By ComboBoxAcoes => By.Name("action");
        public By ComboBoxPrioridade => By.Name("priority");
        public By BtnOk => By.XPath("//input[@value='OK']");
        public By BtnApagarTarefas => By.XPath("//input[@value='Apagar Tarefas']");
        public By LblBugs => By.XPath("//form[@id='bug_action']/div/div/h4/span");
        public By TxtBuscar => By.Id("filter-search-txt");
        public By BtnAplicarFiltro => By.XPath("//input[@name='filter_submit']");
        public By PrioridadeTarefaFiltro => By.XPath("//table[@id='buglist']/tbody/tr/td[3]/i");
        public By PrioridadeAlta => By.CssSelector("i.fa.fa-chevron-up.fa-lg.red");
        public By BtnAtualizarPrioridade => By.XPath("//input[@value='Atualizar Prioridade']");
        public By TxtFldBugID => By.Name("bug_id");
        public By MsgErro => By.CssSelector("div.alert.alert-danger");

        public int totalBugs()
        {
            IWebElement bugs = Uteis.Uteis.WaitForElement(LblBugs);
            String qntBugs = bugs.Text;
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
                Uteis.Uteis.Click(ChBoxSelTudo, "Selecionar Todos");
                Uteis.Uteis.Click(ComboBoxAcoes, "Lista Ações");
                IWebElement acoesCmbBox = Uteis.Uteis.WaitForElement(ComboBoxAcoes);
                var selectElement = new SelectElement(acoesCmbBox);
                selectElement.SelectByText("Apagar");
                Uteis.Uteis.Click(BtnOk, "OK");
                Uteis.Uteis.Click(BtnApagarTarefas, "Apagar Tarefas");
                qntBugs = totalBugs();
            }
        }

        public void alterarPrioridade()
        {
            Uteis.Uteis.Click(ChBoxSelTudo, "Selecionar Todos");
            Uteis.Uteis.Click(ComboBoxAcoes, "Lista Ações");
            IWebElement acoesCmbBox = Uteis.Uteis.WaitForElement(ComboBoxAcoes);
            var selectElement = new SelectElement(acoesCmbBox);
            selectElement.SelectByText("Atualizar Prioridade");
            Uteis.Uteis.Click(BtnOk, "OK");
            Uteis.Uteis.Click(ComboBoxPrioridade, "Prioridade");
            IWebElement prioridadeCmbBox = Uteis.Uteis.WaitForElement(ComboBoxPrioridade);
            selectElement = new SelectElement(prioridadeCmbBox);
            selectElement.SelectByText("alta");
            Uteis.Uteis.Click(BtnAtualizarPrioridade, "Atualizar Prioridade");
        }

    }
}
