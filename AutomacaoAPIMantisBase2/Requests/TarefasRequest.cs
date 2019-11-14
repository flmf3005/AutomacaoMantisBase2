using AutomacaoAPIMantisBase2.Bases;
using AutomacaoAPIMantisBase2.Helpers;
using RestSharp;
using System.IO;
using System.Text;

namespace AutomacaoAPIMantisBase2.Requests
{
    public class TarefasRequest : RequestBase
    {
        public TarefasRequest()
        {
            requestService = "/api/rest/issues/";
            method = Method.GET;
            httpBasicAuthenticator = true;
        }

        public TarefasRequest(string issue)
        {
            requestService = "/api/rest/issues/" + issue;
            method = Method.GET;
            httpBasicAuthenticator = true;
        }

        public TarefasRequest(int project)
        {
            requestService = "/api/rest/issues/?project_id=" + project;
            method = Method.GET;
            httpBasicAuthenticator = true;
        }

        public void setJsonBody()
        {
            
        }
    }
}
