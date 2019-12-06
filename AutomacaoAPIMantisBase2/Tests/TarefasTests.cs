using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using AutomacaoAPIMantisBase2.Requests;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutomacaoAPIMantisBase2.Tests
{
    public class TarefasTests : TestBase
    {
        [Test][Parallelizable]
        public void BuscaTodasAsTarefas()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            TarefasGetRequest request = new TarefasGetRequest();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaTarefaEspecifica()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            TarefasGetRequest request = new TarefasGetRequest("1");

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaTarefasPorFiltroID()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            TarefasGetRequest request = new TarefasGetRequest("1", true);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaTarefasAtribuidasUsuarioToken()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            TarefasGetRequest request = new TarefasGetRequest("assigned", true);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaTarefasNaoAtribuidasUsuarioToken()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            TarefasGetRequest request = new TarefasGetRequest("unassigned", true);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaTarefasReportadasUsuarioToken()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            TarefasGetRequest request = new TarefasGetRequest("reported", true);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaTarefasMonitoradasUsuarioToken()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            TarefasGetRequest request = new TarefasGetRequest("monitored", true);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaTodasAsTarefasDeProjeto()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            TarefasGetRequest request = new TarefasGetRequest(1);            

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaTodosArquivosDeTarefa()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            ArquivosTarefasGetRequest request = new ArquivosTarefasGetRequest(1);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaUnicoArquivoDeTarefa()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            ArquivosTarefasGetRequest request = new ArquivosTarefasGetRequest(1, 1);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test][Parallelizable]
        public void InsereTarefa()
        {
            #region Parameters
            string dadosTarefa = "Tarefa Teste";
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            TarefasPostRequest request = new TarefasPostRequest();
            request.setJsonBody(dadosTarefa, dadosTarefa, "General", "Projeto Inicial");
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.IsTrue(response.Content.Contains(dadosTarefa));
            });
        }

        [Test]
        [Parallelizable]
        [TestCaseSource("ListarTarefas")]
        public void InsereTarefaDDT(string resumo, string descricao)
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            TarefasPostRequest request = new TarefasPostRequest();
            request.setJsonBody(resumo, descricao, "General", "Projeto Inicial");
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.IsTrue(response.Content.Contains(resumo));
                Assert.IsTrue(response.Content.Contains(descricao));
            });
        }

        [Test]
        [Parallelizable]
        public void InsereTarefaComAnexo()
        {
            #region Parameters
            string dadosTarefa = "Tarefa Teste";
            string nomeAnexo = "Anexo.txt";
            string conteudoAnexo = "Anexo Teste";
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            TarefasPostRequest request = new TarefasPostRequest();
            request.adicionaAnexo(nomeAnexo, conteudoAnexo);
            request.setJsonBody(dadosTarefa, dadosTarefa, "General", "Projeto Inicial");
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.IsTrue(response.Content.Contains(dadosTarefa));
                Assert.IsTrue(response.Content.Contains(nomeAnexo));
            });
        }

        public static List<TestCaseData> ListarTarefas
        {
            get
            {
                var testCases = new List<TestCaseData>();
                string[] split = { "" };
                using (var fs = File.OpenRead(String.Concat(GeneralHelpers.GetPastaArquivos(), "\\Tarefas.csv")))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;

                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            split = line.Split(new char[] { ';' }, StringSplitOptions.None);
                            string resumo = split[0].Trim();
                            string descricao = split[1].Trim();

                            if (!resumo.Equals("Resumo"))
                            {
                                var testCase = new TestCaseData(resumo, descricao);
                                testCases.Add(testCase);
                            }
                        }
                    }
                }
                return testCases;
            }
        }
    }
}
