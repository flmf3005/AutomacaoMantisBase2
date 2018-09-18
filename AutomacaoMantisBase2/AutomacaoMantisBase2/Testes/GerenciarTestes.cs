using AutomacaoMantisBase2.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.Testes
{
    public class GerenciarTestes : WebDriver
    {
        [Test]
        public void acessarGerenciarUsuariosPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnUsuarios);
            Assert.AreEqual(true, gerenciarPageObjects.TitUsuarios.Displayed);
        }

        [Test]
        public void acessarGerenciarProjetosPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnProjetos);
            Assert.AreEqual(true, gerenciarPageObjects.TitProjetos.Displayed);
        }

        [Test]
        public void acessarGerenciarMarcadoresPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnMarcadores);
            Assert.AreEqual(true, gerenciarPageObjects.TitMarcadores.Displayed);
        }

        [Test]
        public void acessarGerenciarCamposPersonalizadosPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnCampPers);
            Assert.AreEqual(true, gerenciarPageObjects.TitCampPers.Displayed);
        }

        [Test]
        public void acessarGerenciarPerfisGlobaisPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnPerfisGlob);
            Uteis.Uteis.esperaElemento(gerenciarPageObjects.TitPerfGlobais);
            Assert.AreEqual(true, gerenciarPageObjects.TitPerfGlobais.Displayed);
        }

        [Test]
        public void acessarGerenciarPluginsPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnPlugins);
            Assert.AreEqual(true, gerenciarPageObjects.TitPlugins.Displayed);
        }

        [Test]
        public void acessarRelatorioPermissoesPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnConfig);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnRelPermissoes);
            Assert.AreEqual(true, gerenciarPageObjects.TitRelPermissoes.Displayed);
        }

        [Test]
        public void acessarRelatorioConfiguraçãoPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnConfig);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnRelConfiguracao);
            Assert.AreEqual(true, gerenciarPageObjects.TitRelConfiguracao.Displayed);
        }

        [Test]
        public void acessarLimiaresPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnConfig);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnLimiares);
            Assert.AreEqual(true, gerenciarPageObjects.TitLimiares.Displayed);
        }

        [Test]
        public void acessarTransicoesFluxoPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnConfig);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnTransFluxo);
            Assert.AreEqual(true, gerenciarPageObjects.TitTransFluxo.Displayed);
        }

        [Test]
        public void acessarNotificacoesEmailPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnConfig);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnNotifEmail);
            Assert.AreEqual(true, gerenciarPageObjects.TitNotifEmail.Displayed);
        }

        [Test]
        public void acessarGerenciarColunasPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnConfig);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnGerColunas);
            Assert.AreEqual(true, gerenciarPageObjects.TitGerColunas.Displayed);
        }

        [Test]
        public void criarNovoProjeto()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnProjetos);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnNovoProjeto);
            Uteis.Uteis.preencherTxtField(ConfigurationManager.AppSettings["projetocriado".ToString()], gerenciarPageObjects.TxtFldNomeProjeto);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnCriarProjeto);
            Assert.AreEqual(true, gerenciarPageObjects.VerificaProjeto(ConfigurationManager.AppSettings["projetocriado".ToString()]));
        }

        [Test]
        public void criarNovoUsuario()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnUsuarios);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnCriarConta);
            Uteis.Uteis.preencherTxtField(ConfigurationManager.AppSettings["usuariocriado".ToString()], gerenciarPageObjects.TxtFldNomeUsuario);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnCriarUsuario);
            Thread.Sleep(5000);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnUsuarios);
            Assert.AreEqual(true, gerenciarPageObjects.LnkUsuarioCriado.Displayed);
        }

        [Test]
        public void alterarNomeUsuario()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            criarNovoUsuario();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.LnkUsuarioCriado);
            Uteis.Uteis.preencherTxtField(String.Concat(ConfigurationManager.AppSettings["usuariocriado".ToString()], " - alterado"),gerenciarPageObjects.TxtFldEditarNomeUsuario);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnAtualizarUsuario);
            Assert.AreEqual("Operação realizada com sucesso.", gerenciarPageObjects.MsgSucesso.Text);
        }

        [Test]
        public void deletarUsuario()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            criarNovoUsuario();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.LnkUsuarioCriado);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnApagarUsuario);
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnApagarConta);
            Assert.AreEqual("Operação realizada com sucesso.", gerenciarPageObjects.MsgSucesso.Text);
        }
    }
}
