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
        HomeTestes homeTest = new HomeTestes();
        CriarTarefasPageObjects criarTarefaPageObjects = new CriarTarefasPageObjects(driver);

        [Test]
        public void criarNovaTarefaUnica()
        {            
            String resumo = String.Concat("Resumo Teste ", Uteis.Uteis.GeraStringRandom());
            String descricao = String.Concat("Descrição Teste ", Uteis.Uteis.GeraStringRandom());
            homeTest.acessarCriarTarefasPage();
            Uteis.Uteis.SendKeys(resumo, criarTarefaPageObjects.FldResumo, "Resumo");
            Uteis.Uteis.SendKeys(descricao, criarTarefaPageObjects.FldDescricao, "Descrição");
            Uteis.Uteis.Click(criarTarefaPageObjects.BtnCriarTarefa, "Criar Tarefa");
            Uteis.Uteis.WaitForElement(criarTarefaPageObjects.BtnTarefaCriada);
            string idtarefa = criarTarefaPageObjects.idTarefaCriada(criarTarefaPageObjects.BtnTarefaCriada);
            Thread.Sleep(5000);
            Assert.AreEqual(true, criarTarefaPageObjects.VerificaLknTarefaCriada(idtarefa));
        }

        [Test]
        public void criarNovaTarefaDupla()
        {
            homeTest.acessarCriarTarefasPage();
            String resumo = String.Concat("Resumo Teste ", Uteis.Uteis.GeraStringRandom());
            String descricao = String.Concat("Descrição Teste ", Uteis.Uteis.GeraStringRandom());
            String resumo2 = String.Concat("Resumo Teste ", Uteis.Uteis.GeraStringRandom());
            String descricao2 = String.Concat("Descrição Teste ", Uteis.Uteis.GeraStringRandom());
            Uteis.Uteis.SendKeys(resumo, criarTarefaPageObjects.FldResumo, "Resumo");
            Uteis.Uteis.SendKeys(descricao, criarTarefaPageObjects.FldDescricao, "Descrição");
            Uteis.Uteis.Click(criarTarefaPageObjects.ChBContinuar, "Continuar");
            Uteis.Uteis.Click(criarTarefaPageObjects.BtnCriarTarefa, "Criar Tarefa");
            Uteis.Uteis.WaitForElement(criarTarefaPageObjects.BtnTarefaCriada);
            string idtarefa1 = criarTarefaPageObjects.idTarefaCriada(criarTarefaPageObjects.BtnTarefaCriada);
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Uteis.Uteis.WaitForElement(criarTarefaPageObjects.FldResumo);
            Uteis.Uteis.SendKeys(resumo2, criarTarefaPageObjects.FldResumo, "Resumo");
            Uteis.Uteis.SendKeys(descricao2, criarTarefaPageObjects.FldDescricao, "Descrição");
            Uteis.Uteis.Click(criarTarefaPageObjects.ChBContinuar, "Continuar");
            Uteis.Uteis.Click(criarTarefaPageObjects.BtnCriarTarefa, "Criar Tarefa");
            Uteis.Uteis.WaitForElement(criarTarefaPageObjects.BtnTarefaCriada);
            string idtarefa2 = criarTarefaPageObjects.idTarefaCriada(criarTarefaPageObjects.BtnTarefaCriada);
            Thread.Sleep(5000);
            Assert.AreEqual(true, criarTarefaPageObjects.VerificaLknTarefaCriada(idtarefa1));
            Assert.AreEqual(true, criarTarefaPageObjects.VerificaLknTarefaCriada(idtarefa2));
        }

        [Test]
        [TestCaseSource("ListarTarefas")]
        public void criarTarefasDDT(string resumo, string descricao)

        {
            homeTest.acessarCriarTarefasPage();
            Uteis.Uteis.SendKeys(resumo, criarTarefaPageObjects.FldResumo, "Resumo");
            Uteis.Uteis.SendKeys(descricao, criarTarefaPageObjects.FldDescricao, "Descrição");
            Uteis.Uteis.Click(criarTarefaPageObjects.BtnCriarTarefa, "Criar Tarefa");
            Uteis.Uteis.WaitForElement(criarTarefaPageObjects.BtnTarefaCriada);
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
                using (var fs = File.OpenRead(String.Concat(Uteis.Uteis.getPastaArquivos(), "\\Tarefas.csv")))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;

                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            split = line.Split(new char[] { ';' }, StringSplitOptions.None);
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