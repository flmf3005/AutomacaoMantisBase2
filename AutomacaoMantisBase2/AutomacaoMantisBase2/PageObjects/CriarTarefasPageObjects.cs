using AutomacaoMantisBase2.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.PageObjects
{
    public class CriarTarefasPageObjects : WebDriver
    {
        public CriarTarefasPageObjects(IWebDriver driver)
        {
        }

        public IWebElement FormTitInsercao => driver.FindElement(By.XPath("//form[@id='report_bug_form']/div/div/h4"));
        public IWebElement FldResumo => driver.FindElement(By.Id("summary"));
        public IWebElement FldDescricao => driver.FindElement(By.Id("description"));
        public IWebElement ChBContinuar => driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Continuar Relatando'])[1]/following::span[1]"));
        public IWebElement BtnCriarTarefa => driver.FindElement(By.XPath("//input[@value='Criar Nova Tarefa']"));
        public IWebElement LnkCriarTarefa => driver.FindElement(By.LinkText("Criar Tarefa"));
        public IWebElement BtnTarefaCriada => driver.FindElement(By.XPath("//a[contains(text(),'Visualizar Tarefa Enviada')]"));
        
        public string idTarefaCriada (IWebElement element)
        {
            string tarefa = element.Text;
            string[] split = tarefa.Split(' ');
            return split.Last();
        }

        public bool VerificaLknTarefaCriada (string tarefa)
        {
            string xpath = String.Concat("//a[@href='/view.php?id=", tarefa, "']");
            Uteis.Uteis.esperaElemento(driver.FindElement(By.XPath(xpath)));
            return driver.FindElement(By.XPath(xpath)).Displayed;
        }
        


    }
}
