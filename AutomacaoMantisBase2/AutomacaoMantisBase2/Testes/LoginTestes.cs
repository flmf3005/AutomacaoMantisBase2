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

        [Test]
        public void acessarLoginPage()
        {
            PageObjects.LoginPageObjects loginPage = new PageObjects.LoginPageObjects(driver);

            loginPage.verificaLoginPage();
        }

        [Test]
        public void inserirUsername()
        {
            PageObjects.LoginPageObjects loginPage = new PageObjects.LoginPageObjects(driver);

            loginPage.inserirUsername();
        }

        [Test]
        public void loginSucesso()
        {
            PageObjects.LoginPageObjects loginPage = new PageObjects.LoginPageObjects(driver);

            loginPage.inserirUsername();

            loginPage.inserirSenha();
        }

        [Test]
        public void loginFalha()
        {
            PageObjects.LoginPageObjects loginPage = new PageObjects.LoginPageObjects(driver);

            loginPage.inserirUsername();

            loginPage.inserirSenhaIncorreta();
        }

        [Test]
        public void loginVazio()
        {
            PageObjects.LoginPageObjects loginPage = new PageObjects.LoginPageObjects(driver);

            loginPage.inserirUsernameVazio();
        }

        [Test]
        public void criarConta()
        {
            PageObjects.LoginPageObjects loginPage = new PageObjects.LoginPageObjects(driver);

            loginPage.clicarBtnCriarConta();
        }
    }
}
