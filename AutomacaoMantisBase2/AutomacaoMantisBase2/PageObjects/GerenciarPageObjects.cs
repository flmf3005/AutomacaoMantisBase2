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

        public IWebElement BtnUsuarios => driver.FindElement(By.LinkText("Gerenciar Usuários"));
        public IWebElement BtnProjetos => driver.FindElement(By.LinkText("Gerenciar Projetos"));
        public IWebElement BtnMarcadores => driver.FindElement(By.LinkText("Gerenciar Marcadores"));
        public IWebElement BtnCampPers => driver.FindElement(By.LinkText("Gerenciar Campos Personalizados"));
        public IWebElement BtnPerfisGlob => driver.FindElement(By.LinkText("Gerenciar Perfís Globais"));
        public IWebElement BtnPlugins => driver.FindElement(By.LinkText("Gerenciar Plugins"));
        public IWebElement BtnConfig => driver.FindElement(By.LinkText("Gerenciar Configuração"));
        public IWebElement BtnRelPermissoes => driver.FindElement(By.LinkText("Relatório de Permissões"));
        public IWebElement BtnRelConfiguracao => driver.FindElement(By.LinkText("Relatório de Configuração"));
        public IWebElement BtnLimiares => driver.FindElement(By.LinkText("Limiares do Fluxo de Trabalho"));
        public IWebElement BtnTransFluxo => driver.FindElement(By.LinkText("Transições de Fluxo de Trabalho"));
        public IWebElement BtnNotifEmail => driver.FindElement(By.LinkText("Notificações por E-Mail"));
        public IWebElement BtnGerColunas => driver.FindElement(By.LinkText("Gerenciar Colunas"));
        public IWebElement BtnNovoProjeto => driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement BtnCriarProjeto => driver.FindElement(By.XPath("//input[@value='Adicionar projeto']"));
        public IWebElement BtnApagarProjeto => driver.FindElement(By.XPath("//input[@value='Apagar Projeto']"));
        public IWebElement BtnCriarConta => driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement BtnCriarUsuario => driver.FindElement(By.XPath("//input[@value='Criar Usuário']"));
        public IWebElement BtnAtualizarUsuario => driver.FindElement(By.XPath("//input[@value='Atualizar Usuário']"));
        public IWebElement BtnApagarUsuario => driver.FindElement(By.XPath("//input[@value='Apagar Usuário']"));
        public IWebElement BtnApagarConta => driver.FindElement(By.XPath("//input[@value='Apagar Conta']"));
        public IWebElement TitUsuarios => driver.FindElement(By.CssSelector("i.ace-icon.fa.fa-users"));
        public IWebElement TitProjetos => driver.FindElement(By.CssSelector("i.ace-icon.fa.fa-puzzle-piece"));
        public IWebElement TitMarcadores => driver.FindElement(By.CssSelector("i.ace-icon.fa.fa-tags"));
        public IWebElement TitCampPers => driver.FindElement(By.CssSelector("i.ace-icon.fa.fa-flask"));
        public IWebElement TitPerfGlobais => driver.FindElement(By.XPath("//input[@value='Adicionar Perfil']"));
        public IWebElement TitPlugins => driver.FindElement(By.CssSelector("i.ace-icon.fa.fa-cubes"));
        public IWebElement TitRelPermissoes => driver.FindElement(By.CssSelector("div.widget-header.widget-header-small"));
        public IWebElement TitRelConfiguracao => driver.FindElement(By.CssSelector("i.ace-icon.fa.fa-filter"));
        public IWebElement TitLimiares => driver.FindElement(By.CssSelector("i.ace-icon.fa.fa-sliders"));
        public IWebElement TitTransFluxo => driver.FindElement(By.CssSelector("i.ace-icon.fa.fa-random"));
        public IWebElement TitNotifEmail => driver.FindElement(By.CssSelector("i.ace-icon.fa.fa-envelope"));
        public IWebElement TitGerColunas => driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Gerenciar Colunas'])[1]/following::i[1]"));
        public IWebElement TxtFldNomeProjeto => driver.FindElement(By.Id("project-name"));
        public IWebElement TxtFldNomeUsuario => driver.FindElement(By.Id("user-username"));
        public IWebElement TxtFldEditarNomeUsuario => driver.FindElement(By.Id("edit-username"));
        public IWebElement LnkProjetoCriado => driver.FindElement(By.XPath(String.Concat("(//a[contains(text(),'", ConfigurationManager.AppSettings["projetocriado".ToString()], "')])[2]")));
        public IWebElement MsgSucesso => driver.FindElement(By.CssSelector("p.bold.bigger-110"));
        public IWebElement MsgErro => driver.FindElement(By.XPath("//div[@id='main-container']/div[@class='main-content']/div[@class='page-content']//div[@class='alert alert-danger']"));
        public IWebElement TxtFldMarcador => driver.FindElement(By.Id("tag-name"));
        public IWebElement BtnCriarMarcador => driver.FindElement(By.Name("config_set"));
        public IWebElement TxtFldNomeCampo => driver.FindElement(By.Name("name"));
        public IWebElement BtnNovoCampo => driver.FindElement(By.XPath("//input[@value='Novo Campo Personalizado']"));
        public IWebElement BtnApagarCampoPers => driver.FindElement(By.XPath("//input[@value='Apagar Campo Personalizado']"));
        public IWebElement BtnConfirmaApagarCampo => driver.FindElement(By.XPath("//input[@value='Apagar Campo']"));


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
            string xpath = String.Concat("(//a[contains(text(),'", nomProjeto, "')])[2]");
            Thread.Sleep(5000);
            return driver.FindElement(By.XPath(xpath)).Displayed;
        }
    }
}