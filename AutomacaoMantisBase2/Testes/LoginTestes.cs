using AutomacaoMantisBase2.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.Testes
{
    public class LoginTestes : Drivers.WebDriver
    {
        LoginPageObjects loginPage = new LoginPageObjects(driver);

        [Test]
        public void acessarLoginPage()
        {
            loginPage.verificaLoginPage();
        }

        [Test]
        public void inserirUsernameJS()
        {
            loginPage.inserirUsernameJavaScript();
        }

        [Test]
        public void loginSucesso()
        {
            loginPage.inserirUsername();
            loginPage.inserirSenha();
        }

        [Test]
        public void logoffSucesso()
        {
            loginSucesso();
            Uteis.Uteis.Click(loginPage.BtnUserInfo, "Usuário");
            Uteis.Uteis.Click(loginPage.LnkSair, "Sair");
            loginPage.verificaLoginPage();
        }

        [Test]
        public void loginFalha()
        {
            loginPage.inserirUsername();
            loginPage.inserirSenhaIncorreta();
        }

        [Test]
        public void loginVazio()
        {
            loginPage.inserirUsernameVazio();
        }

        [Test]
        public void acessarCriarConta()
        {
            loginPage.clicarBtnCriarConta();
        }
    }
}
