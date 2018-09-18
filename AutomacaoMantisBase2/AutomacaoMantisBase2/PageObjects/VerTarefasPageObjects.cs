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
        public IWebElement BtnOk => driver.FindElement(By.XPath("//input[@value='OK']"));
        public IWebElement BtnApagarTarefas => driver.FindElement(By.XPath("//input[@value='Apagar Tarefas']"));
        public IWebElement LblBugs => driver.FindElement(By.XPath("//form[@id='bug_action']/div/div/h4/span"));
        public IWebElement TxtBuscar => driver.FindElement(By.Id("filter-search-txt"));

        public int totalBugs()
        {
            String qntBugs = LblBugs.Text;
            String[] divs = qntBugs.Split('/');
            String[] divs2 = divs[0].Split('-');
            int totalBugs = Convert.ToInt32(divs2[1]);

            return totalBugs;
        }

        public void deletarTudo()
        {
            Uteis.Uteis.esperaElemento(LblBugs);
            int qntBugs = totalBugs();
            while (qntBugs > 0)
            {
                Uteis.Uteis.clicarBtn(ChBoxSelTudo);
                Uteis.Uteis.clicarBtn(ComboBoxAcoes);
                var selectElement = new SelectElement(ComboBoxAcoes);
                selectElement.SelectByText("Apagar");
                Uteis.Uteis.clicarBtn(BtnOk);
                Uteis.Uteis.clicarBtn(BtnApagarTarefas);
                qntBugs = totalBugs();
            }

        }

    }
}
