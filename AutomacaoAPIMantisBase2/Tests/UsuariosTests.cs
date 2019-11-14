using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Requests;
using NUnit.Framework;
using RestSharp;

namespace AutomacaoAPIMantisBase2.Tests
{
    public class UsuariosTests : TestBase
    {
        [Test]
        public void BuscaDadosUsuarioAtual()
        {
            #region Parameters
            string statusCodeEsperado = "OK";

            //Resultado esperado

            #endregion

            UsuariosRequest request = new UsuariosRequest();

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        public void InsereNovoUsuario()
        {
            #region Parameters
            string statusCodeEsperado = "Created";

            //Resultado esperado

            #endregion

            UsuariosRequest request = new UsuariosRequest(Method.POST);
            request.setJsonBody("usertest", "usertest", "Usuario Teste", "user@gmail.com");

            IRestResponse<dynamic> response = request.ExecuteRequest();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(statusCodeEsperado, response.StatusCode.ToString());
            });
        }

        [Test]
        public void DeletaUsuario()
        {
            #region Parameters
            string statusCodeEsperado = "NoContent";
            string idUser = null;
            //Resultado esperado

            #endregion

            UsuariosRequest request = new UsuariosRequest(Method.POST);
            request.setJsonBody("usertest", "usertest", "Usuario Teste", "delete@gmail.com");
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
    }
}
