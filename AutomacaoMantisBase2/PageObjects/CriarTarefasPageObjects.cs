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

        public By FormTitInsercao => By.XPath("//form[@id='report_bug_form']/div/div/h4");
        public By FldResumo => By.Id("summary");
        public By FldDescricao => By.Id("description");
        public By ChBContinuar => By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Continuar Relatando'])[1]/following::span[1]");
        public By BtnCriarTarefa => By.XPath("//input[@value='Criar Nova Tarefa']");
        public By LnkCriarTarefa => By.LinkText("Criar Tarefa");
        public By BtnTarefaCriada => By.XPath("//a[contains(text(),'Visualizar Tarefa Enviada')]");
        
        public string idTarefaCriada (IWebElement element)
        {
            string tarefa = element.Text;
            string[] split = tarefa.Split(' ');
            return split.Last();
        }

        public bool VerificaLknTarefaCriada (string tarefa)
        {
            string xpath = String.Concat("//a[@href='/view.php?id=", tarefa, "']");
            Uteis.Uteis.WaitForElement(By.XPath(xpath));
            return driver.FindElement(By.XPath(xpath)).Displayed;
        }
        


    }
}
