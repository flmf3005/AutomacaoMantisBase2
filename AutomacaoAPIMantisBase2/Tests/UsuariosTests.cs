using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Requests;
using NUnit.Framework;
using RestSharp;

namespace AutomacaoAPIMantisBase2.Tests
{
    public class UsuariosTests : TestBase
    {
        [Test]
        [Parallelizable]
        public void BuscaDadosUsuarioAtual()
        {
            #region Parameters
            //Resultado esperado
            string statusCodeEsperado = "OK";
            string idUsuario = "1";
            string nameUsuario = "administrator";
            #endregion

            UsuariosRequest request = new UsuariosRequest();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(idUsuario, response.Data["id"].ToString());
                Assert.AreEqual(nameUsuario, response.Data["name"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void InsereNovoUsuario()
        {
            #region Parameters
            string usuario = "usertest";
            string senha = "usertest";
            string nome = "Usuario Teste";
            string email = "user@gmail.com";
            //Resultado esperado
            string statusCodeEsperado = "Created";
            #endregion

            UsuariosRequest request = new UsuariosRequest(Method.POST);
            request.setJsonBody(usuario, senha, nome, email);

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual(usuario, response.Data["user"]["name"].ToString());
                Assert.AreEqual(nome, response.Data["user"]["real_name"].ToString());
                Assert.AreEqual(email, response.Data["user"]["email"].ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void DeletaUsuario()
        {
            #region Parameters         
            string idUser = null;
            //Resultado esperado
            string statusCodeEsperado = "NoContent";
            #endregion

            UsuariosRequest request = new UsuariosRequest(Method.POST);
            request.setJsonBody("deleteusertest", "deleteusertest", "Usuario Delete Teste", "delete@gmail.com");
            IRestResponse<dynamic> response = request.ExecuteRequest();
            idUser = response.Data["user"]["id"];

            request = null;
            request = new UsuariosRequest(Method.DELETE);
            request.setUserId(idUser);

            response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        [Parallelizable]
        public void DeletaUsuarioInexistente()
        {
            #region Parameters
            string idUser = "999";
            //Resultado esperado
            string statusCodeEsperado = "NotFound";
            #endregion

            UsuariosRequest request = new UsuariosRequest(Method.DELETE);
            request.setUserId(idUser);
            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
                Assert.AreEqual("User id \'" + idUser + "\' not found.", response.Data["message"].ToString());
            });
        }
    }
}
