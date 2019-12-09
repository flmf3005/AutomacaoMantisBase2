using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class NotasPostRequest : RequestBase
    {
        string notes = string.Empty;

        public NotasPostRequest(string id)
        {
            requestService = "/api/rest/issues/" + id + "/notes";
            method = Method.POST;
            httpBasicAuthenticator = true;
        }

        public void setJsonBody(string text, string name)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Notas.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$text", text).Replace("$name", name);
        }

        public void setJsonBodyWithTimeTracking(string text, string name, string time)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Notas.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$text", text).Replace("$name", name).Replace("$time", time);
        }

        public void setJsonBodyWithTimeTrackingAndAttachment(string text, string name, string time, string attach, string content)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Notas.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$text", text).Replace("$name", name).Replace("$time", time).Replace("$attach", attach).Replace("$content", System.Convert.ToBase64String(Encoding.UTF8.GetBytes(content)));
        }
    }
}
