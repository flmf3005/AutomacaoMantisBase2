using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using AutomacaoAPIMantisBase2.Requests;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;

namespace AutomacaoAPIMantisBase2.Tests
{
    public class ConfigTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void BuscaConfigEspecifico()
        {
            #region Parameters
            string config = "csv_separator";
            //Resultado esperado
            string statusCodeEsperado = "OK";
            #endregion

            ConfigRequest request = new ConfigRequest(config);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(config, response.Data["configs"][0]["option"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void BuscaConfigInexistente()
        {
            #region Parameters
            string config = "teste";
            //Resultado esperado
            string statusCodeEsperado = "OK";
            #endregion

            ConfigRequest request = new ConfigRequest(config);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual("[]", response.Data["configs"].ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaVariosConfig()
        {
            #region Parameters
            string config1 = "csv_separator";
            string config2 = "status_colors";
            //Resultado esperado
            string statusCodeEsperado = "OK";
            #endregion

            List<string> configs = new List<string>();
            configs.Add(config1);
            configs.Add(config2);

            ConfigRequest request = new ConfigRequest(configs);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(config1, response.Data["configs"][0]["option"].ToString());
                Assert.AreEqual(config2, response.Data["configs"][1]["option"].ToString());
            });
        }
    }
}
