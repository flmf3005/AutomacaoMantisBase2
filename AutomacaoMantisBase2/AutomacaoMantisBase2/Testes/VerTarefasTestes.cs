using AutomacaoMantisBase2.Drivers;
using AutomacaoMantisBase2.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.Testes
{
    public class VerTarefasTestes : WebDriver
    {

        [Test]
        public void deletarTarefasTotal()
        {
            HomeTestes homeTest = new HomeTestes();
            VerTarefasPageObjects verTarefasPageObjects = new VerTarefasPageObjects(driver);
            homeTest.acessarVerTarefasPage();
            verTarefasPageObjects.deletarTudo();
            Assert.AreEqual(0, verTarefasPageObjects.totalBugs());
        }

    }
}
