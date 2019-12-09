using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class VersaoRequest : RequestBase
    {
        public VersaoRequest(int id)
        {
            requestService = "/api/rest/projects/" + id + "/versions/";
            method = Method.POST;
            httpBasicAuthenticator = true;
        }
     
        public void setJsonBody(string versao)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Versao.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$versao", versao);
        }
    }
}
