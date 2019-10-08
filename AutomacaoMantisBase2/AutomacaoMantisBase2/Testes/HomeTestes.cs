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
            Uteis.Uteis.Click(homePageObjects.MenuMyView);
            Uteis.Uteis.WaitForElement(myViewPageObjects.LnkAtrbuidosAMim);
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
            Uteis.Uteis.Click(homePageObjects.MenuVerTarefas);
            Uteis.Uteis.WaitForElement(verTarefasPageObjects.DivFiltros);
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
            Uteis.Uteis.Click(homePageObjects.MenuCriarTarefas);
            Uteis.Uteis.WaitForElement(criarTarefasPageObjects.FormTitInsercao);
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
            Uteis.Uteis.Click(homePageObjects.MenuRegistroMudancas);
            Uteis.Uteis.WaitForElement(regMudancaPageObjects.MsgNenhumRegistro);
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
            Uteis.Uteis.Click(homePageObjects.MenuPlanejamento);
            Uteis.Uteis.WaitForElement(planejamentoPageObjects.MsgNenhumPlanejamento);
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
            Uteis.Uteis.Click(homePageObjects.MenuResumo);
            Uteis.Uteis.WaitForElement(resumoPageObjects.DivResumo);
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
            Uteis.Uteis.Click(homePageObjects.MenuGerenciar);
            Uteis.Uteis.WaitForElement(homePageObjects.TitInformacao);
            Assert.AreEqual("Informação do Site", homePageObjects.TitInformacao.Text);
        }

        [Test]
        public void acessarMinhaContaPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);
            PageObjects.MyViewPageObjects myViewPageObjects = new PageObjects.MyViewPageObjects(driver);
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.BtnUserInfo);
            Uteis.Uteis.Click(homePageObjects.LnkMinhaConta);
            Assert.AreEqual("Alterar Conta", homePageObjects.TitInformacao.Text);
        }

        [Test]
        public void acessarPreferenciasContaPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);
            PageObjects.MyViewPageObjects myViewPageObjects = new PageObjects.MyViewPageObjects(driver);
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.BtnUserInfo);
            Uteis.Uteis.Click(homePageObjects.LnkMinhaConta);
            Uteis.Uteis.Click(homePageObjects.LnkPreferencias);
            Assert.AreEqual("Preferências da Conta", homePageObjects.TitInformacao.Text);
        }

        [Test]
        public void acessarGerenciarColunasContaPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);
            PageObjects.MyViewPageObjects myViewPageObjects = new PageObjects.MyViewPageObjects(driver);
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.BtnUserInfo);
            Uteis.Uteis.Click(homePageObjects.LnkMinhaConta);
            Uteis.Uteis.Click(homePageObjects.LnkGerenciarColunas);
            Assert.AreEqual("Gerenciar Colunas", homePageObjects.TitInformacao.Text);
        }

        [Test]
        public void acessarPerfisContaPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);
            PageObjects.MyViewPageObjects myViewPageObjects = new PageObjects.MyViewPageObjects(driver);
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.BtnUserInfo);
            Uteis.Uteis.Click(homePageObjects.LnkMinhaConta);
            Uteis.Uteis.Click(homePageObjects.LnkPerfis);
            Assert.AreEqual("Adicionar Perfil", homePageObjects.TitInformacao.Text);
        }

        [Test]
        public void acessarTokensAPIContaPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);
            PageObjects.MyViewPageObjects myViewPageObjects = new PageObjects.MyViewPageObjects(driver);
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.BtnUserInfo);
            Uteis.Uteis.Click(homePageObjects.LnkMinhaConta);
            Uteis.Uteis.Click(homePageObjects.LnkTokensAPI);
            Assert.AreEqual("Criar token API", homePageObjects.TitInformacao.Text);
        }
    }
}
