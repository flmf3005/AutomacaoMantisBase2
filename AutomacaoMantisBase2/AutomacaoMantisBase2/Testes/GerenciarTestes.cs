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
            Uteis.Uteis.Click(gerenciarPageObjects.BtnUsuarios);
            Assert.AreEqual(true, gerenciarPageObjects.TitUsuarios.Displayed);
        }

        [Test]
        public void acessarGerenciarProjetosPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnProjetos);
            Assert.AreEqual(true, gerenciarPageObjects.TitProjetos.Displayed);
        }

        [Test]
        public void acessarGerenciarMarcadoresPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnMarcadores);
            Assert.AreEqual(true, gerenciarPageObjects.TitMarcadores.Displayed);
        }

        [Test]
        public void acessarGerenciarCamposPersonalizadosPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCampPers);
            Assert.AreEqual(true, gerenciarPageObjects.TitCampPers.Displayed);
        }

        [Test]
        public void acessarGerenciarPerfisGlobaisPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnPerfisGlob);
            Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitPerfGlobais);
            Assert.AreEqual(true, gerenciarPageObjects.TitPerfGlobais.Displayed);
        }

        [Test]
        public void acessarGerenciarPluginsPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnPlugins);
            Assert.AreEqual(true, gerenciarPageObjects.TitPlugins.Displayed);
        }

        [Test]
        public void acessarRelatorioPermissoesPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfig);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnRelPermissoes);
            Assert.AreEqual(true, gerenciarPageObjects.TitRelPermissoes.Displayed);
        }

        [Test]
        public void acessarRelatorioConfiguraçãoPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfig);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnRelConfiguracao);
            Assert.AreEqual(true, gerenciarPageObjects.TitRelConfiguracao.Displayed);
        }

        [Test]
        public void acessarLimiaresPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfig);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnLimiares);
            Assert.AreEqual(true, gerenciarPageObjects.TitLimiares.Displayed);
        }

        [Test]
        public void acessarTransicoesFluxoPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfig);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnTransFluxo);
            Assert.AreEqual(true, gerenciarPageObjects.TitTransFluxo.Displayed);
        }

        [Test]
        public void acessarNotificacoesEmailPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfig);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNotifEmail);
            Assert.AreEqual(true, gerenciarPageObjects.TitNotifEmail.Displayed);
        }

        [Test]
        public void acessarGerenciarColunasPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfig);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnGerColunas);
            Assert.AreEqual(true, gerenciarPageObjects.TitGerColunas.Displayed);
        }

        [Test]
        public void criarNovoProjeto()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            String nome = String.Concat("Projeto Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarProjetosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnProjetos);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoProjeto);
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeProjeto);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarProjeto);
            Assert.AreEqual(true, gerenciarPageObjects.VerificaProjeto(nome));
        }

        [Test]
        public void validarProjetoDuplicado()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            String nome = String.Concat("Usuario Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarProjetosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnProjetos);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoProjeto);
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeProjeto);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarProjeto);
            Thread.Sleep(5000);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoProjeto);
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeProjeto);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarProjeto);
            Assert.AreEqual(true, gerenciarPageObjects.MsgErro.Displayed);
        }

        [Test]
        public void criarNovoMarcador()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            String nome = String.Concat("Marcador Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarMarcadoresPage();
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldMarcador);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarMarcador);
            Assert.AreEqual(true, gerenciarPageObjects.LnkMarcadorCriado(nome).Displayed);
        }

        [Test]
        public void criarNovoCampoPers()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            String nome = String.Concat("Campo Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarCamposPersonalizadosPage();
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeCampo);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoCampo);
            Thread.Sleep(5000);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCampPers);
            Assert.AreEqual(true, gerenciarPageObjects.LnkCampoCriado(nome).Displayed);
        }

        [Test]
        public void deletarCampoPers()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            String nome = String.Concat("Campo Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarCamposPersonalizadosPage();
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeCampo);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoCampo);
            Thread.Sleep(5000);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCampPers);
            Uteis.Uteis.Click(gerenciarPageObjects.LnkCampoCriado(nome));
            Uteis.Uteis.Click(gerenciarPageObjects.BtnApagarCampoPers);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfirmaApagarCampo);
            Assert.AreEqual(true, gerenciarPageObjects.MsgSucesso.Displayed);
        }

        [Test]
        public void validarCampoPersDuplicado()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            String nome = String.Concat("Campo Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarCamposPersonalizadosPage();
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeCampo);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoCampo);
            Thread.Sleep(5000);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCampPers);
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeCampo);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoCampo);
            Assert.AreEqual(true, gerenciarPageObjects.MsgErro.Displayed);
        }

        [Test]
        public void validarCampoPersVazio()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            String nome = String.Concat("Campo Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarCamposPersonalizadosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoCampo);
            Assert.AreEqual(true, gerenciarPageObjects.MsgErro.Displayed);
        }

        [Test]
        public void criarNovoUsuario()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            String nome = String.Concat("Usuario Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarUsuariosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarConta);
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeUsuario);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarUsuario);
            Thread.Sleep(5000);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnUsuarios);
            Assert.AreEqual(true, gerenciarPageObjects.LnkUsuarioCriado(nome).Displayed);
        }


        [Test]
        public void validarUsuarioDuplicado()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            String nome = String.Concat("Usuario Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarUsuariosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarConta);
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeUsuario);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarUsuario);
            Thread.Sleep(5000);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnUsuarios);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarConta);
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeUsuario);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarUsuario);          
            Assert.AreEqual(true, gerenciarPageObjects.MsgErro.Displayed);
        }

        [Test]
        public void alterarNomeUsuario()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            String nome = String.Concat("Usuario Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarUsuariosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarConta);
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeUsuario);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarUsuario);
            Thread.Sleep(5000);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnUsuarios);
            Uteis.Uteis.Click(gerenciarPageObjects.LnkUsuarioCriado(nome));
            Uteis.Uteis.SendKeys(String.Concat(nome, " - alterado"), gerenciarPageObjects.TxtFldEditarNomeUsuario);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnAtualizarUsuario);
            Assert.AreEqual("Operação realizada com sucesso.", gerenciarPageObjects.MsgSucesso.Text);
        }

        [Test]
        public void deletarUsuario()
        {
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            String nome = String.Concat("Usuario Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarUsuariosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarConta);
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeUsuario);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarUsuario);
            Thread.Sleep(5000);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnUsuarios);
            Uteis.Uteis.Click(gerenciarPageObjects.LnkUsuarioCriado(nome));
            Uteis.Uteis.Click(gerenciarPageObjects.BtnApagarUsuario);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnApagarConta);
            Assert.AreEqual("Operação realizada com sucesso.", gerenciarPageObjects.MsgSucesso.Text);
        }
    }
}