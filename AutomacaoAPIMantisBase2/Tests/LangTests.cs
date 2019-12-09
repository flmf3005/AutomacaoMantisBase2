using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using AutomacaoAPIMantisBase2.Requests;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;

namespace AutomacaoAPIMantisBase2.Tests
{
    public class LangTests : TestBase
    {
        [Test][Parallelizable]
        public void BuscaLangEspecifico()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            LangRequest request = new LangRequest("all_projects");

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void BuscaLangInexistente()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            LangRequest request = new LangRequest("testes_testes");

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaVariosLang()
        {
            #region Parameters
            string statusCodeEsperado = "OK";
            List<string> langs = new List<string>();
            langs.Add("all_projects");
            langs.Add("move_bugs");

            //Resultado esperado

            #endregion

            LangRequest request = new LangRequest(langs);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }
    }
}
