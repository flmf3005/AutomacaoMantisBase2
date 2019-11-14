using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class UsuariosRequest : RequestBase
    {
        public UsuariosRequest()
        {
            requestService = "/api/rest/users/me";
            method = Method.GET;
            httpBasicAuthenticator = true;
        }

        public UsuariosRequest(Method metodo)
        {
            requestService = "/api/rest/users/";
            method = metodo;
            httpBasicAuthenticator = true;
        }

        public void setUserId(string user)
        {
            requestService = requestService + user;
        }

        public void setJsonBody(string usuario, string senha, string nome, string email)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Usuario.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$usuario", usuario).Replace("$senha", senha).Replace("$nome", nome).Replace("$email", email);
        }
    }
}
