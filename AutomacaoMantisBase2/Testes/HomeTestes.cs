using AutomacaoMantisBase2.PageObjects;
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
        LoginTestes loginTest = new LoginTestes();
        HomePageObjects homePageObjects = new HomePageObjects(driver);
        MyViewPageObjects myViewPageObjects = new MyViewPageObjects(driver);
        VerTarefasPageObjects verTarefasPageObjects = new VerTarefasPageObjects(driver);
        CriarTarefasPageObjects criarTarefasPageObjects = new CriarTarefasPageObjects(driver);
        RegMudancaPageObjects regMudancaPageObjects = new RegMudancaPageObjects(driver);
        PlanejamentoPageObjects planejamentoPageObjects = new PlanejamentoPageObjects(driver);
        ResumoPageObjects resumoPageObjects = new ResumoPageObjects(driver);

        [Test]
        public void acessarMyViewPage()
        {
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.MenuMyView, "Minha Visão");
            Uteis.Uteis.WaitForElement(myViewPageObjects.LnkAtrbuidosAMim);
            Assert.AreEqual("Atribuídos a Mim (não resolvidos)", Uteis.Uteis.WaitForElement(myViewPageObjects.LnkAtrbuidosAMim).Text);
        }

        [Test]
        public void acessarVerTarefasPage()
        {
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.MenuVerTarefas, "Ver Tarefas");
            Uteis.Uteis.WaitForElement(verTarefasPageObjects.DivFiltros);
            Assert.AreEqual("Filtros", Uteis.Uteis.WaitForElement(verTarefasPageObjects.DivFiltros).Text);
        }

        [Test]
        public void acessarCriarTarefasPage()
        {
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.MenuCriarTarefas, "Criar Tarefa");
            Uteis.Uteis.WaitForElement(criarTarefasPageObjects.FormTitInsercao);
            Assert.AreEqual("Digite os Detalhes do Relatório", Uteis.Uteis.WaitForElement(criarTarefasPageObjects.FormTitInsercao).Text);
        }

        [Test]
        public void acessarRegMudancaPage()
        {
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.MenuRegistroMudancas, "Registro Mudanças");
            Uteis.Uteis.WaitForElement(regMudancaPageObjects.MsgNenhumRegistro);
            Assert.AreEqual("Nenhum registro de mudança disponível. Apenas tarefas que indiquem a versão na qual foi resolvida aparecerão nos registros de mudança.", Uteis.Uteis.WaitForElement(regMudancaPageObjects.MsgNenhumRegistro).Text);
        }

        [Test]
        public void acessarPlanejamentoPage()
        {
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.MenuPlanejamento, "Planejamento");
            Uteis.Uteis.WaitForElement(planejamentoPageObjects.MsgNenhumPlanejamento);
            Assert.AreEqual("Nenhum planejamento disponível. Apenas tarefas com a versão indicada aparecerão no planejamento.", Uteis.Uteis.WaitForElement(planejamentoPageObjects.MsgNenhumPlanejamento).Text);
        }

        [Test]
        public void acessarResumoPage()
        {
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.MenuResumo, "Resumo");
            Uteis.Uteis.WaitForElement(resumoPageObjects.DivResumo);
            Assert.AreEqual("Resumo", Uteis.Uteis.WaitForElement(resumoPageObjects.DivResumo).Text);
        }
        [Test]
        public void acessarGerenciarPage()
        {
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.MenuGerenciar, "Gerenciar");
            Uteis.Uteis.WaitForElement(homePageObjects.TitInformacao);
            Assert.AreEqual("Informação do Site", Uteis.Uteis.WaitForElement(homePageObjects.TitInformacao).Text);
        }

        [Test]
        public void acessarMinhaContaPage()
        {
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.BtnUserInfo, "Usuário");
            Uteis.Uteis.Click(homePageObjects.LnkMinhaConta, "Minha Conta");
            Assert.AreEqual("Alterar Conta", Uteis.Uteis.WaitForElement(homePageObjects.TitInformacao).Text);
        }

        [Test]
        public void acessarPreferenciasContaPage()
        {
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.BtnUserInfo, "Usuário");
            Uteis.Uteis.Click(homePageObjects.LnkMinhaConta, "Minha Conta");
            Uteis.Uteis.Click(homePageObjects.LnkPreferencias, "Preferências");
            Assert.AreEqual("Preferências da Conta", Uteis.Uteis.WaitForElement(homePageObjects.TitInformacao).Text);
        }

        [Test]
        public void acessarGerenciarColunasContaPage()
        {
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.BtnUserInfo, "Usuário");
            Uteis.Uteis.Click(homePageObjects.LnkMinhaConta, "Minha Conta");
            Uteis.Uteis.Click(homePageObjects.LnkGerenciarColunas, "Gerenciar Colunas");
            Assert.AreEqual("Gerenciar Colunas", Uteis.Uteis.WaitForElement(homePageObjects.TitInformacao).Text);
        }

        [Test]
        public void acessarPerfisContaPage()
        {
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.BtnUserInfo, "Usuário");
            Uteis.Uteis.Click(homePageObjects.LnkMinhaConta, "Minha Conta");
            Uteis.Uteis.Click(homePageObjects.LnkPerfis, "Perfis");
            Assert.AreEqual("Adicionar Perfil", Uteis.Uteis.WaitForElement(homePageObjects.TitInformacao).Text);
        }

        [Test]
        public void acessarTokensAPIContaPage()
        {
            loginTest.loginSucesso();
            Uteis.Uteis.Click(homePageObjects.BtnUserInfo, "Usuário");
            Uteis.Uteis.Click(homePageObjects.LnkMinhaConta, "Minha Conta");
            Uteis.Uteis.Click(homePageObjects.LnkTokensAPI, "Tokens API");
            Assert.AreEqual("Criar token API", Uteis.Uteis.WaitForElement(homePageObjects.TitInformacao).Text);
        }
    }
}
