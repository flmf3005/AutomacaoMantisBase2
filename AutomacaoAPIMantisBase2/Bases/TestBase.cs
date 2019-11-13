using AutomacaoAPIMantisBase2.Helpers;
using NUnit.Framework;

namespace AutomacaoAPIMantisBase2.Bases
{
    public class TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ExtentReportHelpers.CreateReport();
            DBHelpers.InicializarTestes();
        }

        [SetUp]
        public void SetUp()
        {
            ExtentReportHelpers.AddTest();
        }

        [TearDown]
        public void TearDown()
        {
            ExtentReportHelpers.AddTestResult();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentReportHelpers.GenerateReport();
        }

    }
}
