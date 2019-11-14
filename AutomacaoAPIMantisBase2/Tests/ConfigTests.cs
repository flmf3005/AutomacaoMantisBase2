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
        public void BuscaConfigEspecifico()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            ConfigRequest request = new ConfigRequest("csv_separator");

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        public void BuscaVariosConfig()
        {
            #region Parameters
            string statusCodeEsperado = "OK";
            List<string> configs = new List<string>();
            configs.Add("csv_separator");
            configs.Add("status_colors");

            //Resultado esperado

            #endregion

            ConfigRequest request = new ConfigRequest(configs);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }
    }
}
