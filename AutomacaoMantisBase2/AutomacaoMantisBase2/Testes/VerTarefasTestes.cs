using AutomacaoMantisBase2.Drivers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.Testes
{
    public class VerTarefasTestes : WebDriver
    {
        public void acessarGerenciarUsuariosPage()
        {
            HomeTestes homeTest = new HomeTestes();
            PageObjects.GerenciarPageObjects gerenciarPageObjects = new PageObjects.GerenciarPageObjects(driver);
            homeTest.acessarGerenciarPage();
            Uteis.Uteis.clicarBtn(gerenciarPageObjects.BtnUsuarios);
            Assert.AreEqual(true, gerenciarPageObjects.TitUsuarios.Displayed);
        }
    }
}
