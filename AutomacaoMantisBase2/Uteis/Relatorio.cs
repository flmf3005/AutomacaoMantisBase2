using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomacaoMantisBase2.Uteis
{
    class Relatorio
    {
        public static ExtentReports EXTENT_REPORT = null;
        public static ExtentTest TEST;
        static string reportPathName = ConfigurationManager.AppSettings["nomeDesafio".ToString()] + "_" + DateTime.Today.ToString("dd-MM-yyyy");
        static string reportName = ConfigurationManager.AppSettings["nomeDesafio".ToString()] + "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
        static string projectBinDebugPath = AppDomain.CurrentDomain.BaseDirectory;
        static FileInfo fileInfo = new FileInfo(projectBinDebugPath);
        static DirectoryInfo projectFolder = fileInfo.Directory;
        static string projectFolderPath = projectFolder.FullName;
        static string reportRootPath = projectFolderPath + "/Reports/";
        static string reportPath = projectFolderPath + "/Reports/" + reportPathName + "/";
        static string fileName = reportName + ".html";
        static string fullReportFilePath = reportPath + fileName;

        public static void CreateReport()
        {
            if (EXTENT_REPORT == null)
            {
                Uteis.VerificaDiretorio(reportRootPath);
                Uteis.VerificaDiretorio(reportPath);
                var htmlReporter = new ExtentV3HtmlReporter(fullReportFilePath);
                EXTENT_REPORT = new ExtentReports();
                EXTENT_REPORT.AttachReporter(htmlReporter);
            }
        }

        public static void AddTest()
        {
            string testName = TestContext.CurrentContext.Test.MethodName;
            var testCategory = (TestContext.CurrentContext.Test?.Properties["Category"]).Cast<string>().ToArray();
            TEST = EXTENT_REPORT.CreateTest(testName).AssignCategory(testCategory);
        }

        public static void AddTestInfo(string text)
        {
            TEST.Log(Status.Pass, text);
        }

        public static MediaEntityModelProvider GetScreenShotMedia()
        {
            string testName = TestContext.CurrentContext.Test.MethodName;
            string date = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "-");

            Screenshot screenShot = ((ITakesScreenshot)Drivers.WebDriver.driver).GetScreenshot();
            string filePathAndName = reportPath + "/" + testName + "_" + date + ".png";
            screenShot.SaveAsFile(filePathAndName, ScreenshotImageFormat.Png);
            
            TestContext.AddTestAttachment(filePathAndName);
            return MediaEntityBuilder.CreateScreenCaptureFromPath(filePathAndName.Replace(reportPath, ".")).Build();
        }

        public static void AddTestResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var message = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.Message);
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            switch (status)
            {
                case TestStatus.Failed:
                    TEST.Log(Status.Fail, "Test Result: " + Status.Fail + "<pre>" + "Message: " + message + "</pre>" + "<pre>" + "Stack Trace: " + stacktrace + "</pre>", GetScreenShotMedia());
                    break;
                case TestStatus.Inconclusive:
                    TEST.Log(Status.Warning, "Test Result: " + Status.Warning + "<pre>" + "Message: " + message + "</pre>" + "<pre>" + "Stack Trace: " + stacktrace + "</pre>", GetScreenShotMedia());
                    break;
                case TestStatus.Skipped:
                    TEST.Log(Status.Skip, "Test Result: " + Status.Skip + "<pre>" + "Message: " + message + "</pre>" + "<pre>" + "Stack Trace: " + stacktrace + "</pre>", GetScreenShotMedia());
                    break;
                default:
                    TEST.Log(Status.Pass, "Test Result: " + Status.Pass);
                    break;
            }
        }

        public static void GenerateReport()
        {
            EXTENT_REPORT.Flush();
            Console.WriteLine(fullReportFilePath);
        }
    }
}
