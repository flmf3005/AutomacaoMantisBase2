using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class MonitorPostRequest : RequestBase
    {
        string notes = string.Empty;

        public MonitorPostRequest(string id)
        {
            requestService = "/api/rest/issues/" + id + "/monitors";
            method = Method.POST;
            httpBasicAuthenticator = true;
        }

        public void setJsonBody(string user)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Monitors.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$user", user);
        }
    }
}
