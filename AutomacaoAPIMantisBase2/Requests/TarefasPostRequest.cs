using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class TarefasPostRequest : RequestBase
    {
        string files = string.Empty;

        public TarefasPostRequest()
        {
            requestService = "/api/rest/issues/";
            method = Method.POST;
            httpBasicAuthenticator = true;
        }

        public void adicionaAnexo(string nome, string conteudo)
        {
            if (files.Equals(string.Empty))
            {
                files = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Anexos.json", Encoding.UTF8);
                files = files.Replace("$name", nome).Replace("$content", System.Convert.ToBase64String(Encoding.UTF8.GetBytes(conteudo)));
            }
            else
            {
                files = files + ",\r\n";
                files = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Anexos.json", Encoding.UTF8);
                files = files.Replace("$name", nome).Replace("$content", conteudo);
            }
        }

        public void setJsonBody(string summary, string description, string category, string project)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Tarefas.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$summary", summary).Replace("$description", description).Replace("$category", category).Replace("$project", project).Replace("$files", files);
        }
    }
}
