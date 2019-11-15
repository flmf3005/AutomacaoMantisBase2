using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Requests;
using NUnit.Framework;
using RestSharp;

namespace AutomacaoAPIMantisBase2.Tests
{
    public class ProjetosTests : TestBase
    {
        [Test][Parallelizable]
        public void BuscaTodosOsProjetos()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            ProjetosRequest request = new ProjetosRequest();
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaProjetoEspecifico()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            ProjetosRequest request = new ProjetosRequest(1);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

    }
}
