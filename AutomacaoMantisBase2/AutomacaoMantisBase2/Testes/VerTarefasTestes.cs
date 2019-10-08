using AutomacaoMantisBase2.Drivers;
using AutomacaoMantisBase2.PageObjects;
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
    public class VerTarefasTestes : WebDriver
    {

        [Test]
        public void deletarTarefasTotal()
        {
            HomeTestes homeTest = new HomeTestes();
            VerTarefasPageObjects verTarefasPageObjects = new VerTarefasPageObjects(driver);
            homeTest.acessarVerTarefasPage();
            verTarefasPageObjects.deletarTudo();
            Assert.AreEqual(0, verTarefasPageObjects.totalBugs());
        }

        [Test]
        public void buscarTarefaPorID()
        {
            HomeTestes homeTest = new HomeTestes();
            VerTarefasPageObjects verTarefasPageObjects = new VerTarefasPageObjects(driver);
            CriarTarefasPageObjects criarTarefaPageObjects = new CriarTarefasPageObjects(driver);
            String resumo = String.Concat("Resumo Teste ", Uteis.Uteis.GeraStringRandom());
            String descricao = String.Concat("Descrição Teste ", Uteis.Uteis.GeraStringRandom());
            homeTest.acessarCriarTarefasPage();
            Uteis.Uteis.SendKeys(resumo, criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.SendKeys(descricao, criarTarefaPageObjects.FldDescricao);
            Uteis.Uteis.Click(criarTarefaPageObjects.BtnCriarTarefa);
            Uteis.Uteis.WaitForElement(criarTarefaPageObjects.BtnTarefaCriada);
            string idtarefa = criarTarefaPageObjects.idTarefaCriada(criarTarefaPageObjects.BtnTarefaCriada);
            Thread.Sleep(5000);
            Uteis.Uteis.SendKeys(idtarefa, verTarefasPageObjects.TxtFldBugID);
            verTarefasPageObjects.TxtFldBugID.SendKeys(Keys.Enter);
            Assert.AreEqual(driver.Url.ToString(), String.Concat("http://mantis.fernando.base2.com.br/view.php?id=",idtarefa));
        }

        [Test]
        public void buscarTarefaPorIDInexistente()
        {
            HomeTestes homeTest = new HomeTestes();
            VerTarefasPageObjects verTarefasPageObjects = new VerTarefasPageObjects(driver);
            CriarTarefasPageObjects criarTarefaPageObjects = new CriarTarefasPageObjects(driver);
            String idtarefa = "99999999";
            homeTest.acessarVerTarefasPage();
            Uteis.Uteis.SendKeys(idtarefa, verTarefasPageObjects.TxtFldBugID);
            verTarefasPageObjects.TxtFldBugID.SendKeys(Keys.Enter);
            Assert.AreEqual(true,verTarefasPageObjects.MsgErro.Displayed);
        }

        [Test]
        public void deletarTarefaUnica()
        {
            HomeTestes homeTest = new HomeTestes();
            CriarTarefasPageObjects criarTarefaPageObjects = new CriarTarefasPageObjects(driver);
            VerTarefasPageObjects verTarefasPageObjects = new VerTarefasPageObjects(driver);
            String resumo = String.Concat("Resumo Teste ", Uteis.Uteis.GeraStringRandom());
            String descricao = String.Concat("Descrição Teste ", Uteis.Uteis.GeraStringRandom());
            homeTest.acessarCriarTarefasPage();
            Uteis.Uteis.SendKeys(resumo, criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.SendKeys(descricao, criarTarefaPageObjects.FldDescricao);
            Uteis.Uteis.Click(criarTarefaPageObjects.BtnCriarTarefa);
            Thread.Sleep(5000);
            Uteis.Uteis.SendKeys(resumo, verTarefasPageObjects.TxtBuscar);
            Uteis.Uteis.Click(verTarefasPageObjects.BtnAplicarFiltro);
            verTarefasPageObjects.deletarTudo();
            Uteis.Uteis.Click(verTarefasPageObjects.BtnAplicarFiltro);
            Assert.AreEqual(0, verTarefasPageObjects.totalBugs());
        }

        [Test]
        public void alterarPrioridadeTarefa()
        {
            HomeTestes homeTest = new HomeTestes();
            CriarTarefasPageObjects criarTarefaPageObjects = new CriarTarefasPageObjects(driver);
            VerTarefasPageObjects verTarefasPageObjects = new VerTarefasPageObjects(driver);
            String resumo = String.Concat("Resumo Teste ", Uteis.Uteis.GeraStringRandom());
            String descricao = String.Concat("Descrição Teste ", Uteis.Uteis.GeraStringRandom());
            homeTest.acessarCriarTarefasPage();
            Uteis.Uteis.SendKeys(resumo, criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.SendKeys(descricao, criarTarefaPageObjects.FldDescricao);
            Uteis.Uteis.Click(criarTarefaPageObjects.BtnCriarTarefa);
            Thread.Sleep(5000);
            Uteis.Uteis.SendKeys(resumo, verTarefasPageObjects.TxtBuscar);
            Uteis.Uteis.Click(verTarefasPageObjects.BtnAplicarFiltro);
            verTarefasPageObjects.alterarPrioridade();
            Uteis.Uteis.Click(verTarefasPageObjects.BtnAplicarFiltro);
            Assert.AreEqual(verTarefasPageObjects.PrioridadeAlta, verTarefasPageObjects.PrioridadeTarefaFiltro);
        }
    }
}
