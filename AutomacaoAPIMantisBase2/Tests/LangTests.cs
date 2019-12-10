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
            string text = "all_projects";
            //Resultado esperado
            string nameText = "All Projects";
            string statusCodeEsperado = "OK";
            #endregion

            LangRequest request = new LangRequest(text);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(text, response.Data["strings"][0]["name"].ToString());
                Assert.AreEqual(nameText, response.Data["strings"][0]["localized"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void BuscaLangInexistente()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "OK";
            #endregion

            LangRequest request = new LangRequest("testes_testes");

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual("[]", response.Data["strings"].ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaVariosLang()
        {
            #region Parameters
            string text1 = "all_projects";
            string text2 = "move_bugs";
            //Resultado esperado
            string nameText1 = "All Projects";
            string nameText2 = "Move Issues";
            string statusCodeEsperado = "OK";
            #endregion

            List<string> langs = new List<string>();
            langs.Add(text1);
            langs.Add(text2);

            LangRequest request = new LangRequest(langs);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(text1, response.Data["strings"][0]["name"].ToString());
                Assert.AreEqual(nameText1, response.Data["strings"][0]["localized"].ToString());
                Assert.AreEqual(text2, response.Data["strings"][1]["name"].ToString());
                Assert.AreEqual(nameText2, response.Data["strings"][1]["localized"].ToString());
            });
        }
    }
}
