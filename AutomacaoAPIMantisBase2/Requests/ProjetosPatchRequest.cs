using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class ProjetosPatchRequest : RequestBase
    {
        public ProjetosPatchRequest(string id)
        {
            requestService = "/api/rest/projects/" + id;
            method = Method.PATCH;
            httpBasicAuthenticator = true;
        }

        public void setJsonBody(string id, string name, string descricao)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/AlteraProjeto.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$nome", name).Replace("$descricao", descricao).Replace("$id", id);
        }
    }
}
