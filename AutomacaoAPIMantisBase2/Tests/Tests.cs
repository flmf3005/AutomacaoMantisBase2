using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Requests;
using NUnit.Framework;
using RestSharp;

namespace AutomacaoAPIMantisBase2.Tests
{
    public class Tests : TestBase
    {
        [Test]
        public void BuscaTodosOsProjetos()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            Request request = new Request();
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

    }
}
