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
            //Resultado esperado
            string statusCodeEsperado = "OK";
            string idProjeto = "1";
            string nameProjeto = "Projeto Inicial";
            #endregion

            ProjetosRequest request = new ProjetosRequest();
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(idProjeto, response.Data["projects"][0]["id"].ToString());
                Assert.AreEqual(nameProjeto, response.Data["projects"][0]["name"].ToString());
            });
        }

        [Test][Parallelizable]
        public void BuscaProjetoEspecifico()
        {
            #region Parameters
            int idProjeto = 1;
            //Resultado esperado
            string statusCodeEsperado = "OK";
            string nameProjeto = "Projeto Inicial";
            #endregion

            ProjetosRequest request = new ProjetosRequest(idProjeto);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(idProjeto.ToString(), response.Data["projects"][0]["id"].ToString());
                Assert.AreEqual(nameProjeto, response.Data["projects"][0]["name"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void BuscaProjetoInexistente()
        {
            #region Parameters
            int idProjeto = 999;
            //Resultado esperado
            string statusCodeEsperado = "NotFound";
            #endregion

            ProjetosRequest request = new ProjetosRequest(idProjeto);
            request.setJsonBody();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual("Project #" + idProjeto.ToString() + " not found", response.Data["message"].ToString());
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
                Assert.AreEqual(nome, response.Data["project"]["name"].ToString());
                Assert.AreEqual(descricao, response.Data["project"]["description"].ToString());
                StringAssert.IsMatch("(\\d+)", response.Data["project"]["id"].ToString());
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
                Assert.AreEqual(nome, response.Data["project"]["name"].ToString());
                Assert.AreEqual(descricao, response.Data["project"]["description"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void DeletaProjeto()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "OK";
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
            //Resultado esperado
            string statusCodeEsperado = "Forbidden";
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
            //Resultado esperado
            string statusCodeEsperado = "NoContent";
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
