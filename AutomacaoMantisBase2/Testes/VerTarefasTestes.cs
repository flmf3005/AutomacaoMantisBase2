﻿using AutomacaoMantisBase2.Drivers;
using AutomacaoMantisBase2.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.Testes
{
    public class VerTarefasTestes : WebDriver
    {
        HomeTestes homeTest = new HomeTestes();
        VerTarefasPageObjects verTarefasPageObjects = new VerTarefasPageObjects(driver);
        CriarTarefasPageObjects criarTarefaPageObjects = new CriarTarefasPageObjects(driver);

        [Test]
        public void deletarTarefasTotal()
        {
            homeTest.acessarVerTarefasPage();
            verTarefasPageObjects.deletarTudo();
            Assert.AreEqual(0, verTarefasPageObjects.totalBugs());
        }

        [Test]
        public void buscarTarefaPorID()
        {
            String resumo = String.Concat("Resumo Teste ", Uteis.Uteis.GeraStringRandom());
            String descricao = String.Concat("Descrição Teste ", Uteis.Uteis.GeraStringRandom());
            homeTest.acessarCriarTarefasPage();
            Uteis.Uteis.SendKeys(resumo, criarTarefaPageObjects.FldResumo, "Resumo");
            Uteis.Uteis.SendKeys(descricao, criarTarefaPageObjects.FldDescricao, "Descrição");
            Uteis.Uteis.Click(criarTarefaPageObjects.BtnCriarTarefa, "Criar Tarefa");
            IWebElement tarefaCriadaBtn = Uteis.Uteis.WaitForElement(criarTarefaPageObjects.BtnTarefaCriada);
            string idtarefa = criarTarefaPageObjects.idTarefaCriada(tarefaCriadaBtn);
            Uteis.Uteis.SendKeys(idtarefa + Keys.Enter, verTarefasPageObjects.TxtFldBugID, "Bug Id");
            Assert.AreEqual(driver.Url.ToString(), ConfigurationManager.AppSettings["URL"].ToString() + "/view.php?id=" + idtarefa);
        }

        [Test]
        public void buscarTarefaPorIDInexistente()
        {
            String idtarefa = "99999999";
            homeTest.acessarVerTarefasPage();
            Uteis.Uteis.SendKeys(idtarefa + Keys.Enter, verTarefasPageObjects.TxtFldBugID, "Bug Id");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(verTarefasPageObjects.MsgErro).Displayed);
        }

        [Test]
        public void deletarTarefaUnica()
        {
            String resumo = String.Concat("Resumo Teste ", Uteis.Uteis.GeraStringRandom());
            String descricao = String.Concat("Descrição Teste ", Uteis.Uteis.GeraStringRandom());
            homeTest.acessarCriarTarefasPage();
            Uteis.Uteis.SendKeys(resumo, criarTarefaPageObjects.FldResumo, "Resumo");
            Uteis.Uteis.SendKeys(descricao, criarTarefaPageObjects.FldDescricao, "Descrição");
            Uteis.Uteis.Click(criarTarefaPageObjects.BtnCriarTarefa, "Criar Tarefa");
            Uteis.Uteis.SendKeys(resumo, verTarefasPageObjects.TxtBuscar, "Buscar");
            Uteis.Uteis.Click(verTarefasPageObjects.BtnAplicarFiltro, "Aplicar Filtro");
            verTarefasPageObjects.deletarTudo();
            Uteis.Uteis.Click(verTarefasPageObjects.BtnAplicarFiltro, "Aplicar Filtro");
            Assert.AreEqual(0, verTarefasPageObjects.totalBugs());
        }

        [Test]
        public void alterarPrioridadeTarefa()
        {
            String resumo = String.Concat("Resumo Teste ", Uteis.Uteis.GeraStringRandom());
            String descricao = String.Concat("Descrição Teste ", Uteis.Uteis.GeraStringRandom());
            homeTest.acessarCriarTarefasPage();
            Uteis.Uteis.SendKeys(resumo, criarTarefaPageObjects.FldResumo, "Resumo");
            Uteis.Uteis.SendKeys(descricao, criarTarefaPageObjects.FldDescricao, "Descrição");
            Uteis.Uteis.Click(criarTarefaPageObjects.BtnCriarTarefa, "Criar Tarefa");
            Uteis.Uteis.SendKeys(resumo, verTarefasPageObjects.TxtBuscar, "Buscar");
            Uteis.Uteis.Click(verTarefasPageObjects.BtnAplicarFiltro, "Aplicar Filtro");
            verTarefasPageObjects.alterarPrioridade();
            Uteis.Uteis.Click(verTarefasPageObjects.BtnAplicarFiltro, "Aplicar Filtro");
            Assert.AreEqual(Uteis.Uteis.WaitForElement(verTarefasPageObjects.PrioridadeAlta), Uteis.Uteis.WaitForElement(verTarefasPageObjects.PrioridadeTarefaFiltro));
        }
    }
}
