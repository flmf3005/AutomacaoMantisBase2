using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.Testes
{
    public class HomeTestes : Drivers.WebDriver
    {
        [Test]
        public void acessarMyViewPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);
            PageObjects.MyViewPageObjects myViewPageObjects = new PageObjects.MyViewPageObjects(driver);
            loginTest.loginSucesso();
            homePageObjects.clicarBtnListaProjetos();
            homePageObjects.selecionarProjetoPadrao();
            Uteis.Uteis.clicarBtn(homePageObjects.MenuMyView);
            Uteis.Uteis.esperaElemento(myViewPageObjects.LnkAtrbuidosAMim);
            Assert.AreEqual("Atribuídos a Mim (não resolvidos)", myViewPageObjects.LnkAtrbuidosAMim.Text);
        }

        [Test]
        public void acessarVerTarefasPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);
            PageObjects.VerTarefasPageObjects verTarefasPageObjects = new PageObjects.VerTarefasPageObjects(driver);
            loginTest.loginSucesso();
            homePageObjects.clicarBtnListaProjetos();
            homePageObjects.selecionarProjetoPadrao();
            Uteis.Uteis.clicarBtn(homePageObjects.MenuVerTarefas);
            Uteis.Uteis.esperaElemento(verTarefasPageObjects.DivFiltros);
            Assert.AreEqual("Filtros", verTarefasPageObjects.DivFiltros.Text);
        }

        [Test]
        public void acessarCriarTarefasPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);
            PageObjects.CriarTarefasPageObjects criarTarefasPageObjects = new PageObjects.CriarTarefasPageObjects(driver);
            loginTest.loginSucesso();
            homePageObjects.clicarBtnListaProjetos();
            homePageObjects.selecionarProjetoPadrao();
            Uteis.Uteis.clicarBtn(homePageObjects.MenuCriarTarefas);
            Uteis.Uteis.esperaElemento(criarTarefasPageObjects.FormTitInsercao);
            Assert.AreEqual("Digite os Detalhes do Relatório", criarTarefasPageObjects.FormTitInsercao.Text);
        }

        [Test]
        public void acessarRegMudancaPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);
            PageObjects.RegMudancaPageObjects regMudancaPageObjects = new PageObjects.RegMudancaPageObjects(driver);
            loginTest.loginSucesso();
            homePageObjects.clicarBtnListaProjetos();
            homePageObjects.selecionarProjetoPadrao();
            Uteis.Uteis.clicarBtn(homePageObjects.MenuRegistroMudancas);
            Uteis.Uteis.esperaElemento(regMudancaPageObjects.MsgNenhumRegistro);
            Assert.AreEqual("Nenhum registro de mudança disponível. Apenas tarefas que indiquem a versão na qual foi resolvida aparecerão nos registros de mudança.", regMudancaPageObjects.MsgNenhumRegistro.Text);
        }

        [Test]
        public void acessarPlanejamentoPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);
            PageObjects.PlanejamentoPageObjects planejamentoPageObjects = new PageObjects.PlanejamentoPageObjects(driver);
            loginTest.loginSucesso();
            homePageObjects.clicarBtnListaProjetos();
            homePageObjects.selecionarProjetoPadrao();
            Uteis.Uteis.clicarBtn(homePageObjects.MenuPlanejamento);
            Uteis.Uteis.esperaElemento(planejamentoPageObjects.MsgNenhumPlanejamento);
            Assert.AreEqual("Nenhum planejamento disponível. Apenas tarefas com a versão indicada aparecerão no planejamento.", planejamentoPageObjects.MsgNenhumPlanejamento.Text);
        }

        [Test]
        public void acessarResumoPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);
            PageObjects.ResumoPageObjects resumoPageObjects = new PageObjects.ResumoPageObjects(driver);
            loginTest.loginSucesso();
            homePageObjects.clicarBtnListaProjetos();
            homePageObjects.selecionarProjetoPadrao();
            Uteis.Uteis.clicarBtn(homePageObjects.MenuResumo);
            Uteis.Uteis.esperaElemento(resumoPageObjects.DivResumo);
            Assert.AreEqual("Resumo", resumoPageObjects.DivResumo.Text);
        }
        [Test]
        public void acessarGerenciarPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);
            loginTest.loginSucesso();
            homePageObjects.clicarBtnListaProjetos();
            homePageObjects.selecionarProjetoPadrao();
            Uteis.Uteis.clicarBtn(homePageObjects.MenuGerenciar);
            Uteis.Uteis.esperaElemento(homePageObjects.TitInformacao);
            Assert.AreEqual("Informação do Site", homePageObjects.TitInformacao.Text);
        }
    }
}
