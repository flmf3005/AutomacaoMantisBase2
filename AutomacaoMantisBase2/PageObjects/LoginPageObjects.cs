using AutomacaoMantisBase2.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;

namespace AutomacaoMantisBase2.PageObjects
{
    public class LoginPageObjects : WebDriver
    {

        public LoginPageObjects(IWebDriver driver)
        {

        }

        public By FldEntrar => By.XPath("//div[@id='login-box']/div/div/h4");
        public By TxtUserName => By.Id("username");
        public By BtnEntrar => By.XPath("//input[@value='Entrar']");
        public By TxtSenha => By.Id("password");
        public By LnkPerdeuSenha => By.LinkText("Perdeu a sua senha?");
        public By BtnUserInfo => By.CssSelector("span.user-info");
        public By LnkCriarNovaConta => By.LinkText("criar uma nova conta");
        public By LnkSair => By.LinkText("Sair");
        public void verificaLoginPage()
        {
            IWebElement entrar = Uteis.Uteis.WaitForElement(FldEntrar);
            Assert.AreEqual("Entrar", entrar.Text);
        }

        public void inserirUsername()
        {
            Uteis.Uteis.WaitForElement(TxtUserName);
            Uteis.Uteis.SendKeys(ConfigurationManager.AppSettings["username".ToString()], TxtUserName, "Username");
            Uteis.Uteis.Click(BtnEntrar, "Entrar");
            IWebElement perdeuSenha = Uteis.Uteis.WaitForElement(LnkPerdeuSenha);
            Assert.AreEqual("Perdeu a sua senha?", perdeuSenha.Text);
        }

        public void inserirUsernameJavaScript()
        {
            Uteis.Uteis.WaitForElement(TxtUserName);
            Uteis.Uteis.SendKeysJavaScript(ConfigurationManager.AppSettings["username".ToString()], TxtUserName, "Username");
            Uteis.Uteis.ClickJavaScript(BtnEntrar, "Entrar");
            IWebElement perdeuSenha = Uteis.Uteis.WaitForElement(LnkPerdeuSenha);
            Assert.AreEqual("Perdeu a sua senha?", perdeuSenha.Text);
        }

        public void inserirUsernameVazio()
        {
            Uteis.Uteis.WaitForElement(TxtUserName);
            Uteis.Uteis.Click(BtnEntrar, "Entrar");
            Assert.AreEqual("Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='AVISO:'])[1]/preceding::p[1]")).Text);
        }
        public void inserirSenha()
        {
            Uteis.Uteis.WaitForElement(TxtSenha);
            Uteis.Uteis.SendKeys(ConfigurationManager.AppSettings["password".ToString()], TxtSenha, "Senha");
            Uteis.Uteis.Click(BtnEntrar, "Entrar");
            IWebElement usuarioBtn = Uteis.Uteis.WaitForElement(BtnUserInfo);
            Assert.AreEqual(ConfigurationManager.AppSettings["username".ToString()], usuarioBtn.Text);
        }

        public void inserirSenhaIncorreta()
        {
            Uteis.Uteis.WaitForElement(TxtSenha);
            Uteis.Uteis.SendKeys("senha", TxtSenha, "Senha");
            Uteis.Uteis.Click(BtnEntrar, "Entrar");
            Assert.AreEqual("Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='AVISO:'])[1]/preceding::p[1]")).Text);
        }

        public void clicarBtnCriarConta()
        {
            Uteis.Uteis.WaitForElement(LnkCriarNovaConta);
            Uteis.Uteis.Click(LnkCriarNovaConta, "Criar Nova Conta");
            IWebElement usuario = Uteis.Uteis.WaitForElement(TxtUserName);
            Assert.AreEqual("username", usuario.GetAttribute("id"));
        }
    }
}
