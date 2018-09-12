using AutomacaoMantisBase2.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.PageObjects
{
    public class LoginPageObjects : WebDriver
    {

        public LoginPageObjects(IWebDriver driver)
        {

        }

        public IWebElement FldEntrar => driver.FindElement(By.XPath("//div[@id='login-box']/div/div/h4"));

        public IWebElement TxtUserName => driver.FindElement(By.Id("username"));

        public IWebElement BtnEntrar => driver.FindElement(By.XPath("//input[@value='Entrar']"));

        public IWebElement TxtSenha => driver.FindElement(By.Id("password"));

        public IWebElement LnkPerdeuSenha => driver.FindElement(By.LinkText("Perdeu a sua senha?"));

        public IWebElement BtnUserInfo => driver.FindElement(By.CssSelector("span.user-info"));

        public IWebElement LnkCriarNovaConta => driver.FindElement(By.LinkText("criar uma nova conta"));


        public void verificaLoginPage()
        {
            Uteis.Uteis.esperaElemento(FldEntrar, "Field Entrar");

            Assert.AreEqual("Entrar", FldEntrar.Text);
        }

        public void inserirUsername()
        {
            Uteis.Uteis.esperaElemento(TxtUserName, "Campo Texto Username");

            Uteis.Uteis.preencherTxtField(ConfigurationManager.AppSettings["username".ToString()], TxtUserName);

            Uteis.Uteis.clicarBtn(BtnEntrar);

            Assert.AreEqual("Perdeu a sua senha?", LnkPerdeuSenha.Text);

        }

        public void inserirUsernameVazio()
        {
            Uteis.Uteis.esperaElemento(TxtUserName, "Campo Texto Username");

            Uteis.Uteis.clicarBtn(BtnEntrar);

            Assert.AreEqual("Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='AVISO:'])[1]/preceding::p[1]")).Text);
        }
        public void inserirSenha()
        {
            Uteis.Uteis.esperaElemento(TxtSenha, "Campo Texto Senha");

            Uteis.Uteis.preencherTxtField(ConfigurationManager.AppSettings["password".ToString()], TxtSenha);

            Uteis.Uteis.clicarBtn(BtnEntrar);

            Assert.AreEqual(ConfigurationManager.AppSettings["username".ToString()], BtnUserInfo.Text);
        }

        public void inserirSenhaIncorreta()
        {
            Uteis.Uteis.esperaElemento(TxtSenha, "Campo Texto Senha");

            Uteis.Uteis.preencherTxtField("senha", TxtSenha);

            Uteis.Uteis.clicarBtn(BtnEntrar);

            Assert.AreEqual("Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='AVISO:'])[1]/preceding::p[1]")).Text);
        }

        public void clicarBtnCriarConta()
        {
            Uteis.Uteis.esperaElemento(LnkCriarNovaConta, "Campo Criar uma nova conta");

            Uteis.Uteis.clicarBtn(LnkCriarNovaConta);

            Assert.AreEqual("username", TxtUserName.GetAttribute("id"));
        }
    }
}
