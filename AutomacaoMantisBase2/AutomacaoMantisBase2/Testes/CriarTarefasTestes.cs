using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.Testes
{
    public class CriarTarefasTestes : Drivers.WebDriver
    {
        [Test]
        public void criarNovaTarefaUnica()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.CriarTarefasPageObjects criarTarefaPageObjects = new PageObjects.CriarTarefasPageObjects(driver);
            homeTest.acessarCriarTarefasPage();
            Uteis.Uteis.preencherTxtField("Resumo Teste", criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.preencherTxtField("Descrição Teste ", criarTarefaPageObjects.FldDescricao);
            Uteis.Uteis.clicarBtn(criarTarefaPageObjects.BtnCriarTarefa);
            Uteis.Uteis.esperaElemento(criarTarefaPageObjects.BtnTarefaCriada);
            string idtarefa = criarTarefaPageObjects.idTarefaCriada(criarTarefaPageObjects.BtnTarefaCriada);
            Thread.Sleep(5000);
            Assert.AreEqual(true, criarTarefaPageObjects.VerificaLknTarefaCriada(idtarefa));
        }

        [Test]
        public void criarNovaTarefaDupla()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.CriarTarefasPageObjects criarTarefaPageObjects = new PageObjects.CriarTarefasPageObjects(driver);
            homeTest.acessarCriarTarefasPage();
            Uteis.Uteis.preencherTxtField("Resumo Teste", criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.preencherTxtField("Descrição Teste ", criarTarefaPageObjects.FldDescricao);
            Uteis.Uteis.clicarBtn(criarTarefaPageObjects.ChBContinuar);
            Uteis.Uteis.clicarBtn(criarTarefaPageObjects.BtnCriarTarefa);
            Uteis.Uteis.esperaElemento(criarTarefaPageObjects.BtnTarefaCriada);
            string idtarefa1 = criarTarefaPageObjects.idTarefaCriada(criarTarefaPageObjects.BtnTarefaCriada);
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Uteis.Uteis.esperaElemento(criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.preencherTxtField("Resumo Teste 2", criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.preencherTxtField("Descrição Teste 2", criarTarefaPageObjects.FldDescricao);
            Uteis.Uteis.clicarBtn(criarTarefaPageObjects.ChBContinuar);
            Uteis.Uteis.clicarBtn(criarTarefaPageObjects.BtnCriarTarefa);
            Uteis.Uteis.esperaElemento(criarTarefaPageObjects.BtnTarefaCriada);
            string idtarefa2 = criarTarefaPageObjects.idTarefaCriada(criarTarefaPageObjects.BtnTarefaCriada);
            Thread.Sleep(5000);
            Assert.AreEqual(true, criarTarefaPageObjects.VerificaLknTarefaCriada(idtarefa1));
            Assert.AreEqual(true, criarTarefaPageObjects.VerificaLknTarefaCriada(idtarefa2));
        }
    }
}