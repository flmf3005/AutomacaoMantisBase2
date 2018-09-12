using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.Testes
{
    public class HomeTestes : Drivers.WebDriver
    {
        [Test]
        public void acessarGerenciarPage()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);

            loginTest.loginSucesso();

            Uteis.Uteis.clicarBtn(homePageObjects.MenuGerenciar);

            Assert.AreEqual("Informação do Site", homePageObjects.TitInformacao.Text);

        }

        [Test]
        public void buscarProjetos()
        {
            LoginTestes loginTest = new LoginTestes();
            PageObjects.HomePageObjects homePageObjects = new PageObjects.HomePageObjects(driver);

            loginTest.loginSucesso();

            homePageObjects.clicarBtnListaProjetos();



        }
    }
}
