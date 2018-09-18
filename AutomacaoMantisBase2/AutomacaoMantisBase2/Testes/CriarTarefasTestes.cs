using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Test]
        public void criarTarefasDDT()

        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.CriarTarefasPageObjects criarTarefaPageObjects = new PageObjects.CriarTarefasPageObjects(driver);

            excel.Application x1Appl = new excel.Application();
            excel.Workbook x1WorkBook = x1Appl.Workbooks.Open(String.Concat(Uteis.Uteis.getPastaArquivos(),"\\Tarefas.xlsx"));
            excel.Worksheet x1WorkSheet = (excel.Worksheet)x1WorkBook.Worksheets.get_Item(1);
            excel.Range x1Range = x1WorkSheet.UsedRange;

            int xlRowCnt = 0;
            String Resumo;
            String Descricao;

            homeTest.acessarCriarTarefasPage();
            for (xlRowCnt = 2; xlRowCnt <= x1Range.Rows.Count; xlRowCnt++)
            {
                Resumo = (string)(x1Range.Cells[xlRowCnt, 1] as excel.Range).Value2;
                Descricao = (string)(x1Range.Cells[xlRowCnt, 2] as excel.Range).Value2;

                Uteis.Uteis.clicarBtn(criarTarefaPageObjects.LnkCriarTarefa);
                Uteis.Uteis.preencherTxtField(Resumo, criarTarefaPageObjects.FldResumo);
                Uteis.Uteis.preencherTxtField(Descricao, criarTarefaPageObjects.FldDescricao);
                Uteis.Uteis.clicarBtn(criarTarefaPageObjects.BtnCriarTarefa);
                Uteis.Uteis.esperaElemento(criarTarefaPageObjects.BtnTarefaCriada);
                string idtarefa = criarTarefaPageObjects.idTarefaCriada(criarTarefaPageObjects.BtnTarefaCriada);
                Thread.Sleep(5000);
                Assert.AreEqual(true, criarTarefaPageObjects.VerificaLknTarefaCriada(idtarefa));
            }

            x1WorkBook.Close();
            x1Appl.Quit();
        }
    }
}