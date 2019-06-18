using AutomacaoMantisBase2.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;

namespace AutomacaoMantisBase2.Testes
{
    public class CriarTarefasTestes : Drivers.WebDriver
    {

        [Test]
        public void criarNovaTarefaUnica()
        {
            HomeTestes homeTest = new HomeTestes();
            CriarTarefasPageObjects criarTarefaPageObjects = new CriarTarefasPageObjects(driver);
            String resumo = String.Concat("Resumo Teste ", Uteis.Uteis.geraNomeRandom());
            String descricao = String.Concat("Descrição Teste ", Uteis.Uteis.geraNomeRandom());
            homeTest.acessarCriarTarefasPage();
            Uteis.Uteis.preencherTxtField(resumo, criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.preencherTxtField(descricao, criarTarefaPageObjects.FldDescricao);
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
            String resumo = String.Concat("Resumo Teste ", Uteis.Uteis.geraNomeRandom());
            String descricao = String.Concat("Descrição Teste ", Uteis.Uteis.geraNomeRandom());
            String resumo2 = String.Concat("Resumo Teste ", Uteis.Uteis.geraNomeRandom());
            String descricao2 = String.Concat("Descrição Teste ", Uteis.Uteis.geraNomeRandom());
            Uteis.Uteis.preencherTxtField(resumo, criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.preencherTxtField(descricao, criarTarefaPageObjects.FldDescricao);
            Uteis.Uteis.clicarBtn(criarTarefaPageObjects.ChBContinuar);
            Uteis.Uteis.clicarBtn(criarTarefaPageObjects.BtnCriarTarefa);
            Uteis.Uteis.esperaElemento(criarTarefaPageObjects.BtnTarefaCriada);
            string idtarefa1 = criarTarefaPageObjects.idTarefaCriada(criarTarefaPageObjects.BtnTarefaCriada);
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Uteis.Uteis.esperaElemento(criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.preencherTxtField(resumo2, criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.preencherTxtField(descricao2, criarTarefaPageObjects.FldDescricao);
            Uteis.Uteis.clicarBtn(criarTarefaPageObjects.ChBContinuar);
            Uteis.Uteis.clicarBtn(criarTarefaPageObjects.BtnCriarTarefa);
            Uteis.Uteis.esperaElemento(criarTarefaPageObjects.BtnTarefaCriada);
            string idtarefa2 = criarTarefaPageObjects.idTarefaCriada(criarTarefaPageObjects.BtnTarefaCriada);
            Thread.Sleep(5000);
            Assert.AreEqual(true, criarTarefaPageObjects.VerificaLknTarefaCriada(idtarefa1));
            Assert.AreEqual(true, criarTarefaPageObjects.VerificaLknTarefaCriada(idtarefa2));
        }

        [Test]
        [TestCaseSource("ListarTarefas")]
        public void criarTarefasDDT(string resumo, string descricao)

        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.CriarTarefasPageObjects criarTarefaPageObjects = new PageObjects.CriarTarefasPageObjects(driver);

            Uteis.Uteis.clicarBtn(criarTarefaPageObjects.LnkCriarTarefa);
            Uteis.Uteis.preencherTxtField(resumo, criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.preencherTxtField(descricao, criarTarefaPageObjects.FldDescricao);
            Uteis.Uteis.clicarBtn(criarTarefaPageObjects.BtnCriarTarefa);
            Uteis.Uteis.esperaElemento(criarTarefaPageObjects.BtnTarefaCriada);
            string idtarefa = criarTarefaPageObjects.idTarefaCriada(criarTarefaPageObjects.BtnTarefaCriada);
            Thread.Sleep(5000);
            Assert.AreEqual(true, criarTarefaPageObjects.VerificaLknTarefaCriada(idtarefa));
        }

        public static List<TestCaseData> ListarTarefas
        {
            get
            {
                var testCases = new List<TestCaseData>();
                string[] split = { "" };
                using (var fs = File.OpenRead(String.Concat(Uteis.Uteis.getPastaArquivos(), "\\Tarefas.xlsx")))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;

                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            split = line.Split(new char[] { ',' }, StringSplitOptions.None);
                            string resumo = split[0].Trim();
                            string descricao = split[1].Trim();

                            if (!resumo.Equals("Resumo"))
                            {
                                var testCase = new TestCaseData(resumo, descricao);
                                testCases.Add(testCase);
                            }


                        }
                    }
                }
                return testCases;
            }
        }
    }
}