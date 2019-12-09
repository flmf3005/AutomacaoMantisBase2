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

        [Test]
        [Parallelizable]
        public void BuscaProjetoInexistente()
        {
            #region Parameters
            string statusCodeEsperado = "NotFound";

            //Resultado esperado

            #endregion

            ProjetosRequest request = new ProjetosRequest(99999);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void InsereProjeto()
        {
            #region Parameters
            string nome = "Projeto Teste";
            string descricao = "Projeto incluido na automacao";
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            ProjetosPostRequest request = new ProjetosPostRequest();
            request.setJsonBody(nome, descricao);
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.IsTrue(response.Content.Contains(nome));
                Assert.IsTrue(response.Content.Contains(descricao));
            });
        }

        [Test]
        [Parallelizable]
        [TestCaseSource("ListarProjetos")]
        public void InsereProjetoDDT(string nome, string descricao)
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            ProjetosPostRequest request = new ProjetosPostRequest();
            request.setJsonBody(nome, descricao);
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.IsTrue(response.Content.Contains(nome));
                Assert.IsTrue(response.Content.Contains(descricao));
            });
        }

        [Test]
        [Parallelizable]
        public void DeletaProjeto()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            ProjetosDeleteRequest request = new ProjetosDeleteRequest(2);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void DeletaProjetoInexistente()
        {
            #region Parameters
            string statusCodeEsperado = "Forbidden";

            //Resultado esperado

            #endregion

            ProjetosDeleteRequest request = new ProjetosDeleteRequest(999);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void AdicionaVersaoProjeto()
        {
            #region Parameters
            string versao = "2.0";
            string statusCodeEsperado = "NoContent";
            //Resultado esperado
            #endregion

            VersaoRequest request = new VersaoRequest(1);
            request.setJsonBody(versao);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        public static List<TestCaseData> ListarProjetos
        {
            get
            {
                var testCases = new List<TestCaseData>();
                string[] split = { "" };
                using (var fs = File.OpenRead(String.Concat(GeneralHelpers.GetPastaArquivos(), "\\Projetos.csv")))
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
                            string descricao = split[1].Trim();

                            if (!nome.Equals("Nome"))
                            {
                                var testCase = new TestCaseData(nome, descricao);
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
