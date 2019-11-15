using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using AutomacaoAPIMantisBase2.Requests;
using NUnit.Framework;
using RestSharp;

namespace AutomacaoAPIMantisBase2.Tests
{
    public class FiltrosTests : TestBase
    {
        [Test][Parallelizable]
        public void BuscaTodosOsFiltros()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            FiltrosRequest request = new FiltrosRequest();
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaFiltroEspecifico()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            FiltrosRequest request = new FiltrosRequest(1, Method.GET);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void DeletaFiltroEspecifico()
        {
            #region Parameters
            string statusCodeEsperado = "NoContent";

            //Resultado esperado

            #endregion

            FiltrosRequest request = new FiltrosRequest(2, Method.DELETE);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }
    }
}
