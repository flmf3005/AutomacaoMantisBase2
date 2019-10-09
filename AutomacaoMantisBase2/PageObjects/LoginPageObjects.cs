﻿using AutomacaoMantisBase2.Drivers;
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

        public IWebElement FldEntrar => driver.FindElement(By.XPath("//div[@id='login-box']/div/div/h4"));
        public IWebElement TxtUserName => driver.FindElement(By.Id("username"));
        public IWebElement BtnEntrar => driver.FindElement(By.XPath("//input[@value='Entrar']"));
        public IWebElement TxtSenha => driver.FindElement(By.Id("password"));
        public IWebElement LnkPerdeuSenha => driver.FindElement(By.LinkText("Perdeu a sua senha?"));
        public IWebElement BtnUserInfo => driver.FindElement(By.CssSelector("span.user-info"));
        public IWebElement LnkCriarNovaConta => driver.FindElement(By.LinkText("criar uma nova conta"));
        public IWebElement LnkSair => driver.FindElement(By.LinkText("Sair"));
        public void verificaLoginPage()
        {
            Uteis.Uteis.WaitForElement(element: FldEntrar);
            Assert.AreEqual("Entrar", FldEntrar.Text);
        }

        public void inserirUsername()
        {
            Uteis.Uteis.WaitForElement(TxtUserName);
            Uteis.Uteis.SendKeys(ConfigurationManager.AppSettings["username".ToString()], TxtUserName, "Username");
            Uteis.Uteis.Click(BtnEntrar, "Entrar");
            Assert.AreEqual("Perdeu a sua senha?", LnkPerdeuSenha.Text);
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
            Assert.AreEqual(ConfigurationManager.AppSettings["username".ToString()], BtnUserInfo.Text);
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
            Assert.AreEqual("username", TxtUserName.GetAttribute("id"));
        }
    }
}