using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Requests;
using NUnit.Framework;
using RestSharp;

namespace AutomacaoAPIMantisBase2.Tests
{
    public class Tests : TestBase
    {
        [Test]
        public void DataRealizacaoMenorQue30Dias()
        {
            #region Parameters
            string solicitacaoItemId = "930770CF-0DDE-4284-8A87-B2E3E0AA6141";
            string pacienteId = "F2ECCD64-A4C9-477B-8059-02103C991480";
            string itensAssitenciais = "15888";
            string statusCodeEsperado = "OK";

            //Resultado esperado
            string resultId = "dc4cfcb1-05dc-4542-8f80-badbaad9f41c";
            string resultCodigoItem = "40101010";
            string resultDescricaoItem = "ECG convencional de até 12 derivações (40101010)";
            string resultDataSolicitacao = "2019-06-13T16:53:57.897";
            #endregion

            //SolicitacaoDBSteps.AtualizaDataDoItemSolicitacaoParaAgoraDB(solicitacaoItemId);
            Request request = new Request();
            request.setJsonBody(pacienteId, itensAssitenciais);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(resultId, response.Data["result"][0]["id"]);
                Assert.AreEqual(itensAssitenciais, response.Data["result"][0]["identificadorIntegracaoItemAssistencial"]);
                Assert.AreEqual(resultCodigoItem, response.Data["result"][0]["codigoItem"]);
                Assert.AreEqual(resultDescricaoItem, response.Data["result"][0]["descricaoItem"]);
                Assert.AreEqual(resultDataSolicitacao, response.Data["result"][0]["dataSolicitacao"]);
            });
        }

    }
}
