using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using AutomacaoAPIMantisBase2.Requests;
using NUnit.Framework;
using RestSharp;

namespace AutomacaoAPIMantisBase2.Tests
{
    public class FiltrosTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void BuscaTodosOsFiltros()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "OK";
            string idFiltro = "2";
            string nameFiltro = "filter1";
            #endregion

            FiltrosRequest request = new FiltrosRequest();
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(idFiltro, response.Data["filters"][0]["id"].ToString());
                Assert.AreEqual(nameFiltro, response.Data["filters"][0]["name"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void BuscaFiltroEspecifico()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "OK";
            string idFiltro = "2";
            string nameFiltro = "filter1";
            #endregion

            FiltrosRequest request = new FiltrosRequest(int.Parse(idFiltro), Method.GET);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(idFiltro, response.Data["filters"][0]["id"].ToString());
                Assert.AreEqual(nameFiltro, response.Data["filters"][0]["name"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void BuscaFiltroInexistente()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "OK";
            #endregion

            FiltrosRequest request = new FiltrosRequest(999, Method.GET);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual("[]", response.Data["filters"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void DeletaFiltroEspecifico()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "NoContent";
            #endregion

            FiltrosRequest request = new FiltrosRequest(2, Method.DELETE);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void DeletaFiltroInexistente()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "NotFound";
            #endregion

            FiltrosRequest request = new FiltrosRequest(999, Method.DELETE);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }
    }
}
