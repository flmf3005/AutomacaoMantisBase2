using AutomacaoMantisBase2.Drivers;
using AutomacaoMantisBase2.PageObjects;
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
        HomeTestes homeTest = new HomeTestes();
        GerenciarPageObjects gerenciarPageObjects = new GerenciarPageObjects(driver);

        [Test]
        public void acessarGerenciarUsuariosPage()
        {
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnUsuarios, "Gerenciar Usuários");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitUsuarios).Displayed);
        }

        [Test]
        public void acessarGerenciarProjetosPage()
        {
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnProjetos, "Gerenciar Projetos");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitProjetos).Displayed);
        }

        [Test]
        public void acessarGerenciarMarcadoresPage()
        {
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnMarcadores, "Gerenciar Marcadores");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitMarcadores).Displayed);
        }

        [Test]
        public void acessarGerenciarCamposPersonalizadosPage()
        {
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCampPers, "Gerenciar Campos Personalizados");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitCampPers).Displayed);
        }

        [Test]
        public void acessarGerenciarPerfisGlobaisPage()
        {
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnPerfisGlob, "Gerenciar Perfis Globais");
            Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitPerfGlobais);
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitPerfGlobais).Displayed);
        }

        [Test]
        public void acessarGerenciarPluginsPage()
        {
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnPlugins, "Gerenciar Plugins");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitPlugins).Displayed);
        }

        [Test]
        public void acessarRelatorioPermissoesPage()
        {
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfig, "Gerenciar Configurações");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnRelPermissoes, "Relatório Permissões");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitRelPermissoes).Displayed);
        }

        [Test]
        public void acessarRelatorioConfiguraçãoPage()
        {
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfig, "Gerenciar Configurações");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnRelConfiguracao, "Relatório Configuração");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitRelConfiguracao).Displayed);
        }

        [Test]
        public void acessarLimiaresPage()
        {
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfig, "Gerenciar Configurações");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnLimiares, "Limiares do Fluxo de Trabalho");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitLimiares).Displayed);
        }

        [Test]
        public void acessarTransicoesFluxoPage()
        {
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfig, "Gerenciar Configurações");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnTransFluxo, "Transições de Fluxo de Trabalho");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitTransFluxo).Displayed);
        }

        [Test]
        public void acessarNotificacoesEmailPage()
        {
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfig, "Gerenciar Configurações");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNotifEmail, "Notificações por E-Mail");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitNotifEmail).Displayed);
        }

        [Test]
        public void acessarGerenciarColunasPage()
        {
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfig, "Gerenciar Configurações");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnGerColunas, "Gerenciar Colunas");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.TitGerColunas).Displayed);
        }

        [Test]
        public void criarNovoProjeto()
        {
            String nome = String.Concat("Projeto Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarProjetosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnProjetos, "Gerenciar Projetos");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoProjeto, "Novo Projeto");
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeProjeto, "Nome Projeto");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarProjeto, "Criar Projeto");
            Assert.AreEqual(true, gerenciarPageObjects.VerificaProjeto(nome));
        }

        [Test]
        public void validarProjetoDuplicado()
        {         
            String nome = String.Concat("Usuario Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarProjetosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnProjetos, "Gerenciar Projetos");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoProjeto, "Novo Projeto");
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeProjeto, "Nome Projeto");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarProjeto, "Criar Projeto");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoProjeto, "Novo Projeto");
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeProjeto, "Nome Projeto");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarProjeto, "Criar Projeto");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.MsgErro).Displayed);
        }

        [Test]
        public void criarNovoMarcador()
        {         
            String nome = String.Concat("Marcador Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarMarcadoresPage();
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldMarcador, "Marcador");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarMarcador, "Criar Marcador");
            Assert.AreEqual(true, gerenciarPageObjects.LnkMarcadorCriado(nome).Displayed);
        }

        [Test]
        public void criarNovoCampoPers()
        {         
            String nome = String.Concat("Campo Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarCamposPersonalizadosPage();
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeCampo, "Nome Campo");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoCampo, "Novo Campo");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCampPers, "Gerenciar Campos Personalizados");
            Assert.AreEqual(true, gerenciarPageObjects.LnkCampoCriado(nome).Displayed);
        }

        [Test]
        public void deletarCampoPers()
        {         
            String nome = String.Concat("Campo Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarCamposPersonalizadosPage();
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeCampo, "Nome Campo");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoCampo, "Novo Campo");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCampPers, "Gerenciar Campos Personalizados");
            Uteis.Uteis.Click(By.LinkText(nome), nome);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnApagarCampoPers, "Apagar Campo Personalizado");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnConfirmaApagarCampo, "Apagar Campo");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.MsgSucesso).Displayed);
        }

        [Test]
        public void validarCampoPersDuplicado()
        {         
            String nome = String.Concat("Campo Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarCamposPersonalizadosPage();
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeCampo, "Nome Campo");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoCampo, "Novo Campo");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCampPers, "Gerenciar Campos Personalizados");
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeCampo, "Nome Campo");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoCampo, "Novo Campo");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.MsgErro).Displayed);
        }

        [Test]
        public void validarCampoPersVazio()
        {         
            String nome = String.Concat("Campo Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarCamposPersonalizadosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnNovoCampo, "Novo Campo");
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.MsgErro).Displayed);
        }

        [Test]
        public void criarNovoUsuario()
        {         
            String nome = String.Concat("Usuario Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarUsuariosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarConta, "Criar Conta");
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeUsuario, "Nome Usuario");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarUsuario, "Criar Usuário");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnUsuarios, "Gerenciar Usuários");
            Assert.AreEqual(true, gerenciarPageObjects.LnkUsuarioCriado(nome).Displayed);
        }


        [Test]
        public void validarUsuarioDuplicado()
        {         
            String nome = String.Concat("Usuario Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarUsuariosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarConta, "Criar Conta");
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeUsuario, "Nome Usuario");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarUsuario, "Criar Usuário");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnUsuarios, "Gerenciar Usuários");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarConta, "Criar Conta");
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeUsuario, "Nome Usuario");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarUsuario, "Criar Usuário");          
            Assert.AreEqual(true, Uteis.Uteis.WaitForElement(gerenciarPageObjects.MsgErro).Displayed);
        }

        [Test]
        public void alterarNomeUsuario()
        {         
            String nome = String.Concat("Usuario Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarUsuariosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarConta, "Criar Conta");
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeUsuario, "Nome Usuario");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarUsuario, "Criar Usuário");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnUsuarios, "Gerenciar Usuários");
            Uteis.Uteis.Click(By.LinkText(nome), nome);
            Uteis.Uteis.SendKeys(String.Concat(nome, " - alterado"), gerenciarPageObjects.TxtFldEditarNomeUsuario, "Editar");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnAtualizarUsuario, "Atualizar Usuário");
            Assert.AreEqual("Operação realizada com sucesso.", Uteis.Uteis.WaitForElement(gerenciarPageObjects.MsgSucesso).Text);
        }

        [Test]
        public void deletarUsuario()
        {         
            String nome = String.Concat("Usuario Teste ", Uteis.Uteis.GeraStringRandom());
            acessarGerenciarUsuariosPage();
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarConta, "Criar Conta");
            Uteis.Uteis.SendKeys(nome, gerenciarPageObjects.TxtFldNomeUsuario, "Nome Usuario");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnCriarUsuario, "Criar Usuário");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnUsuarios, "Gerenciar Usuários");
            Uteis.Uteis.Click(By.LinkText(nome), nome);
            Uteis.Uteis.Click(gerenciarPageObjects.BtnApagarUsuario, "Apagar Usuário");
            Uteis.Uteis.Click(gerenciarPageObjects.BtnApagarConta, "Apagar Conta");
            Assert.AreEqual("Operação realizada com sucesso.", Uteis.Uteis.WaitForElement(gerenciarPageObjects.MsgSucesso).Text);
        }
    }
}