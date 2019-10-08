using AutomacaoMantisBase2.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;
using System.Reflection;


namespace AutomacaoMantisBase2.Uteis
{
    public class Uteis
    {
        public static String getPathSeleniumDriver()
        {
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);

            var gparent = Directory.GetParent(Directory.GetParent(strAppDir).ToString());

            String strAppFolderData = gparent + "\\Drivers";
            return strAppFolderData; //+ strAppFolderData;
        }

        public static String getPastaArquivos()
        {
            String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);

            var gparent = Directory.GetParent(Directory.GetParent(strAppDir).ToString());

            String strAppFolderData = gparent + "\\Arquivos";
            return strAppFolderData;
        }

        public static void WaitForElement(IWebElement element)
        {
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, timeout: TimeSpan.FromSeconds(30));
            espera.Until(condition: SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public static void SendKeys(String value, IWebElement element, String nomeElemento)
        {
            WaitForElement(element);
            element.Clear();
            element.SendKeys(value);
            Relatorio.AddTestInfo("SendKeys || " + nomeElemento + "- Valor: " + value);
        }

        public static void Click(IWebElement element, String nomeElemento)
        {
            WaitForElement(element);
            element.Click();
            Relatorio.AddTestInfo("Click || " + nomeElemento);
        }

        public static String GeraStringRandom()
        {
            Random random = new Random();
            int length = 10;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void VerificaDiretorio(string fullReportFilePath)
        {
            var directory = Path.GetDirectoryName(fullReportFilePath);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        }
    }
}