using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class ProjetosPostRequest : RequestBase
    {
        public ProjetosPostRequest()
        {
            requestService = "/api/rest/projects/";
            method = Method.POST;
            httpBasicAuthenticator = true;
        }

        public void setJsonBody(string name, string descricao)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Projetos.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$name", name).Replace("$descricao", descricao);
        }
    }
}
