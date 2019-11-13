using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class Request : RequestBase
    {
        public Request()
        {
            requestService = "/api/Solicitacao/ItensAssistenciais/Validos";
            method = Method.POST;
            httpBasicAuthenticator = true;
        }

        public void setJsonBody(string pacienteId, string itensAssistenciais)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Solicitacao/SolicitacaoItensAssitenciaisValidosJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$pacienteId", pacienteId).Replace("$itensAssistenciais", itensAssistenciais);
        }
    }
}
