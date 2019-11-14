using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Requests;
using NUnit.Framework;
using RestSharp;

namespace AutomacaoAPIMantisBase2.Tests
{
    public class TarefasTests : TestBase
    {
        [Test]
        public void BuscaTodasAsTarefas()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            TarefasRequest request = new TarefasRequest();
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        public void BuscaTodasAsTarefasDeProjeto()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            TarefasRequest request = new TarefasRequest(1);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }
    }
}
