﻿using AutomacaoAPIMantisBase2.Bases;
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

        [Test]
        [Parallelizable]
        public void BuscaTarefaInexistente()
        {
            #region Parameters
            string statusCodeEsperado = "NotFound";

            //Resultado esperado

            #endregion

            TarefasGetRequest request = new TarefasGetRequest("9999999");

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

        [Test]
        [Parallelizable]
        public void AlteraTarefa()
        {
            #region Parameters
            string dadosTarefa = "Tarefa Teste";
            string status = "assigned";
            //Resultado esperado
            string statusCodeEsperado = "OK";
            #endregion

            TarefasPatchRequest request = new TarefasPatchRequest("1");
            request.setJsonBody(status);
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.IsTrue(response.Content.Contains(dadosTarefa));
                Assert.IsTrue(response.Content.Contains(status));
            });
        }

        [Test]
        [Parallelizable]
        public void DeletaTarefa()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "NoContent";
            #endregion

            TarefasDeleteRequest request = new TarefasDeleteRequest("2");
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());                
            });
        }

        [Test]
        [Parallelizable]
        public void InsereAnexoEmTarefa()
        {
            #region Parameters
            string nomeAnexo = "Anexo.txt";
            string conteudoAnexo = "Anexo Teste";
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            AnexosPostRequest request = new AnexosPostRequest("1");
            request.adicionaAnexo(nomeAnexo, conteudoAnexo);
            request.setJsonBody();
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        [TestCaseSource("ListarAnexos")]
        public void InsereAnexoEmTarefaDDT(string nomeAnexo, string conteudoAnexo)
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            AnexosPostRequest request = new AnexosPostRequest("1");
            request.adicionaAnexo(nomeAnexo, conteudoAnexo);
            request.setJsonBody();
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void InsereNotaEmTarefa()
        {
            #region Parameters
            string textoNota = "Nota teste incluida na tarefa 1";
            string nameState = "public";
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            NotasPostRequest request = new NotasPostRequest("1");
            request.setJsonBody(textoNota, nameState);
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void DeletaNota()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "OK";
            #endregion

            NotasDeleteRequest request = new NotasDeleteRequest("1", "1");
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void DeletaNotaInexistente()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "NotFound";
            #endregion

            NotasDeleteRequest request = new NotasDeleteRequest("1", "2");
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void InsereNotaComTimeTrackingEmTarefa()
        {
            #region Parameters
            string textoNota = "Nota teste incluida na tarefa 1";
            string nameState = "public";
            string time = "00:15";
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            NotasPostRequest request = new NotasPostRequest("1");
            request.setJsonBodyWithTimeTracking(textoNota, nameState, time);
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void InsereNotaComTimeTrackingEAnexoEmTarefa()
        {
            #region Parameters
            string textoNota = "Nota teste incluida na tarefa 1";
            string nameState = "public";
            string time = "00:15";
            string nomeAnexo = "Anexo.txt";
            string conteudoAnexo = "Anexo Teste";
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            NotasPostRequest request = new NotasPostRequest("1");
            request.setJsonBodyWithTimeTrackingAndAttachment(textoNota, nameState, time, nomeAnexo, conteudoAnexo);
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        [TestCaseSource("ListarNotas")]
        public void InsereNotaEmTarefaDDT(string textoNota, string nameState)
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            NotasPostRequest request = new NotasPostRequest("1");
            request.setJsonBody(textoNota, nameState);
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void MonitoraTarefa()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            MonitorPostRequest request = new MonitorPostRequest("1");
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void MonitoraTarefaUsuarioEspecifico()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            MonitorPostRequest request = new MonitorPostRequest("1");
            request.setJsonBody("administrator");
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void MonitoraTarefaUsuarioInexistente()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "NotFound";
            #endregion

            MonitorPostRequest request = new MonitorPostRequest("1");
            request.setJsonBody("fernando.ferreira");
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
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

        public static List<TestCaseData> ListarAnexos
        {
            get
            {
                var testCases = new List<TestCaseData>();
                string[] split = { "" };
                using (var fs = File.OpenRead(String.Concat(GeneralHelpers.GetPastaArquivos(), "\\Anexos.csv")))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;

                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            split = line.Split(new char[] { ';' }, StringSplitOptions.None);
                            string nome = split[0].Trim();
                            string texto = split[1].Trim();

                            if (!nome.Equals("Nome"))
                            {
                                var testCase = new TestCaseData(nome, texto);
                                testCases.Add(testCase);
                            }
                        }
                    }
                }
                return testCases;
            }
        }

        public static List<TestCaseData> ListarNotas
        {
            get
            {
                var testCases = new List<TestCaseData>();
                string[] split = { "" };
                using (var fs = File.OpenRead(String.Concat(GeneralHelpers.GetPastaArquivos(), "\\Notas.csv")))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;

                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            split = line.Split(new char[] { ';' }, StringSplitOptions.None);
                            string texto = split[0].Trim();
                            string state = split[1].Trim();

                            if (!texto.Equals("Texto"))
                            {
                                var testCase = new TestCaseData(texto, state);
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
