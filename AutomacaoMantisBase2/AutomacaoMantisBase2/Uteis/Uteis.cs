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

        public static void esperaElemento(IWebElement element)
        {
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, timeout: TimeSpan.FromSeconds(30));
            espera.Until(condition: SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public static void preencherTxtField(String value, IWebElement element)
        {
            esperaElemento(element);
            element.Clear();
            element.SendKeys(value);
        }

        public static void clicarBtn(IWebElement element)
        {
            esperaElemento(element);
            element.Click();
        }

        private static Random random = new Random();
        public static String geraNomeRandom()
        {
            int length = 10;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}