using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class TarefasPatchRequest : RequestBase
    {
        string files = string.Empty;

        public TarefasPatchRequest(string id)
        {
            requestService = "/api/rest/issues/" + id;
            method = Method.PATCH;
            httpBasicAuthenticator = true;
        }

        public void setJsonBody(string status)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/AlterarTarefa.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$status", status);
        }
    }
}
