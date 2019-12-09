using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class SubProjetosRequest : RequestBase
    {
        public SubProjetosRequest(int id)
        {
            requestService = "/api/rest/projects/" + id + "/subprojects";
            method = Method.POST;
            httpBasicAuthenticator = true;
        }

        public void setJsonBody(string name)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/SubProjetos.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$name", name);
        }
    }
}
