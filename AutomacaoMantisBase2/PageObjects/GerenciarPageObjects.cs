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

namespace AutomacaoMantisBase2.PageObjects
{
    public class GerenciarPageObjects : WebDriver
    {
        public GerenciarPageObjects(IWebDriver driver)
        {
        }

        public By BtnUsuarios => By.LinkText("Gerenciar Usuários");
        public By BtnProjetos => By.LinkText("Gerenciar Projetos");
        public By BtnMarcadores => By.LinkText("Gerenciar Marcadores");
        public By BtnCampPers => By.LinkText("Gerenciar Campos Personalizados");
        public By BtnPerfisGlob => By.LinkText("Gerenciar Perfís Globais");
        public By BtnPlugins => By.LinkText("Gerenciar Plugins");
        public By BtnConfig => By.LinkText("Gerenciar Configuração");
        public By BtnRelPermissoes => By.LinkText("Relatório de Permissões");
        public By BtnRelConfiguracao => By.LinkText("Relatório de Configuração");
        public By BtnLimiares => By.LinkText("Limiares do Fluxo de Trabalho");
        public By BtnTransFluxo => By.LinkText("Transições de Fluxo de Trabalho");
        public By BtnNotifEmail => By.LinkText("Notificações por E-Mail");
        public By BtnGerColunas => By.LinkText("Gerenciar Colunas");
        public By BtnNovoProjeto => By.XPath("//button[@type='submit']");
        public By BtnCriarProjeto => By.XPath("//input[@value='Adicionar projeto']");
        public By BtnApagarProjeto => By.XPath("//input[@value='Apagar Projeto']");
        public By BtnCriarConta => By.XPath("//button[@type='submit']");
        public By BtnCriarUsuario => By.XPath("//input[@value='Criar Usuário']");
        public By BtnAtualizarUsuario => By.XPath("//input[@value='Atualizar Usuário']");
        public By BtnApagarUsuario => By.XPath("//input[@value='Apagar Usuário']");
        public By BtnApagarConta => By.XPath("//input[@value='Apagar Conta']");
        public By TitUsuarios => By.CssSelector("i.ace-icon.fa.fa-users");
        public By TitProjetos => By.CssSelector("i.ace-icon.fa.fa-puzzle-piece");
        public By TitMarcadores => By.CssSelector("i.ace-icon.fa.fa-tags");
        public By TitCampPers => By.CssSelector("i.ace-icon.fa.fa-flask");
        public By TitPerfGlobais => By.XPath("//input[@value='Adicionar Perfil']");
        public By TitPlugins => By.CssSelector("i.ace-icon.fa.fa-cubes");
        public By TitRelPermissoes => By.CssSelector("div.widget-header.widget-header-small");
        public By TitRelConfiguracao => By.CssSelector("i.ace-icon.fa.fa-filter");
        public By TitLimiares => By.CssSelector("i.ace-icon.fa.fa-sliders");
        public By TitTransFluxo => By.CssSelector("i.ace-icon.fa.fa-random");
        public By TitNotifEmail => By.CssSelector("i.ace-icon.fa.fa-envelope");
        public By TitGerColunas => By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Gerenciar Colunas'])[1]/following::i[1]");
        public By TxtFldNomeProjeto => By.Id("project-name");
        public By TxtFldNomeUsuario => By.Id("user-username");
        public By TxtFldEditarNomeUsuario => By.Id("edit-username");
        public By LnkProjetoCriado => By.XPath(String.Concat("(//a[contains(text(),'", ConfigurationManager.AppSettings["projetocriado".ToString()], "')])[2]"));
        public By MsgSucesso => By.CssSelector("p.bold.bigger-110");
        public By MsgErro => By.XPath("//div[@id='main-container']/div[@class='main-content']/div[@class='page-content']//div[@class='alert alert-danger']");
        public By TxtFldMarcador => By.Id("tag-name");
        public By BtnCriarMarcador => By.Name("config_set");
        public By TxtFldNomeCampo => By.Name("name");
        public By BtnNovoCampo => By.XPath("//input[@value='Novo Campo Personalizado']");
        public By BtnApagarCampoPers => By.XPath("//input[@value='Apagar Campo Personalizado']");
        public By BtnConfirmaApagarCampo => By.XPath("//input[@value='Apagar Campo']");


        public IWebElement LnkUsuarioCriado(string nomUsuario)
        {
            return driver.FindElement(By.LinkText(nomUsuario));
        }

        public IWebElement LnkMarcadorCriado(string nomMarcador)
        {
            return driver.FindElement(By.LinkText(nomMarcador));
        }
        public IWebElement LnkCampoCriado(string nomCampo)
        {
            return driver.FindElement(By.LinkText(nomCampo));
        }

        public bool VerificaProjeto(string nomProjeto)
        {
            By xpath = By.XPath("(//a[contains(text(),'" + nomProjeto + "')])[2]");
            IWebElement element = Uteis.Uteis.WaitForElement(xpath);
            return element.Displayed;
        }
    }
}